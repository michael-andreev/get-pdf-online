using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Data.SQLite;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;
using PrecizeSoft.GetPdfOnline.Domain.Handlers;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.GetPdfOnline.Model;
using PrecizeSoft.IO.Services.FaultContracts.Converter.V1;
using PrecizeSoft.IO.Services.Implementation.Converter.V1;

namespace PrecizeSoft.GetPdfOnline.Api.Implementation.Converter.V1
{
    public class Service : WcfConverterV1Service<ServiceConverter>
    {
        protected IConvertLogRepository CreateRepository()
        {
            return new ConvertLogRepository(new GetPdfOnlineDbContext(this.connectionString));
        }

        protected readonly string connectionString;

        public Service(): base()
        {
            this.connectionString = V1ServiceConfiguration.ConnectionString;

            this.LogRequestEvent += Service_LogRequestEvent;
            this.LogResponseEvent += Service_LogResponseEvent;
        }

        private void Service_LogRequestEvent(RequestLog request)
        {
            ConvertRequestLog data = new ConvertRequestLog
            {
                RequestId = request.RequestId,
                RequestDateUtc = request.RequestDateUtc,
                SenderIp = request.SenderIp,
                FileExtension = request.FileExtension,
                FileSize = request.FileSize,
                CustomAttributes = request.CustomAttributes
            };

            new CreateConvertRequestLog(this.CreateRepository()).Execute(data);
        }

        private void Service_LogResponseEvent(ResponseLog response)
        {
            FaultException fault = response.Fault;

            ResultTypeEnum resultType;

            if (fault is null)
            {
                resultType = ResultTypeEnum.Positive;
            }
            else if (fault is FaultException<FileBytesEmpty>)
            {
                resultType = ResultTypeEnum.FileBytesEmpty;
            }
            else if (fault is FaultException<FileExtensionEmpty>)
            {
                resultType = ResultTypeEnum.FileExtensionEmpty;
            }
            else if (fault is FaultException<FormatNotSupported>)
            {
                resultType = ResultTypeEnum.FormatNotSupported;
            }
            else if (fault is FaultException<InvalidFileExtension>)
            {
                resultType = ResultTypeEnum.InvalidFileExtension;
            }
            else
            {
                resultType = ResultTypeEnum.OtherError;
            }

            ConvertResponseLog data = new ConvertResponseLog
            {
                RequestId = response.RequestId,
                ResponseDateUtc = response.ResponseDateUtc,
                ResultFileSize = response.ResultFileSize,
                ResultType = resultType
            };

            new CreateConvertResponseLog(this.CreateRepository()).Execute(data);
        }
    }
}
