using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Domain.Models;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Models
{
    public class Statistics
    {
        public SummaryStat Summary { get; set; }

        public IEnumerable<StatByFileCategory> StatByFileCategories { get; set; }

        public IEnumerable<StatByHour> DailyStat { get; set; }
    }
}
