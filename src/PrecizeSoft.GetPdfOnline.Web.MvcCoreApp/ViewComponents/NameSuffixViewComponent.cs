using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration;
using PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Models;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.ViewComponents
{
    public class NameSuffixViewComponent: ViewComponent
    {
        private readonly TitleOptions options;

        public NameSuffixViewComponent(IOptionsSnapshot<TitleOptions> optionsAccessor)
        {
            this.options = optionsAccessor.Value;
        }

        public async Task<string> InvokeAsync()
        {
            string suffix = await Task.Run(() =>
            {
                if (options.IncludeSuffix)
                {
                    return options.Suffix
                        .Replace("{HostName}", System.Net.Dns.GetHostName())
                        .Replace("{Port}", Request.Host.Port.Value.ToString());
                }
                else
                {
                    //We can't return null value, because it can't render in View
                    return String.Empty;
                }
            });

            return suffix;
        }
    }
}
