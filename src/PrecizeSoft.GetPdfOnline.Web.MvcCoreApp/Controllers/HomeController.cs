using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Models;
using System.IO;
using System.ServiceModel;
using System.Diagnostics;
using PrecizeSoft.IO.Converters;
using Microsoft.Extensions.Options;
using PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration;
using System.Net;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.GetPdfOnline.Domain.Handlers;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Models;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserSettingsOptions options;

        private readonly ICacheRepository cacheRepository;

        public HomeController(IOptionsSnapshot<UserSettingsOptions> optionsAccessor, ICacheRepository cacheRepository)
        {
            this.options = optionsAccessor.Value;
            this.cacheRepository = cacheRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Converter model = new Converter();

            IEnumerable<string> formats = new GetSupportedFormatsViaService(this.options.ServiceClients.ConverterV1Service).Execute();
            model.SupportedFormatsCount = formats.Count();
            model.SupportedFormatsString = string.Join(", ", formats);
            {
                GetConvertedFilesInfo handler = new GetConvertedFilesInfo(this.cacheRepository);
                model.ConvertedFiles = handler.Execute(Guid.Parse(HttpContext.Session.Id));
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(Converter converter)
        {
            if (ModelState.IsValid)
            {
                Dictionary<string, string> headers = null;
                if (this.options.ServiceClients.ConverterV1Service.ConvertRequest.AddClientHttpHeadersToCustomAttributes)
                {
                    headers =
                        (from P in Request.Headers
                         where this.options.ServiceClients.ConverterV1Service.ConvertRequest.ClientHttpHeaders.Contains(P.Key)
                         select P).ToDictionary(P => P.Key, P => P.Value.ToString());
                }

                ConvertToPdfViaService handler = new ConvertToPdfViaService(this.options.ServiceClients.ConverterV1Service,
                    new ModelStateWrapper(ModelState), this.cacheRepository);

                bool result = false;

                using (Stream inputFileStream = converter.InputFile.OpenReadStream())
                {
                    result = handler.Execute(inputFileStream, converter.InputFile.FileName, headers, Guid.Parse(HttpContext.Session.Id));
                }
            }

            Converter model = new Converter();

            IEnumerable<string> formats = new GetSupportedFormatsViaService(this.options.ServiceClients.ConverterV1Service).Execute();
            model.SupportedFormatsCount = formats.Count();
            model.SupportedFormatsString = string.Join(", ", formats);
            {
                GetConvertedFilesInfo handler = new GetConvertedFilesInfo(this.cacheRepository);
                model.ConvertedFiles = handler.Execute(Guid.Parse(HttpContext.Session.Id));
            }

            return View(model);
        }

        [HttpGet]
        public FileContentResult GetPdf(Guid id)
        {
            GetConvertedFile handler = new GetConvertedFile(this.cacheRepository);

            ConvertedFile file = handler.Execute(id);

            return File(file.Bytes, "application/pdf", file.FileName);
        }

        public IActionResult Download()
        {

            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Mobile()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Statistics()
        {
            Statistics model = new Models.Statistics()
            {
                Summary = new GetSummaryStatViaService(this.options.ServiceClients.ConversionStatisticsV1Service).Execute(),
                StatByFileCategories = new GetStatByFileCategoriesViaService(this.options.ServiceClients.ConversionStatisticsV1Service).Execute(),
                DailyStat = new GetStatByHoursViaService(this.options.ServiceClients.ConversionStatisticsV1Service).Execute(DateTimeOffset.Now.Date)
            };
            return View(model);
        }

        public IActionResult Developers()
        {
            Developers model = new Models.Developers();
            model.ApiUrl = this.options.View.Links.ApiUrl;

            ViewData["Message"] = "Api";

            return View(model);
        }

        public IActionResult Comments()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult About()
        {
            //ServiceClient client = new ServiceClient();

            ViewData["Message"] = "Your application description page.";
            //ViewData["Message"] = client.TestAsync().Result;

            return View();
        }

        /*public IActionResult Contacts()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }*/

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
