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
    internal static class ConvertJobExtensions
    {
        public static Job ToJob(this ConvertJob job)
        {
            return new Job
            {
                JobId = job.ConvertJobId,
                SessionId = job.SessionId,
                ExpireDateUtc = job.ExpireDateUtc?.UtcDateTime,
                InputFileId = job.InputFileId,
                OutputFileId = job.OutputFileId,
                ErrorType = (ConvertErrorType?)job.ErrorTypeId,
                Rating = job.Rating
            };
        }
    }
}
