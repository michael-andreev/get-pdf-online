using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Wcf.Clients.ConversionStatistics.V1;
using PrecizeSoft.IO.Wcf.MessageContracts.ConversionStatistics.V1;
using PrecizeSoft.IO.Contracts.ConversionStatistics;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class GetStatByHoursViaService
    {
        protected ConversionStatisticsV1ServiceOptions serviceOptions;

        public GetStatByHoursViaService(ConversionStatisticsV1ServiceOptions serviceOptions)
        {
            this.serviceOptions = serviceOptions;
        }

        public IEnumerable<IStatByHour> Execute(DateTimeOffset dateWithTimeZone)
        {
            ServiceClient client = new ServiceClient(new EndpointAddress(this.serviceOptions.Address));

            GetDailyStatMessage message = new GetDailyStatMessage()
            {
                ReportDate = dateWithTimeZone.Date,
                TimeZoneUtcOffsetInMinutes = (short)dateWithTimeZone.Offset.TotalMinutes
            };
            List<StatByHour> result =
            (from P in client.GetDailyStat(message).Data
             select new StatByHour
             {
                 Hour = P.Hour,
                 FileSizeSum = P.FileSizeSum,
                 ResultFileSizeSum = P.ResultFileSizeSum,
                 TotalFileSizeSum = P.TotalFileSizeSum,
                 TotalCount = P.TotalCount
             }).ToList();

            return result;
        }
    }
}
