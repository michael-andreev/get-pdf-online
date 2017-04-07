using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.GetPdfOnline.Domain.Contracts;
using PrecizeSoft.IO.Converters;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class GetSupportedFormatsViaService
    {
        protected ConverterV1ServiceOptions serviceOptions;

        public GetSupportedFormatsViaService(ConverterV1ServiceOptions serviceOptions)
        {
            this.serviceOptions = serviceOptions;
        }

        public IEnumerable<string> Execute()
        {
            var pdfConverter = new ConverterFactory().CreateWcfConverterV1(new EndpointAddress(this.serviceOptions.Address));

            return pdfConverter.SupportedFormatCollection;
        }
    }
}
