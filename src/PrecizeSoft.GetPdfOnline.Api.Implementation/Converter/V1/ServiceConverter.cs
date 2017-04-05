using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.IO.Converters;

namespace PrecizeSoft.GetPdfOnline.Api.Implementation.Converter.V1
{
    public class ServiceConverter: PrecizeSoft.IO.Converters.FileConverterRouter
    {
        public ServiceConverter():base(new List<IFileConverter>()
        {
            new ConverterFactory().CreateImageMagickToPdfConverter(),
            new ConverterFactory().CreateLOToPdfConverter(true, V1ServiceConfiguration.LibreOfficePath)
        })
        {
            
        }
    }
}
