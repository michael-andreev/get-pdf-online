using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Services.Clients.ConversionStatistics.V1;
using PrecizeSoft.IO.Services.MessageContracts.ConversionStatistics.V1;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class GetSummaryStatViaService
    {
        protected ConversionStatisticsV1ServiceOptions serviceOptions;

        public GetSummaryStatViaService(ConversionStatisticsV1ServiceOptions serviceOptions)
        {
            this.serviceOptions = serviceOptions;
        }

        public SummaryStat Execute()
        {
            ServiceClient client = new ServiceClient(new EndpointAddress(this.serviceOptions.Address));

            var data = client.GetSummaryStat(new GetSummaryStatMessage()).Data;

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
