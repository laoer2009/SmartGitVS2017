using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using NewsPublish.Service;
using System.IO;
using NewsPublish.Web.Models;
using NewsPublish.Web.Comm;
namespace NewsPublish.Web
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
            string redisConnectiong = Configuration.GetConnectionString("Redis");
            services.AddSession();
            services.AddDistributedRedisCache(options => options.Configuration = redisConnectiong);
            services.AddMvc();
           
            services.AddTransient<BannerService>();
            services.AddTransient<CommentService>();
            services.AddTransient<Db>();
            services.AddTransient<NewsService>();
          

            //20190411
            
            //20190105
            //在出于安全问题默认情况下是不允许浏览目录的文件和文件夹的，但是如果你需要浏览的话可以用以下方法。
            services.AddDirectoryBrowser();

            //　然后在startup.cs文件的Configure方法中写入：

            //20190106
            IFileProvider physicalProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());
            services.AddSingleton(physicalProvider);

            //读取配置文件  http://www.bubuko.com/infodetail-2321217.html
            //https://blog.csdn.net/syrs1987/article/details/81482306
             EnvironmentInfo.ConnectionString = Configuration["RedisConfig:RedisConnectionString"];
             EnvironmentInfo.DefaultKey = Configuration["RedisConfig:DefaultKey"];

            EnvironmentInfo.ConnectionString = ConfigurationManager.GetAppSettings<ConnectionStrings>("ConnectionStrings").Redis;

            //Configuration.GetSection("RedisConfig:RedisConnectionString").Value
            services.AddOptions();
            services.Configure<RedisConfig>(Configuration.GetSection("RedisConfig"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
         
         
            //20190106:
            //内置状态码中间件
            app.UseStatusCodePages("text/html", "<h2>statuscode:{0}</h2>");
         
            //20190105
            //https://www.cnblogs.com/CreateMyself/p/9235968.html
            //如何将静态文件注入到项目中　
            app.UseStaticFiles();
            //app.UseDefaultFiles();
            //如何使用自己的文件路径
            //这时候我们知道FileProvider是指定路径，RequestPath是将对外的路径重写。
            //即可用 StaticFiles来访问而不是MyStaticFiles。
            //我觉得这样地址重写的好处是可以保证项目的结构不被暴露，有一定的安全性吧。

            app.UseStaticFiles(new StaticFileOptions() {
             FileProvider= new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),@"MyStaticFiles")),
              RequestPath = new PathString("/StaticFiles"),
                OnPrepareResponse = ctx => {
                    
                    const int cacheExpire = 6000;
                    //Cache-Control指定了请求和响应遵循的缓存机制。好的缓存机制可以减少对网络带宽的占用，可以提高访问速度，提高用户的体验，还可以减轻服务器的负担
                    // ctx.Context.Response.Headers.Add("CacheControl", "public,max-age="+cacheExpire);
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + cacheExpire;
                }
            });

            //在出于安全问题默认情况下是不允许浏览目录的文件和文件夹的，但是如果你需要浏览的话可以用以下方法 
            // 首先要在startup.cs文件的ConfigureServices方法中加入：
            //services.AddDirectoryBrowser();
            //然后在startup.cs文件的Configure方法中写入：
            app.UseDirectoryBrowser(new DirectoryBrowserOptions() {
                FileProvider = new PhysicalFileProvider(
                      Path.Combine(Directory.GetCurrentDirectory() + @"\wwwroot\images")),
                 RequestPath = new PathString("/wwwroot/images")
            });
            //浏览文件
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images")),
                RequestPath = new PathString("/wwwroot/images")
            });

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "OutStaticFiles")),
                RequestPath = "/outfiles",
                OnPrepareResponse = ctx => {

                    const int cacheExpire = 60;
                    //Cache-Control指定了请求和响应遵循的缓存机制。好的缓存机制可以减少对网络带宽的占用，可以提高访问速度，提高用户的体验，还可以减轻服务器的负担
                    // ctx.Context.Response.Headers.Add("CacheControl", "public,max-age="+cacheExpire);
                    ctx.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=" + cacheExpire;
                }
            });

            // 20190106
            //自定义默认文件目录
            var fileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "OutDefaultHtml"));
            app.UseDefaultFiles(new DefaultFilesOptions() {
                FileProvider = fileProvider,
                DefaultFileNames=new[] { "OutDefault.html" }
            });
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = fileProvider
            });

           // app.UseMiddleware<NewsPublish.Web.MiddleWares.RecordRequestMiddleWare>();
            app.UseStatusCodePagesWithReExecute("/home/StatusCodePagesWithReExcute", "?code={0}");
            app.UseMvc(routes =>
            {
                //routes.MapRoute(
                //  name: "areaRoute",
                //  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
              
            });
        }
    }
}
