using System;
using System.Collections.Generic;
using System.Text;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class ConvertSession
    {
        public Guid SessionId { get; set; }

        public DateTimeOffset CreateDateUtc { get; set; }

        public ICollection<ConvertJob> Jobs { get; set; }
    }
}
