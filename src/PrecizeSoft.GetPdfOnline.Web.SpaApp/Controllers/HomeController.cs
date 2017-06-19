using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using PrecizeSoft.GetPdfOnline.Web.SpaApp.Localization;
using Microsoft.Extensions.Options;
using PrecizeSoft.GetPdfOnline.Web.SpaApp.Configuration;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Controllers
{
    // [Route("{language:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}")]
    // [Route("")]
    // [Route("{culture}")]
    public class HomeController : Controller
    {
        private readonly GoogleAnalyticsOptions googleAnalyticsOptions;

        public HomeController(IOptionsSnapshot<GoogleAnalyticsOptions> googleAnalyticsOptionsAccessor)
        {
            this.googleAnalyticsOptions = googleAnalyticsOptionsAccessor.Value;
        }

        /*[Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return LocalRedirect("/" + CultureInfo.CurrentCulture.Name + Request.Path);
            // return View();
        }*/

        // [ApiExplorerSettings(IgnoreApi = true)]
        // [Route("")]
        // [Route("{culture}")]
        // [Route("{culture}/Index")]
        //[MiddlewareFilter(typeof(LocalizationPipeline))]
        public IActionResult Index(string culture)
        {
            ViewBag.GaTrackingId = this.googleAnalyticsOptions.TrackingId;

            CultureInfo cultureInfo = LocalizationHelper.ExtractCultureFromPath(Request.Path);

            if (cultureInfo == null)
            {
                return LocalRedirect("/" + CultureInfo.CurrentCulture.Name + Request.Path);
            }
            else
            {
                return View();
            }
        }

        // [Route("Error")]
        // [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
