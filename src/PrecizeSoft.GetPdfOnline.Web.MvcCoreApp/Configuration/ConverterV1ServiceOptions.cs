using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration
{
    public class ConverterV1ServiceOptions
    {
        public string Address { get; set; } = "http://localhost:9436/Converter/V1/Service.svc";
    }
}
