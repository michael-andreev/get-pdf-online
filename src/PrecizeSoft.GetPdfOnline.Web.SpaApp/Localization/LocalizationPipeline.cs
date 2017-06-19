using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Text.RegularExpressions;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Localization
{
    /*public class LocalizationPipeline
    {
        public void Configure(IApplicationBuilder app)
        {
            RequestLocalizationOptions globalOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
            
            RequestLocalizationOptions routeOptions = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = globalOptions.DefaultRequestCulture,
                FallBackToParentCultures = globalOptions.FallBackToParentCultures,
                FallBackToParentUICultures = globalOptions.FallBackToParentUICultures,
                SupportedCultures = globalOptions.SupportedCultures,
                SupportedUICultures = globalOptions.SupportedUICultures
            };
            routeOptions.RequestCultureProviders = new List<IRequestCultureProvider>
            {
                new CustomRouteDataRequestCultureProvider() { Options = routeOptions, RouteDataStringKey = "culture", UIRouteDataStringKey = "culture" }
            };
            foreach (var provider in globalOptions.RequestCultureProviders)
            {
                routeOptions.RequestCultureProviders.Add(provider);
            }

            app.UseRequestLocalization(routeOptions);

            //app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
        }
    }*/
}
