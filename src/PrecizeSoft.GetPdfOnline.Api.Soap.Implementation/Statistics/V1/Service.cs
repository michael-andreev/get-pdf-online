using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.IO.Wcf.MessageContracts.ConversionStatistics.V1;
using PrecizeSoft.IO.Wcf.Implementation.ConversionStatistics.V1;
using PrecizeSoft.GetPdfOnline.Domain.Handlers;
using PrecizeSoft.IO.Wcf.DataContracts.ConversionStatistics.V1;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;
using PrecizeSoft.GetPdfOnline.Data.SQLite;

namespace PrecizeSoft.GetPdfOnline.Api.Soap.Implementation.Statistics.V1
{
    public class Service: WcfConversionStatisticsV1Service
    {
        protected IConvertLogRepository CreateRepository()
        {
            return new ConvertLogRepository(new GetPdfOnlineDbContext(this.connectionString));
        }

        protected readonly string connectionString;

        public Service() : base()
        {
            this.connectionString = V1ServiceConfiguration.ConnectionString;
        }

        public override GetSummaryStatResponseMessage GetSummaryStat(GetSummaryStatMessage message)
        {
            var data = new GetSummaryStat(this.CreateRepository()).Execute();

            return new GetSummaryStatResponseMessage
            {
                Data = new SummaryStat
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
                }
            };
        }

        public override GetStatByFileCategoriesResponseMessage GetStatByFileCategories(GetStatByFileCategoriesMessage message)
        {
            var data = new GetStatByFileCategories(this.CreateRepository()).Execute();

            return new GetStatByFileCategoriesResponseMessage
            {
                Data =
                (from P in data
                 select new StatByFileCategory
                 {
                     FileCategoryCode = P.FileCategoryCode,
                     TotalCount = P.TotalCount,
                     FileSizeAvg = P.FileSizeAvg,
                     FileSizeMax = P.FileSizeMax,
                     FileSizeMin = P.FileSizeMin,
                     FileSizeSum = P.FileSizeSum
                 }).ToList()
            };
        }

        public override GetDailyStatResponseMessage GetDailyStat(GetDailyStatMessage message)
        {
            
            if (message.ReportDate.Kind == DateTimeKind.Local //Can't exctract date from Local time correctly in WCF
                ||
                message.ReportDate.Hour != 0
                ||
                message.ReportDate.Minute != 0
                ||
                message.ReportDate.Second != 0
                ||
                message.ReportDate.Millisecond != 0)
            {
                throw new ArgumentException("Report Date field can not contain Hours, Minutes, Seconds, Milliseconds or TimeZone.");
            }

            if (message.TimeZoneUtcOffsetInMinutes % 15 != 0)
            {
                throw new ArgumentException();
            }

            var date = message.ReportDate.Date;
            var offset = new TimeSpan(0, message.TimeZoneUtcOffsetInMinutes, 0);

            //new DateTimeOffset(message.DateWithTimeZone) - don't work for DateTimeKind.Utc
            var dateWithTimeZone = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, offset);

            var data = new GetStatByHours(this.CreateRepository())
                .Execute(dateWithTimeZone);

            return new GetDailyStatResponseMessage
            {
                Data =
                (from P in data
                 select new StatByHour
                 {
                     Hour = P.Hour,
                     FileSizeSum = P.FileSizeSum,
                     ResultFileSizeSum = P.ResultFileSizeSum,
                     TotalFileSizeSum = P.TotalFileSizeSum,
                     TotalCount = P.TotalCount
                 }).ToList()
            };
        }
    }
}
