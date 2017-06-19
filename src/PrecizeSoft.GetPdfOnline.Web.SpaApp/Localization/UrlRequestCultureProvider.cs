﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Localization
{
    public class UrlRequestCultureProvider : IRequestCultureProvider
    {
        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            CultureInfo culture = LocalizationHelper.ExtractCultureFromPath(httpContext.Request.Path);

            if (culture == null)
            {
                return Task.FromResult<ProviderCultureResult>(null);
            }
            else
            {
                httpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

                return Task.FromResult(new ProviderCultureResult(culture.Name));
            }
        }
    }
}
