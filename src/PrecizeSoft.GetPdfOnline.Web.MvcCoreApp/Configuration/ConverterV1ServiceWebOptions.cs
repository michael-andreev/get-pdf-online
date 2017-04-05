using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration
{
    public class ConverterV1ServiceWebOptions: ConverterV1ServiceOptions
    {
        public ConvertRequestOptions ConvertRequest { get; set; } = new ConvertRequestOptions();
    }
}
