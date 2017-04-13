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

        public IEnumerable<ConvertedFileInfo> Execute(string sessionId = null)
        {
            return
                from P in this.cacheRepository.GetResultFilesBySessionId(sessionId)
                orderby P.CreateDateUtc descending
                select new ConvertedFileInfo
                {
                    ConvertedFileId = P.ResultFileId,
                    FileNameWithoutExtension = Path.GetFileNameWithoutExtension(P.FileName),
                    FileSizeKb = Math.Round((double)P.FileSize / 1024, 2),
                    CreateDateUtc = P.CreateDateUtc,
                    ExpireDateUtc = P.ExpireDateUtc,
                    Rating = 0
                };
        }
    }
}
