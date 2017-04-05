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

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Controllers
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
            ViewData["Message"] = "Convert your files to PDF online";

            return View();
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

                ConvertToPdfViaService handler = new ConvertToPdfViaService(this.options.ServiceClients.ConverterV1Service, new ModelStateWrapper(ModelState));

                byte[] resultPdfBytes = null;

                using (Stream inputFileStream = converter.InputFile.OpenReadStream())
                {
                    resultPdfBytes = handler.Execute(inputFileStream, converter.InputFile.FileName, headers);
                }

                if (resultPdfBytes != null)
                {
                    return File(resultPdfBytes, "application/pdf",
                        System.IO.Path.GetFileNameWithoutExtension(converter.InputFile.FileName) + ".pdf");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
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

        public IActionResult Error()
        {
            return View();
        }
    }
}
