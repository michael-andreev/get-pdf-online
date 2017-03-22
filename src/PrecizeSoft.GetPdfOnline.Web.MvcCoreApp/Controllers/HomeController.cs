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
                var factory = new ConverterFactory();
                //var pdfConverter = factory.CreateWcfConverterV1(new EndpointAddress(@"http://misha-ws.home.local/PrecizeSoft.GetPdfOnline.Api.Host/Converter/V1/Service.svc"));
                //var pdfConverter = factory.CreateWcfConverterV1(new EndpointAddress(@"http://localhost:9436/Converter/V1/Service.svc"));
                var pdfConverter = factory.CreateWcfConverterV1(new EndpointAddress(this.options.Address));

                //ServiceClient client = new ServiceClient();

                byte[] inputFileBytes;

                using (Stream inputFileStream = converter.InputFile.OpenReadStream())
                {
                    inputFileBytes = new byte[inputFileStream.Length];
                    inputFileStream.Read(inputFileBytes, 0, (int)inputFileStream.Length);
                }

                string extension = Path.GetExtension(converter.InputFile.FileName);

                //byte[] resultPdfBytes = client.ConvertToPdfAsync(inputFileBytes, extension).Result;
                byte[] resultPdfBytes = pdfConverter.Convert(inputFileBytes, extension);

                return File(resultPdfBytes, "application/pdf",
                    System.IO.Path.GetFileNameWithoutExtension(converter.InputFile.FileName) + ".pdf");
            }
            else
            {
                ViewData["Message"] = "ERROR";

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
