using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PrecizeSoft.GetPdfOnline.Domain.Models;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Models
{
    public class Converter
    {
        [Required(ErrorMessage = "Please select a file to convert")]
        public IFormFile InputFile
        {
            get;
            set;
        }

        public string SupportedFormatsString { get; set; }

        public int SupportedFormatsCount { get; set; }

        public IEnumerable<ConvertedFileInfo> ConvertedFiles { get; set; }
    }
}
