using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.IO.Converters;
using PrecizeSoft.GetPdfOnline.Domain.Services;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;

namespace PrecizeSoft.GetPdfOnline.Api.Soap.Implementation.Converter.V1
{
    public class ConverterServiceWrapper: ConverterService
    {
        public ConverterServiceWrapper():base(new LibreOfficeOptions
        {
            UseCustomUnoPath = string.IsNullOrEmpty(V1ServiceConfiguration.LibreOfficePath),
            CustomUnoPath = V1ServiceConfiguration.LibreOfficePath
        })
        {
            
        }
    }
}
