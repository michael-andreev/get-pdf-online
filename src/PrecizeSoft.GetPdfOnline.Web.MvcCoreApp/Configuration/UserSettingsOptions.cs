using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration
{
    public class UserSettingsOptions
    {
        public string BasePath { get; set; } = null;

        public bool RunAsService { get; set; } = false;

        public HostOptions Host { get; set; } = new HostOptions();

        public ServiceClientsOptions ServiceClients { get; set; } = new ServiceClientsOptions();

        public ViewOptions View { get; set; } = new ViewOptions();
    }
}
