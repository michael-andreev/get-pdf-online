using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration
{
    public class ConvertRequestOptions
    {
        public bool AddClientHttpHeadersToCustomAttributes { get; set; } = false;

        public List<string> ClientHttpHeaders { get; set; } = null;
    }
}
