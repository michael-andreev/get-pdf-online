using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;

namespace PrecizeSoft.GetPdfOnline.Api.WinService.Configuration
{
    public class UserSettingsOptions
    {
        public HostOptions Host { get; set; } = new HostOptions();

        public LibreOfficeOptions LibreOffice { get; set; } = new LibreOfficeOptions();

        public DataOptions Data { get; set; } = new DataOptions();
    }
}
