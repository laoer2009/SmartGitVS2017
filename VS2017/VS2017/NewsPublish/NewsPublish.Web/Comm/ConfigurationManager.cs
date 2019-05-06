using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPublish.Web.Comm
{
    /// <summary>
    /// .net core 项目类库读配置文件
    /// </summary>
    public class ConfigurationManager
    {
        static IConfiguration Configuration;
        static ConfigurationManager()
        {
            var baseDir = Directory.GetCurrentDirectory();//AppContext.BaseDirectory;
            Configuration = new ConfigurationBuilder()
                .SetBasePath(baseDir)
                .Add(new JsonConfigurationSource { Path = "appsettings.json", Optional = false, ReloadOnChange = true })
                .Build();
        }
        public static T GetAppSettings<T>(string key) where T:class,new()
        {
            var appConfig = new ServiceCollection()
                .AddOptions()
                .Configure<T>(Configuration.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appConfig;
        }
    }
}
