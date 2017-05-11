using PrecizeSoft.IO.Contracts.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public class ConvertedFileInfo: IFileInfo
    {
        public Guid FileId { get; set; }

        public string FileName { get; set; }

        public string FileNameWithoutExtension
        {
            get
            {
                return Path.GetFileNameWithoutExtension(this.FileName);
            }
        }

        public int FileSize { get; set; }

        public double FileSizeKb
        {
            get
            {
                return Math.Round((double)this.FileSize / 1024, 2);
            }
        }

        public DateTime CreateDateUtc { get; set; }

        public Guid? SessionId { get; set; }

        public DateTime? ExpireDateUtc { get; set; }

        public byte? Rating { get; set; }
    }
}
