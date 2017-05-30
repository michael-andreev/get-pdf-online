using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Net.Http;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Domain.Handlers;
using PrecizeSoft.IO.WebApi.Controllers.Converter.V1;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using Microsoft.Extensions.Options;
using PrecizeSoft.GetPdfOnline.Domain.Services;
using PrecizeSoft.GetPdfOnline.Web.SpaApp.Swagger;
using PrecizeSoft.IO.WebApi.Contracts.Converter.V1;
using PrecizeSoft.IO.Contracts.Converters;
using Microsoft.AspNetCore.Cors;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Controllers
{
    //[Route("[controller]")]
    [Route("api/converter/v1")]
    //[Consumes("application/json", "application/json-patch+json", "multipart/form-data", "application/octet-stream")]
    //[EnableCors("AllowSpecificOrigin")]
    public class ConverterV1Controller : ConverterV1ControllerBase
    {
        public ConverterV1Controller(IOptionsSnapshot<LibreOfficeOptions> optionsAccessor, IJobService jobService,
            IFileService fileService, IOptionsSnapshot<StoreOptions> storeOptionsAccessor, ILogService logService) :
            base(new ConverterService(optionsAccessor.Value), jobService, fileService, storeOptionsAccessor.Value,
                logService)
        {

        }

        /// <summary>
        /// Download file (source or converted) by ID
        /// </summary>
        /// <param name="id">File ID (GUID)</param>
        /// <returns>File (source or converted)</returns>
        [SwaggerFileResponse(System.Net.HttpStatusCode.OK, Description = "Success")]
        public override IActionResult GetFile(Guid id)
        {
            return base.GetFile(id);
        }
    }
}