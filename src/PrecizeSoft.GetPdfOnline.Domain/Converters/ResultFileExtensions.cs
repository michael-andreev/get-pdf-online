using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Domain.Models;
using PrecizeSoft.GetPdfOnline.Model;

namespace PrecizeSoft.GetPdfOnline.Domain.Converters
{
    internal static class BinaryFileExtensions
    {
        public static ConvertedFile ToConvertedFile(this BinaryFile file)
        {
            return new ConvertedFile
            {
                FileId = file.FileId,
                FileName = file.FileName,
                FileSize = file.FileSize,
                CreateDateUtc = file.CreateDateUtc,
                Bytes = file.Content.FileBytes
            };
        }

        public static ConvertedFileInfo ToConvertedFileInfo(this BinaryFile file)
        {
            return new ConvertedFileInfo
            {
                FileId = file.FileId,
                FileName = file.FileName,
                FileSize = file.FileSize,
                CreateDateUtc = file.CreateDateUtc
            };
        }
    }
}
