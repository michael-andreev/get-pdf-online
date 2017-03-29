using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration
{
    public class TitleOptions
    {
        public bool IncludeSuffix { get; set; } = false;
        public string Suffix { get; set; } = null;
    }
}
