using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace iMvc
{
    public class Startup
    {
        public IConfiguration _configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<StudentClass>(_configuration);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IHostingEnvironment env,IApplicationBuilder app, IApplicationLifetime lifetime)
        {
            // app.Use(async (context, next) =>
            // {
            //     await context.Response.WriteAsync("fisrt……");
            //     await next.Invoke();
            // });

            // app.Use(
            //         next=> {
            //                 return (context) =>
            //                 {
            //                     context.Response.WriteAsync("second……");
            //                     return next.Invoke(context);
            //                 };
            //             }
            //         );

            app.Run(async (context) =>
            {
                // await context.Response.WriteAsync("third……");
                
                //await context.Response.WriteAsync($"ContentRootPath={env.ContentRootPath}");
                //await context.Response.WriteAsync($"EnvironmentName={env.EnvironmentName}");
                //await context.Response.WriteAsync($"WebRootPath={env.WebRootPath}");


                //绑定配置文件和实体类的映射
                //StudentClass c = new StudentClass();
                //_configuration.Bind(c);

                ////打印配置信息
                //await context.Response.WriteAsync($"name:{c.Name}");
                //await context.Response.WriteAsync($"age:{c.Age}");
                //await context.Response.WriteAsync($"student count:{c.Students.Count}");

                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
