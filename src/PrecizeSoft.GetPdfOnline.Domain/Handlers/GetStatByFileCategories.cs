using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Contracts.ConversionStatistics;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class GetStatByFileCategories
    {
        private readonly IConvertLogRepository convertLogRepository;

        public GetStatByFileCategories(IConvertLogRepository convertLogRepository)
        {
            this.convertLogRepository = convertLogRepository;
        }

        public IEnumerable<IStatByFileCategory> Execute()
        {
            List<StatByFileCategory> result =
                (from P in this.convertLogRepository.GetConvertStatByFileCategories()
                 orderby P.TotalCount descending, P.FileCategoryCode ascending
                 select new StatByFileCategory
                 {
                     FileCategoryCode = P.FileCategoryCode,
                     TotalCount = P.TotalCount,
                     FileSizeAvg = P.FileSizeAvg,
                     FileSizeMax = P.FileSizeMax,
                     FileSizeMin = P.FileSizeMin,
                     FileSizeSum = P.FileSizeSum
                 }).ToList();

            return result;
        }
    }
}
