using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp.Configuration
{
    public class UserSettingsManager
    {
        public IConfigurationRoot BuildConfiguration(string[] args)
        {
            bool runAsService = args.Contains("--run-as-service");
            string dir = runAsService ? AppContext.BaseDirectory : Directory.GetCurrentDirectory();

            Dictionary<string, string> argsOptions = new Dictionary<string, string>
            {
                { "BasePath", dir },
                { "RunAsService", runAsService.ToString() }
            };

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(dir)
                .AddJsonFile("usersettings.txt", optional: false, reloadOnChange: true)
                .AddInMemoryCollection(argsOptions);

            var configuration = builder.Build();

            return configuration;
        }
    }
}
