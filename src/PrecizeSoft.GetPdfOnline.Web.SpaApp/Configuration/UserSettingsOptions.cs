using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.IO.Contracts.Converters;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Configuration
{
    public class UserSettingsOptions
    {
        public string BasePath { get; set; } = null;

        public bool RunAsService { get; set; } = false;

        public HostOptions Host { get; set; } = new HostOptions();

        public LibreOfficeOptions LibreOffice { get; set; } = new LibreOfficeOptions();

        public DataOptions Data { get; set; } = new DataOptions();

        public StoreOptions Cache { get; set; } = new StoreOptions();

        public ViewOptions View { get; set; } = new ViewOptions();

        public GoogleAnalyticsOptions GoogleAnalytics { get; set; } = new GoogleAnalyticsOptions();
    }
}
