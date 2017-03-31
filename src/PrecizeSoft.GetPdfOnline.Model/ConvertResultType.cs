using System.Collections.Generic;

namespace PrecizeSoft.GetPdfOnline.Model
{
    public class ConvertResultType
    {
        public int ConvertResultTypeId { get; set; }

        public string ConvertResultTypeCode { get; set; }

        public ICollection<ConvertResponse> ConvertResponses { get; set; }
    }
}