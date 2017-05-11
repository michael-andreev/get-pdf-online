using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Contracts.ConversionStatistics;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Models
{
    public class Statistics
    {
        public ISummaryStat Summary { get; set; }

        public IEnumerable<IStatByFileCategory> StatByFileCategories { get; set; }

        public IEnumerable<IStatByHour> DailyStat { get; set; }
    }
}
