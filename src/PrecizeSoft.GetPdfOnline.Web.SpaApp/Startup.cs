using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PrecizeSoft.GetPdfOnline.Api.Soap.Host;
using Microsoft.Data.Sqlite;
using PrecizeSoft.GetPdfOnline.Data.SQLite;
using PrecizeSoft.GetPdfOnline.Web.SpaApp.Configuration;
using PrecizeSoft.GetPdfOnline.Data;
using PrecizeSoft.IO.Contracts.Converters;
using PrecizeSoft.GetPdfOnline.Domain.Services;
using PrecizeSoft.GetPdfOnline.Data.SQLite.Repositories;
using PrecizeSoft.GetPdfOnline.Domain.Configuration;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using PrecizeSoft.GetPdfOnline.Web.SpaApp.Swagger;

namespace PrecizeSoft.GetPdfOnline.Web.SpaApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFile("usersettings.txt", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        private SqliteConnection cacheConnection = null;

        SoapApiHost soapApiHost = null;

        protected void CreateAndOpenHosts(int port, bool useLibreOfficeCustomPath, string libreOfficeCustomPath,
            string connectionString)
        {
            this.soapApiHost = new SoapApiHost();
            this.soapApiHost.Configure(false, port, "/soap", useLibreOfficeCustomPath, libreOfficeCustomPath, connectionString);
            this.soapApiHost.Open();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            cacheConnection = new SqliteConnection("Data Source=:memory:");
            // cacheConnection = new SqliteConnection("Data Source=cache.db");
            cacheConnection.Open();

            services.AddDbContext<CacheDbContext>(options =>
                options.UseSqlite("Data Source=cache.db"));
                //options.UseSqlite(cacheConnection));

            services.AddDbContext<GetPdfOnlineDbContext>(options =>
                options.UseSqlite(this.Configuration.Get<UserSettingsOptions>().Data.ConnectionString));

            services.AddTransient<ICacheRepository, CacheRepository>();
            services.AddTransient<IConvertLogRepository, ConvertLogRepository>();
            services.AddTransient<IFileService, FileStorageService>(p =>
            {
                return new FileStorageService(p.GetRequiredService<ICacheRepository>());
            });
            services.AddTransient<IJobService, JobService>(p =>
            {
                return new JobService(p.GetRequiredService<ICacheRepository>());
            });
            services.AddTransient<ILogService, LoggerService>(p =>
            {
                return new LoggerService(p.GetRequiredService<IConvertLogRepository>());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });
            
            // Add framework services.
            services.AddMvc();

            services.Configure<UserSettingsOptions>(Configuration);
            services.Configure<TitleOptions>(Configuration.GetSection("View:Title"));
            services.Configure<LibreOfficeOptions>(Configuration.GetSection("LibreOffice"));
            services.Configure<StoreOptions>(Configuration.GetSection("View:Cache"));

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Rest API",
                    Version = "v1",
                    Contact = new Contact { Name = "Mikhail Andreev", Url = "http://andreev.work", Email = "m@andreev.work" }
                });

                //Set the comments path for the swagger json and ui.
                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                c.IncludeXmlComments(Path.Combine(basePath, "PrecizeSoft.IO.WebApi.xml"));
                c.IncludeXmlComments(Path.Combine(basePath, "PrecizeSoft.GetPdfOnline.Web.SpaApp.xml"));

                c.OrderActionsBy(apiDescription =>
                {
                    return $"{apiDescription.GroupName}!{apiDescription.RelativePath}!{apiDescription.HttpMethod}!";
                });

                c.OperationFilter<FormFileOperationFilter>();
                c.OperationFilter<UpdateFileResponseTypeFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory,
            IApplicationLifetime life, CacheDbContext cacheDbContext, GetPdfOnlineDbContext getPdfOnlineDbContext)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });

            cacheDbContext.Database.EnsureCreated();
            getPdfOnlineDbContext.Database.Migrate();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/{documentName}/swagger.json";
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            /*app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/v1/swagger.json", "GetPDF.online REST API v1");
                c.RoutePrefix = "swagger";
            });*/

            life.ApplicationStarted.Register(() =>
            {
                var options = this.Configuration.Get<UserSettingsOptions>();
                this.CreateAndOpenHosts(/*44735*/options.Host.TcpPort, options.LibreOffice.UseCustomUnoPath, options.LibreOffice.CustomUnoPath, options.Data.ConnectionString);
            });
        }
    }
}
