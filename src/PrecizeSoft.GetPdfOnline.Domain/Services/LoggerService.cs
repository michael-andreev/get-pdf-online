using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Handlers;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Contracts.Converters;
using PrecizeSoft.GetPdfOnline.Domain.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Services
{
    public class LoggerService : ILogService
    {
        protected IConvertLogRepository convertLogRepository;

        public LoggerService(IConvertLogRepository convertLogRepository)
        {
            this.convertLogRepository = convertLogRepository;
        }

        public void LogRequest(RequestLog request)
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

            new CreateConvertRequestLog(this.convertLogRepository).Execute(data);
        }

        public void LogResponse(ResponseLog response)
        {
            ConvertResponseLog data = new ConvertResponseLog
            {
                RequestId = response.RequestId,
                ResponseDateUtc = response.ResponseDateUtc,
                ResultFileSize = response.ResultFileSize,
                ResultType = response.ErrorType.ToResultType()
            };

            new CreateConvertResponseLog(this.convertLogRepository).Execute(data);
        }
    }
}
