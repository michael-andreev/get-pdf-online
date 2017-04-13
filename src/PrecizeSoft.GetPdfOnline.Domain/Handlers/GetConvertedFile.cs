using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.GetPdfOnline.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class GetConvertedFile
    {
        protected ICacheRepository cacheRepository;

        public GetConvertedFile(ICacheRepository cacheRepository)
        {
            this.cacheRepository = cacheRepository;
        }

        public ConvertedFile Execute(Guid fileId)
        {
            ResultFile resultFile = cacheRepository.GetResultFile(fileId, true);

            return new ConvertedFile
            {
                ConvertedFileId = resultFile.ResultFileId,
                FileBytes = resultFile.Content.FileBytes,
                FileName = resultFile.FileName
            };
        }
    }
}
