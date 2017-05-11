using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.GetPdfOnline.Domain.Contracts;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Converters;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Model;
using PrecizeSoft.IO.Wcf.Clients.Converter.V1;
using PrecizeSoft.IO.Wcf.MessageContracts.Converter.V1;
using PrecizeSoft.IO.Wcf.DataContracts.Converter.V1;

namespace PrecizeSoft.GetPdfOnline.Domain.Handlers
{
    public class ConvertToPdfViaService
    {
        protected ConverterV1ServiceOptions serviceOptions;
        protected IValidationDictionary validationDictionary;
        protected ICacheRepository cacheRepository;

        public ConvertToPdfViaService(ConverterV1ServiceOptions serviceOptions, IValidationDictionary validationDictionary, ICacheRepository cacheRepository)
        {
            this.serviceOptions = serviceOptions;
            this.validationDictionary = validationDictionary;
            this.cacheRepository = cacheRepository;
        }

        public bool Execute(Stream fileStream, string fileName, IDictionary customAttributes, Guid? sessionId = null)
        {
            byte[] inputFileBytes;

            inputFileBytes = new byte[fileStream.Length];
            fileStream.Read(inputFileBytes, 0, (int)fileStream.Length);

            string extension = Path.GetExtension(fileName);

            List<CustomAttribute> attr = null;

            if (customAttributes != null)
            {
                attr = new List<CustomAttribute>();

                foreach (var p in customAttributes.Keys)
                    attr.Add(new CustomAttribute
                    {
                        Name = p.ToString(),
                        Value = customAttributes[p].ToString()
                    });
            }

            var pdfConverter = new ServiceClient(new EndpointAddress(this.serviceOptions.Address));

            ConvertResponseMessage result = null;

            try
            {
                result = pdfConverter.Convert(new ConvertMessage
                {
                    FileBytes = inputFileBytes,
                    FileExtension = extension,
                    CustomAttributes = attr
                });
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

            ConvertJob job = null;

            if (result != null)
            {
                job = new ConvertJob
                {
                    ConvertJobId = result.RequestId,
                    SessionId = sessionId,
                    ExpireDateUtc = DateTime.Now.ToUniversalTime() + TimeSpan.FromHours(1),
                    InputFile = new BinaryFile
                    {
                        FileId = Guid.NewGuid(),
                        CreateDateUtc = DateTime.UtcNow,
                        FileName = fileName,
                        FileSize = inputFileBytes.Length,
                        Content = new BinaryFileContent
                        {
                            FileBytes = inputFileBytes
                        }
                    },
                    OutputFile = new BinaryFile
                    {
                        FileId = Guid.NewGuid(),
                        CreateDateUtc = DateTime.UtcNow,
                        FileName = Path.GetFileNameWithoutExtension(fileName) + ".pdf",
                        FileSize = result.FileBytes.Length,
                        Content = new BinaryFileContent
                        {
                            FileBytes = result.FileBytes
                        }
                    }
                };

                cacheRepository.CreateJob(job);
            }

            return (result != null);
        }
    }
}
