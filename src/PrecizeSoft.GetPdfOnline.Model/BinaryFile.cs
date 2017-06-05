using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class BinaryFile
    {
        public Guid FileId { get; set; }

        public string FileName { get; set; }

        public int FileSize { get; set; }

        public DateTimeOffset CreateDateUtc { get; set; }

        public BinaryFileContent Content { get; set; }

        public ConvertJob ConvertJobOnInput { get; set; }

        public ConvertJob ConvertJobOnOutput { get; set; }
    }
}
