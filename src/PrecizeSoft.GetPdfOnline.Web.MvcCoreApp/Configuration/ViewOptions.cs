using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration
{
    public class ViewOptions
    {
        public TitleOptions Title { get; set; } = new TitleOptions();

        public LinksOptions Links { get; set; } = new LinksOptions();
    }
}
