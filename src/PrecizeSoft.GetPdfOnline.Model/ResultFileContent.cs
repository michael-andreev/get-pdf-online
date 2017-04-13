using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class ResultFileContent
    {
        public Guid ResultFileContentId { get; set; }

        public byte[] FileBytes { get; set; }

        public ResultFile ResultFile { get; set; }
    }
}
