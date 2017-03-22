using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace PrecizeSoft.GetPdfOnline.Api.WinService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();

            //this.serviceProcessInstaller.StartOnInstall = true;
        }

        private void serviceProcessInstaller_AfterInstall(object sender, InstallEventArgs e)
        {

        }
        
        private void ServiceInstaller_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(serviceInstaller.ServiceName))
            {
                sc.Start();
            }
        }
    }
}
