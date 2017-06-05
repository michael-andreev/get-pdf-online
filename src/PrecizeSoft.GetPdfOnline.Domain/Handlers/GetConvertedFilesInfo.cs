using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class GetConvertedFilesInfo
    {
        protected ICacheRepository cacheRepository;

        public GetConvertedFilesInfo(ICacheRepository cacheRepository)
        {
            this.cacheRepository = cacheRepository;
        }

        public IEnumerable<ConvertedFileInfo> Execute(Guid sessionId)
        {
            return
                from P in this.cacheRepository.GetJobsBySession(sessionId, true)
                orderby P.OutputFile.CreateDateUtc descending
                where P.OutputFile != null
                select new ConvertedFileInfo
                {
                    FileId = P.OutputFileId.Value,
                    SessionId = P.SessionId,
                    FileName = P.OutputFile.FileName,
                    FileSize = P.OutputFile.FileSize,
                    CreateDateUtc = P.OutputFile.CreateDateUtc.UtcDateTime,
                    ExpireDateUtc = P.ExpireDateUtc?.UtcDateTime,
                    Rating = P.Rating
                };
        }
    }
}
