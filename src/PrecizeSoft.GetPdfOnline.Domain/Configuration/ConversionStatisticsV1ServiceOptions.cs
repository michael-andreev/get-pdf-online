using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Configuration
{
    public class ConversionStatisticsV1ServiceOptions
    {
        public string Address { get; set; } = "http://localhost:9436/ConversionStatistics/V1/Service.svc";
    }
}
