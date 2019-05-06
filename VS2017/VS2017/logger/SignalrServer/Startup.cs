using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNet.SignalR;
namespace SignalrServer
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
            //这里我们启用了CORS, 因为需要提供跨域访问
            services.AddCors();
            services.AddMvc();
            //我们通过service.AddSignalR注册了SignalR服务
            services.AddSignalR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //env.IsDevelopment()就可以读出当前程序是否是处于开发环境当中，如果你在Visual Studio中运行ASP.NET Core项目那么上面的env.IsDevelopment()就会返回true，
            //如果你发布（publish）了ASP.NET Core项目，并在IIS中运行发布后的项目代码，那么上面的env.IsDevelopment()就会返回false
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            //我们通过app.UserSignalR方法注册一个logHub
            app.UseSignalR(routes =>
            {
                routes.MapHub<LogHub>(new Microsoft.AspNetCore.Http.PathString("/logHub"));
            });

            app.UseMvc();
        }
    }
}
