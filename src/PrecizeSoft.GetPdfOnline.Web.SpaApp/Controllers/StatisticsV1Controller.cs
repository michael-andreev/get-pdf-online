using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Handlers;
using PrecizeSoft.IO.WebApi.Controllers.ConversionStatistics.V1;
using PrecizeSoft.IO.Contracts.ConversionStatistics;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Controllers
{
    //[Route("[controller]")]
    [Route("api/statistics/v1")]
    public class StatisticsV1Controller : ConversionStatisticsV1ControllerBase
    {
        private readonly IConvertLogRepository convertLogRepository;

        public StatisticsV1Controller(IConvertLogRepository convertLogRepository)
        {
            this.convertLogRepository = convertLogRepository;
        }

        protected override ISummaryStat GetSummaryStatInternal()
        {
            return new GetSummaryStat(this.convertLogRepository).Execute();
        }

        protected override IEnumerable<IStatByFileCategory> GetStatByFileCategoriesInternal()
        {
            return new GetStatByFileCategories(this.convertLogRepository).Execute();
        }

        protected override IEnumerable<IStatByHour> GetDailyStatInternal(DateTimeOffset dateWithTimeZone)
        {
            return new GetStatByHours(this.convertLogRepository).Execute(dateWithTimeZone);
        }
    }
}