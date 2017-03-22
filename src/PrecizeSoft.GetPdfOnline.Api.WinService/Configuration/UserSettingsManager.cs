using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace PrecizeSoft.GetPdfOnline.Api.WinService.Configuration
{
    public class UserSettingsManager
    {
        public IConfigurationRoot BuildConfiguration()
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("usersettings.txt", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            return configuration;
        }
    }
}
