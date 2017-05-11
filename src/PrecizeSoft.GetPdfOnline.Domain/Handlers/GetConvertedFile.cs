using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Converters;
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
            return cacheRepository.GetFile(fileId, true).ToConvertedFile();
        }
    }
}
