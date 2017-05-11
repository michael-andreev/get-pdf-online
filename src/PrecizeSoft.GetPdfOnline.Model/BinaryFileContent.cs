using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class BinaryFileContent
    {
        public Guid FileContentId { get; set; }

        public byte[] FileBytes { get; set; }

        public BinaryFile File { get; set; }
    }
}
