using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.SpaServices.Prerendering;
using Microsoft.AspNetCore.NodeServices;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        private IRequest AbstractHttpContextRequestInfo(HttpRequest request)
        {

            IRequest requestSimplified = new IRequest();
            requestSimplified.cookies = request.Cookies;
            requestSimplified.headers = request.Headers;
            requestSimplified.host = request.Host;

            return requestSimplified;
        }

        public IActionResult Error()
        {
            return View();
        }
    }

    public class IRequest
    {
        public object cookies { get; set; }
        public object headers { get; set; }
        public object host { get; set; }
    }

    public class TransferData
    {
        // By default we're expecting the REQUEST Object (in the aspnet engine), so leave this one here
        public dynamic request { get; set; }

        // Your data here ?
        public object thisCameFromDotNET { get; set; }
    }
}
