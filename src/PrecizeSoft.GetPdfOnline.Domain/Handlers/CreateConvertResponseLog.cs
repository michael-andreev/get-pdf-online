using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.GetPdfOnline.Model;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class CreateConvertResponseLog
    {
        private readonly IConvertLogRepository convertLogRepository;

        public CreateConvertResponseLog(IConvertLogRepository convertLogRepository)
        {
            this.convertLogRepository = convertLogRepository;
        }

        public void Execute(ConvertResponseLog responseLog)
        {
            ConvertResponse data = new ConvertResponse
            {
                ConvertResponseId = responseLog.RequestId,
                ResponseDateUtc = responseLog.ResponseDateUtc,
                ResultFileSize = responseLog.ResultFileSize,
                ResultTypeId = (int)responseLog.ResultType
            };

            this.convertLogRepository.CreateConvertResponse(data);
        }
    }
}
