using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.GetPdfOnline.Model;
using PrecizeSoft.IO.Contracts.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Converters
{
    internal static class IJobExtensions
    {
        public static ConvertJob ToConvertJob(this IJob job)
        {
            return new ConvertJob
            {
                ConvertJobId = job.JobId,
                SessionId = job.SessionId,
                ExpireDateUtc = job.ExpireDateUtc,
                InputFileId = job.InputFileId,
                OutputFileId = job.OutputFileId,
                ErrorTypeId = job.ErrorType?.ToInt(),
                Rating = job.Rating
            };
        }
    }
}
