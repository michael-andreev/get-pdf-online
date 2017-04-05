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
    public class ConvertToPdfViaService
    {
        protected ConverterV1ServiceOptions serviceOptions;
        protected IValidationDictionary validationDictionary;

        public ConvertToPdfViaService(ConverterV1ServiceOptions serviceOptions, IValidationDictionary validationDictionary)
        {
            this.serviceOptions = serviceOptions;
            this.validationDictionary = validationDictionary;
        }

        public byte[] Execute(Stream fileStream, string fileName, IDictionary customAttributes)
        {
            byte[] inputFileBytes;

                inputFileBytes = new byte[fileStream.Length];
                fileStream.Read(inputFileBytes, 0, (int)fileStream.Length);

            string extension = Path.GetExtension(fileName);

            var pdfConverter = new ConverterFactory().CreateWcfConverterV1(new EndpointAddress(this.serviceOptions.Address),
                customAttributes);

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
            catch
            {
                this.validationDictionary.AddError("ApiService", "An unexpected error occurred. Please try again. If the problem persists, please contact the developer.");
            }

            return resultPdfBytes;
        }
    }
}
