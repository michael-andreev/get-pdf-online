using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class ResultFile
    {
        public Guid ResultFileId { get; set; }

        public DateTime CreateDateUtc { get; set; }

        public DateTime ExpireDateUtc { get; set; }

        public string SessionId { get; set; }

        public string FileName { get; set; }

        public int FileSize { get; set; }

        public ResultFileContent Content { get; set; }
    }
}
