using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Configuration
{
    public class ServiceClientsOptions
    {
        public ConverterV1ServiceOptions ConverterV1Service { get; set; } = new ConverterV1ServiceOptions();
    }
}
