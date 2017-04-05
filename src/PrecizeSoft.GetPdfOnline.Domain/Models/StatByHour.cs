using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public class StatByHour
    {
        public int Hour { get; set; }

        public int TotalCount { get; set; }

        public long FileSizeSum { get; set; }

        public long ResultFileSizeSum { get; set; }

        public long TotalFileSizeSum { get; set; }
    }
}
