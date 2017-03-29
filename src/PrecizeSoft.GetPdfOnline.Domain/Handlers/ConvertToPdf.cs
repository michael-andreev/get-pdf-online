using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.GetPdfOnline.Domain.Contracts;
using PrecizeSoft.IO.Converters;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class ConvertToPdf
    {
        protected ConverterV1ServiceOptions serviceOptions;
        protected IValidationDictionary validationDictionary;

        public ConvertToPdf(ConverterV1ServiceOptions serviceOptions, IValidationDictionary validationDictionary)
        {
            this.serviceOptions = serviceOptions;
            this.validationDictionary = validationDictionary;
        }

        public byte[] Execute(Stream fileStream, string fileName)
        {
            var pdfConverter = new ConverterFactory().CreateWcfConverterV1(new EndpointAddress(this.serviceOptions.Address));

            byte[] inputFileBytes;

                inputFileBytes = new byte[fileStream.Length];
                fileStream.Read(inputFileBytes, 0, (int)fileStream.Length);

            string extension = Path.GetExtension(fileName);

            byte[] resultPdfBytes = null;

            try
            {
                resultPdfBytes = pdfConverter.Convert(inputFileBytes, extension);
            }
            catch (FileExtensionNullException)
            {
                this.validationDictionary.AddError("FileExtension", "File doesn't have extension");
            }
            catch (FormatNotSupportedException)
            {
                this.validationDictionary.AddError("FileExtension", "File format doesn't supported");
            }
            catch (EndpointNotFoundException)
            {
                this.validationDictionary.AddError("ApiService", "Service is unavailable. Please try again later.");
            }

            return resultPdfBytes;
        }
    }
}
