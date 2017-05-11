using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class ConvertJob
    {
        public Guid ConvertJobId { get; set; }

        public DateTime? ExpireDateUtc { get; set; }

        public Guid? SessionId { get; set; }

        public Guid InputFileId { get; set; }

        public Guid OutputFileId { get; set; }

        public BinaryFile InputFile { get; set; }

        public BinaryFile OutputFile { get; set; }

        public byte? Rating { get; set; }
    }
}
