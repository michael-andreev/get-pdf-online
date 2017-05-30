using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.IO.Contracts.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Converters
{
    internal static class ConvertErrorTypeExtensions
    {
        public static int ToInt(this ConvertErrorType errorType)
        {
            switch (errorType)
            {
                case ConvertErrorType.FileBytesEmpty:
                    return 10;
                case ConvertErrorType.FileExtensionEmpty:
                    return 20;
                case ConvertErrorType.FormatNotSupported:
                    return 40;
                case ConvertErrorType.InvalidFileExtension:
                    return 30;
                case ConvertErrorType.Other:
                    return 99;
                default:
                    throw new NotImplementedException("Unknown error type");
            }
        }

        public static ResultTypeEnum ToResultType(this ConvertErrorType? errorType)
        {
            return (errorType == null) ? ResultTypeEnum.Positive :
                (ResultTypeEnum)errorType.Value.ToInt();
        }
    }
}
