using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

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
    }
}
