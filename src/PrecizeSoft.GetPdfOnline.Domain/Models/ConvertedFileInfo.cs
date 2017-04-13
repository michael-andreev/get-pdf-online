using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public class ConvertedFileInfo
    {
        public Guid ConvertedFileId { get; set; }

        public string FileNameWithoutExtension { get; set; }

        public double FileSizeKb { get; set; }

        public DateTime CreateDateUtc { get; set; }

        public DateTime ExpireDateUtc { get; set; }

        public byte Rating { get; set; }
    }
}
