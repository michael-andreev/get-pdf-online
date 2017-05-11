using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using PrecizeSoft.GetPdfOnline.Web.MvcCoreApp.Configuration;
using PrecizeSoft.GetPdfOnline.Data.SQLite;
using Microsoft.Data.Sqlite;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;
using PrecizeSoft.GetPdfOnline.Model;
using Microsoft.AspNetCore.Http;

namespace PrecizeSoft.GetPdfOnline.Web.MvcCoreApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("usersettings.txt", optional:false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        private SqliteConnection cacheConnection = null;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            cacheConnection = new SqliteConnection("Data Source=:memory:");
            cacheConnection.Open();

            services.AddDbContext<CacheDbContext>(options =>
                options.UseSqlite(cacheConnection));

            services.AddTransient<ICacheRepository, CacheRepository>();

            // Add the localization services to the services container
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // Add framework services.
            services.AddMvc()
                // Add support for finding localized views, based on file name suffix, e.g. Index.fr.cshtml
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                // Add support for localizing strings in data annotations (e.g. validation messages) via the
                // IStringLocalizer abstractions.
                .AddDataAnnotationsLocalization();

            services.Configure<UserSettingsOptions>(Configuration);
            services.Configure<TitleOptions>(Configuration.GetSection("View:Title"));

            // Configure supported cultures and localization options
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("ru")
                };

                // State what the default culture for your application is. This will be used if no specific culture
                // can be determined for a given request.
                options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");

                // You must explicitly state which cultures your application supports.
                // These are the cultures the app supports for formatting numbers, dates, etc.
                options.SupportedCultures = supportedCultures;

                // These are the cultures the app supports for UI strings, i.e. we have localized resources for.
                options.SupportedUICultures = supportedCultures;

                // You can change which providers are configured to determine the culture for requests, or even add a custom
                // provider with your own logic. The providers will be asked in order to provide a culture for each request,
                // and the first to provide a non-null result that is in the configured supported cultures list will be used.
                // By default, the following built-in providers are configured:
                // - QueryStringRequestCultureProvider, sets culture via "culture" and "ui-culture" query string values, useful for testing
                // - CookieRequestCultureProvider, sets culture via "ASPNET_CULTURE" cookie
                // - AcceptLanguageHeaderRequestCultureProvider, sets culture via the "Accept-Language" request header
                //options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
                //{
                //  // My custom request culture logic
                //  return new ProviderCultureResult("en");
                //}));
            });

            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.CookieHttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, CacheDbContext cacheDbContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();
            //When using cookie - based session state, ASP.NET does not allocate storage for session data until the Session object
            //is used.As a result, a new session ID is generated for each page request until the session object is accessed.
            app.Use((httpContext, nextMiddleware) =>
            {
                httpContext.Session.SetInt32("InitSessionId", 1);

                /*using (CacheDbContext ctx = new CacheDbContext(new DbContextOptionsBuilder<CacheDbContext>()
                        .UseSqlite(cacheConnection).Options))
                {
                    ctx.SeedForSession(httpContext.Session.Id);
                }*/

                return nextMiddleware();
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            cacheDbContext.Database.EnsureCreated();
        }
    }
}
