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
        private readonly ConverterV1ServiceOptions options;

        public HomeController(IOptionsSnapshot<ConverterV1ServiceOptions> optionsAccessor)
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
                ConvertToPdf handler = new ConvertToPdf(this.options, new ModelStateWrapper(ModelState));

                byte[] resultPdfBytes = null;

                using (Stream inputFileStream = converter.InputFile.OpenReadStream())
                {
                    resultPdfBytes = handler.Execute(inputFileStream, converter.InputFile.FileName);
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
            
            ViewData["Message"] = HttpContext.Request.Host.Port; //"Your application description page.";

            return View();
        }

        public IActionResult Mobile()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Statistics()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Developers()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
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
