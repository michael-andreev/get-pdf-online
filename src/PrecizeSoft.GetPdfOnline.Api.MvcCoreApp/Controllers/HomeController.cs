using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.ServiceModel;
using System.Diagnostics;
using PrecizeSoft.IO.Converters;
using Microsoft.Extensions.Options;
using PrecizeSoft.GetPdfOnline.Api.MvcCoreApp.Configuration;
using System.Net;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.GetPdfOnline.Domain.Handlers;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Models;

namespace PrecizeSoft.GetPdfOnline.Api.MvcCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserSettingsOptions options;

        public HomeController(IOptionsSnapshot<UserSettingsOptions> optionsAccessor)
        {
            this.options = optionsAccessor.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
