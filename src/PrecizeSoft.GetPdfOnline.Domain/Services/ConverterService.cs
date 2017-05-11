using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.IO.Converters;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;

namespace PrecizeSoft.GetPdfOnline.Domain.Services
{
    public class ConverterService: FileConverterRouter
    {
        public ConverterService(LibreOfficeOptions options):base(new List<IFileConverter>()
        {
            new ConverterFactory().CreateImageMagickToPdfConverter(),
            new ConverterFactory().CreateLOToPdfConverter(true, options.UseCustomUnoPath ? options.CustomUnoPath : null)
        })
        {
            
        }
    }
}
