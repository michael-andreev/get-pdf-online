using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Localization
{
    /*public class CustomRouteDataRequestCultureProvider : RouteDataRequestCultureProvider
    {
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            CultureInfo culture = LocalizationHelper.ExtractCultureFromPath(httpContext.Request.Path);

            if (culture != null)
            {
                httpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

                return base.DetermineProviderCultureResult(httpContext);
            }
            else
            {
                return Task.FromResult<ProviderCultureResult>(null);
            }
        }
    }*/
}
