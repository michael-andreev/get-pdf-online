using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Handlers;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Contracts.Converters;
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
            ResultTypeEnum resultType;

            switch (response.ErrorType)
            {
                case null:
                    resultType = ResultTypeEnum.Positive;
                    break;
                case ConvertErrorType.FileBytesEmpty:
                    resultType = ResultTypeEnum.FileBytesEmpty;
                    break;
                case ConvertErrorType.FileExtensionEmpty:
                    resultType = ResultTypeEnum.FileExtensionEmpty;
                    break;
                case ConvertErrorType.FormatNotSupported:
                    resultType = ResultTypeEnum.FormatNotSupported;
                    break;
                case ConvertErrorType.InvalidFileExtension:
                    resultType = ResultTypeEnum.InvalidFileExtension;
                    break;
                case ConvertErrorType.Other:
                default:
                    resultType = ResultTypeEnum.OtherError;
                    break;
            }

            ConvertResponseLog data = new ConvertResponseLog
            {
                RequestId = response.RequestId,
                ResponseDateUtc = response.ResponseDateUtc,
                ResultFileSize = response.ResultFileSize,
                ResultType = resultType
            };

            new CreateConvertResponseLog(this.convertLogRepository).Execute(data);
        }
    }
}
