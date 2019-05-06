using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebHostConfiguration
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IOperation, Operation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IConfiguration configuration,IOperation operaion,ILoggerFactory loggerfactory)
        {
            string guid = operaion.GetGuid();

            loggerfactory.AddConsole(minLevel: LogLevel.Information);
            var logger = loggerfactory.CreateLogger("Middleware");
            
            //public delegate Task RequestDelegate(HttpContext context);
            app.Use(async (context, next) =>
            {
                logger.LogInformation("Handling request");
                await next.Invoke();
                logger.LogInformation("Finished handling request");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello from Middleware");
                //  await context.Response.WriteAsync($"connectionString=\"{configuration["connectionString:defaultConnectionString"]}\"");    //显示json文件中的配置文件
                // await context.Response.WriteAsync($"name={configuration["name"]}");
                //await context.Response.WriteAsync("Hello World!");

                //   await context.Response.WriteAsync($"ContentRootPath={env.ContentRootPath}");
                //  await context.Response.WriteAsync($"WebRootPath={env.WebRootPath}");
                // await context.Response.WriteAsync($"ApplicationName={env.ApplicationName}");
                // await context.Response.WriteAsync($"EnvironmentName = {env.EnvironmentName}");

            });
        }
    }
}
