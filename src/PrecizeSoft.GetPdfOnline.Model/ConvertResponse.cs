using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class ConvertResponse
    {
        public Guid ConvertResponseId { get; set; }

        public DateTimeOffset ResponseDateUtc { get; set; }

        public int ResultTypeId { get; set; }

        public int? ResultFileSize { get; set; }

        public ConvertRequest Request { get; set; }

        public ConvertResultType ResultType { get; set; }
    }
}
