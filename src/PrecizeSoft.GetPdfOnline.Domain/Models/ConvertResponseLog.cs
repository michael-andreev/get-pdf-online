using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Models
{
    public class ConvertResponseLog
    {
        public Guid RequestId { get; set; }

        public DateTime ResponseDateUtc { get; set; }

        public ResultTypeEnum ResultType { get; set; }

        public int? ResultFileSize { get; set; }
    }
}
