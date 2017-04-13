using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public class ConvertedFile
    {
        public Guid ConvertedFileId { get; set; }

        public string FileName { get; set; }

        public byte[] FileBytes { get; set; }
    }
}
