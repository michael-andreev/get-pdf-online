using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using PrecizeSoft.GetPdfOnline.Api.Implementation.Converter.V1;
using PrecizeSoft.GetPdfOnline.Api.WinService.Configuration;

namespace PrecizeSoft.GetPdfOnline.Api.WinService
{
    partial class WindowsService : ServiceBase
    {
        private RootPageHost rootPageHost = null;
        private ServiceHost converterV1ServiceHost = null;

        public WindowsService()
        {
            InitializeComponent();
        }

        protected void ConfigureHosts(IConfigurationRoot configuration)
        {
            //This string must be first, because if the next code will break, the change Callback wouldn't be registered and
            //in the next time this event will not throw
            configuration.GetReloadToken().RegisterChangeCallback((cfg) => { this.ConfigureHosts((IConfigurationRoot)cfg); }, configuration);

            this.CloseHosts();

            UserSettingsOptions options = configuration.Get<UserSettingsOptions>();

            this.CreateAndOpenHosts(options.Host.TcpPort, options.LibreOffice.UseCustomUnoPath, options.LibreOffice.CustomUnoPath);
        }

        protected void CreateAndOpenHosts(int port, bool useLibreOfficeCustomPath, string libreOfficeCustomPath)
        {
            this.rootPageHost = new RootPageHost();
            this.rootPageHost.Open(port);

            converterV1ServiceHost = new ConverterV1ServiceHost(port, useLibreOfficeCustomPath, libreOfficeCustomPath);
            converterV1ServiceHost.Open();
        }

        protected void CloseHosts()
        {
            if ((this.rootPageHost != null) && (this.rootPageHost.IsOpened))
            {
                this.rootPageHost.Close();
            }

            if ((this.converterV1ServiceHost != null) && (this.converterV1ServiceHost.State != CommunicationState.Closed))
            {
                this.converterV1ServiceHost.Close();
            }
        }

        protected override void OnStart(string[] args)
        {
            IConfigurationRoot configuration = new UserSettingsManager().BuildConfiguration();

            this.ConfigureHosts(configuration);
        }

        protected override void OnStop()
        {
            this.CloseHosts();
        }

        internal void TestServiceInConsole()
        {
            this.OnStart(null);
            Console.WriteLine("Service is running. Press any key to stop the Service.");
            Console.ReadKey();
            this.OnStop();
        }
    }
}
