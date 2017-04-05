using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public class SummaryStat
    {
        public DateTime? FirstRequestDateUtc { get; set; }

        public DateTime? LastRequestDateUtc { get; set; }

        public double DurationInSecondsAvg { get; set; }

        public double DurationInSecondsMin { get; set; }

        public double DurationInSecondsMax { get; set; }

        public int TotalCount { get; set; }

        public int PositiveResultCount { get; set; }

        public int NegativeResultCount { get; set; }

        public long FileSizeSum { get; set; }

        public int FileSizeAvg { get; set; }

        public int FileSizeMin { get; set; }

        public int FileSizeMax { get; set; }

        public long ResultFileSizeSum { get; set; }

        public int ResultFileSizeAvg { get; set; }

        public int ResultFileSizeMin { get; set; }

        public int ResultFileSizeMax { get; set; }

        public long TotalFileSizeSum { get; set; }
    }
}
