using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using PrecizeSoft.GetPdfOnline.Web.SpaApp.Configuration;
using System.Diagnostics;
using Microsoft.Net.Http.Server;
using Microsoft.AspNetCore.Hosting.WindowsServices;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build();

                host.Run();
            }
            else
            {
                IConfigurationRoot configuration = new UserSettingsManager().BuildConfiguration(args);

                ConfigureHost(configuration);
            }
        }

        protected static void ConfigureHost(IConfigurationRoot configuration)
        {
            // This string must be first, because if the next code will break, the change Callback wouldn't be registered and
            // in the next time this event will not throw
            // configuration.GetReloadToken().RegisterChangeCallback((cfg) => { ConfigureHost((IConfigurationRoot)cfg); }, configuration);

            UserSettingsOptions options = configuration.Get<UserSettingsOptions>();

            IWebHostBuilder hostBuilder = new WebHostBuilder()
                //.UseKestrel()
                .UseContentRoot(options.BasePath)
                .UseStartup<Startup>()
                .UseWebListener(opt =>
                {
                    opt.ListenerSettings.Authentication.Schemes = AuthenticationSchemes.None;
                    opt.ListenerSettings.Authentication.AllowAnonymous = true;
                });
                // .UseApplicationInsights();

            IWebHost host;

            if (options.RunAsService)
            {
                host = hostBuilder
                   .UseUrls(new string[1] { $"http://+:{options.Host.TcpPort}" })
                   .Build();

                host.RunAsService();
            }
            else
            {
                host = hostBuilder
                    // .UseIISIntegration()
                    .UseUrls($"http://localhost:{options.Host.TcpPort}")
                    .Build();

                host.Run();
            }
        }
    }
}
