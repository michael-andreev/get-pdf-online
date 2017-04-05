using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public enum ResultTypeEnum
    {
        UNKNOWN = 0,
        Positive = 1,
        FileBytesEmpty = 10,
        FileExtensionEmpty = 20,
        InvalidFileExtension = 30,
        FormatNotSupported = 40,
        OtherError = 99
    }
}
