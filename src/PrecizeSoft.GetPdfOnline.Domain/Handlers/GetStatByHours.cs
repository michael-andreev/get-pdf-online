using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Models;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class GetStatByHours
    {
        private readonly IConvertLogRepository convertLogRepository;

        public GetStatByHours(IConvertLogRepository convertLogRepository)
        {
            this.convertLogRepository = convertLogRepository;
        }

        public IEnumerable<StatByHour> Execute(DateTimeOffset dateWithTimeZone)
        {
            List<StatByHour> result =
                (from P in this.convertLogRepository.GetConvertStatByHoursForDay(dateWithTimeZone)
                 select new StatByHour
                 {
                     Hour = P.BeginRequestDateUtc.Add(dateWithTimeZone.Offset).Hour,
                     FileSizeSum = P.FileSizeSum,
                     ResultFileSizeSum = P.ResultFileSizeSum,
                     TotalFileSizeSum = P.TotalFileSizeSum,
                     TotalCount = P.TotalCount
                 }).ToList();

            return result;
        }
    }
}
