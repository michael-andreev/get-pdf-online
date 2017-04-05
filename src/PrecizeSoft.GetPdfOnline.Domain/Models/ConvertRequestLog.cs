using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public class ConvertRequestLog
    {
        public Guid RequestId { get; set; }

        public DateTime RequestDateUtc { get; set; }

        public string SenderIp { get; set; }

        public string FileExtension { get; set; }

        public int FileSize { get; set; }

        public Dictionary<string, string> CustomAttributes { get; set; }
    }
}
