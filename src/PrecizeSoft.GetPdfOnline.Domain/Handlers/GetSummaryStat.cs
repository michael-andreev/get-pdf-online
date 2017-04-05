using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Models;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class GetSummaryStat
    {
        private readonly IConvertLogRepository convertLogRepository;

        public GetSummaryStat(IConvertLogRepository convertLogRepository)
        {
            this.convertLogRepository = convertLogRepository;
        }

        public SummaryStat Execute()
        {
            var data = this.convertLogRepository.GetConvertStatTotal();

            SummaryStat result = new SummaryStat
            {
                FirstRequestDateUtc = data.FirstRequestDateUtc,
                LastRequestDateUtc = data.LastRequestDateUtc,
                DurationInSecondsAvg = data.DurationInSecondsAvg,
                DurationInSecondsMin = data.DurationInSecondsMin,
                DurationInSecondsMax = data.DurationInSecondsMax,
                TotalCount = data.TotalCount,
                PositiveResultCount = data.PositiveResultCount,
                NegativeResultCount = data.NegativeResultCount,
                FileSizeSum = data.FileSizeSum,
                FileSizeAvg = data.FileSizeAvg,
                FileSizeMin = data.FileSizeMin,
                FileSizeMax = data.FileSizeMax,
                ResultFileSizeSum = data.ResultFileSizeSum,
                ResultFileSizeAvg = data.ResultFileSizeAvg,
                ResultFileSizeMin = data.ResultFileSizeMin,
                ResultFileSizeMax = data.ResultFileSizeMax,
                TotalFileSizeSum = data.TotalFileSizeSum
            };

            return result;
        }
    }
}
