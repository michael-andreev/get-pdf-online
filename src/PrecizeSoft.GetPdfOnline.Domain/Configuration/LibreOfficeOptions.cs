using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Domain.Configuration
{
    public class LibreOfficeOptions
    {
        public bool UseCustomUnoPath { get; set; } = false;

        public string CustomUnoPath { get; set; } = null;
    }
}
