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
    public class CreateConvertRequestLog
    {
        private readonly IConvertLogRepository convertLogRepository;

        public CreateConvertRequestLog(IConvertLogRepository convertLogRepository)
        {
            this.convertLogRepository = convertLogRepository;
        }

        public void Execute(ConvertRequestLog requestLog)
        {
            ConvertRequest data = new ConvertRequest
            {
                ConvertRequestId = requestLog.RequestId,
                RequestDateUtc = requestLog.RequestDateUtc,
                SenderIp = requestLog.SenderIp,
                FileExtension = requestLog.FileExtension,
                FileSize = requestLog.FileSize,
                FileType = this.convertLogRepository.GetFileTypeByExtension(requestLog.FileExtension),
                CustomAttributes = string.Join(";", requestLog.CustomAttributes.Select(p => $"{p.Key}=\"{p.Value}\""))
            };

            this.convertLogRepository.CreateConvertRequest(data);
        }
    }
}
