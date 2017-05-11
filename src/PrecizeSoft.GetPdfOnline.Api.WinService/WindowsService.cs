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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using PrecizeSoft.GetPdfOnline.Api.WinService.Configuration;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Data.SQLite;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;
using PrecizeSoft.GetPdfOnline.Api.Soap.Host;

namespace PrecizeSoft.GetPdfOnline.Api.WinService
{
    partial class WindowsService : ServiceBase
    {
        protected SoapApiHost soapApiHost = null;

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

            GetPdfOnlineDbContext context = new GetPdfOnlineDbContext(options.Data.ConnectionString);
            context.Database.Migrate();
            //context.Seed();
            //context.SaveChanges();

            this.CreateAndOpenHosts(options.Host.TcpPort, options.LibreOffice.UseCustomUnoPath, options.LibreOffice.CustomUnoPath,
                options.Data.ConnectionString);
        }

        protected void CreateAndOpenHosts(int port, bool useLibreOfficeCustomPath, string libreOfficeCustomPath,
            string connectionString)
        {
            this.soapApiHost = new SoapApiHost();
            this.soapApiHost.Configure(true, port, "/soap", useLibreOfficeCustomPath, libreOfficeCustomPath, connectionString);
            this.soapApiHost.Open();
        }

        protected void CloseHosts()
        {
            if ((this.soapApiHost != null) && (this.soapApiHost.IsOpened))
            {
                this.soapApiHost.Close();
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
