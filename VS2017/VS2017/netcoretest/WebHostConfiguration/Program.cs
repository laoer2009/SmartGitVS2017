using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using AutoMapper;
namespace WebHostConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x => x.CreateMap<UserInfo, UserInfo_DTO>());
        
            //Entity Model
            UserInfo user = new UserInfo();
            user.Name = "xiaoqiu";
            user.Age = 21;
            user.Address = "湖北襄阳";
            user.Birth = new DateTime(1995, 8, 18);

            UserInfo_DTO userdto = new UserInfo_DTO();
            //DTO: Data Transfer Object
          var t =  Mapper.Map(user, typeof(UserInfo), typeof(UserInfo_DTO));
       
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(config => {
                config.AddJsonFile("json.json"); //从json.json中读取配置文件
                config.AddCommandLine(args); //从命令行中读取配置文件
            }).UseUrls("http://localhost:8093")
            .UseStartup<Startup>()
                .Build();
    }
}
