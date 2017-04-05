using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration
{
    public class ServiceClientsOptions
    {
        public ConverterV1ServiceWebOptions ConverterV1Service { get; set; } = new ConverterV1ServiceWebOptions();

        public ConversionStatisticsV1ServiceOptions ConversionStatisticsV1Service { get; set; } = new ConversionStatisticsV1ServiceOptions();
    }
}
