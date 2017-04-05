using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public class StatByFileCategory
    {
        public string FileCategoryCode { get; set; }

        public int TotalCount { get; set; }

        public long FileSizeSum { get; set; }

        public int FileSizeAvg { get; set; }

        public int FileSizeMin { get; set; }

        public int FileSizeMax { get; set; }
    }
}
