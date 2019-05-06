using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using LoggerTwo.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LoggerTwo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddOptions();
            services.Configure<AppSettingModel>(Configuration.GetSection("AppSettings"));
            services.Configure<AppSetting2>(Configuration.GetSection("AppSetting2"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
          
          //  var q = Configuration.GetSection("Logging");
          //  Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
          //Encoding.GetEncoding("GB2312");

            //loggerFactory.AddConsole();
            //loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            loggerFactory.AddProvider(new ColoredConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Information,
                Color = ConsoleColor.Blue
            }));
            loggerFactory.AddProvider(new ColoredConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Debug,
                Color = ConsoleColor.Yellow
            }));
            loggerFactory.AddProvider(new ColoredConsoleLoggerProvider(new ColoredConsoleLoggerConfiguration()
            {
                 LogLevel = LogLevel.Warning,
                 Color = ConsoleColor.Red
            }));


            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
