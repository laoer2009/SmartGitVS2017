using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace netcoretest1
{
    class Program
    {
        // 视频地址 ：http://video.jessetalk.cn/course/4/task/11/show
        static void Main(string[] args)
        {
            //    var settting = new Dictionary<string, string>();
            //    settting.Add("name", "laoer");
            //    settting.Add("age", "29");
            //    var builder = new ConfigurationBuilder().
            //        AddInMemoryCollection(settting).
            //        AddCommandLine(args);
            //    var configuration = builder.Build();
            //    Console.WriteLine($"name:{configuration["name"]}");
            //    Console.WriteLine($"age:{configuration["age"]}");
            //    Console.ReadLine();

            //读取json配置文件
            //var buider = new ConfigurationBuilder();
            //buider.AddJsonFile("class.json");
            //var configuration = buider.Build();
            //Console.WriteLine($"ClassNo:{configuration["ClassNo"]}");
            //Console.WriteLine($"ClassDesc:{configuration["ClassDesc"]}");
            //Console.WriteLine("student……………………");
            //Console.WriteLine($"Students0:{configuration["Students:0:name"]}");
            //Console.WriteLine($"Students0:{configuration["Students:0:age"]}");

            //Console.WriteLine($"Students1:{configuration["Students:1:name"]}");
            //Console.WriteLine($"Students1:{configuration["Students:1:age"]}");

            //Console.WriteLine($"Students2:{configuration["Students:2:name"]}");
            //Console.WriteLine($"Students2:{configuration["Students:2:age"]}");
            #region 单例
            //负责注册
            //var services = new ServiceCollection();
            //services.AddSingleton<IOperationSingleton, Operation>();

            //services.AddSingleton<IOperationSingleton>(new Operation(Guid.Empty));
            //services.AddSingleton<IOperationSingleton>(new Operation(Guid.NewGuid()));

            ////负责提供实例

            //var provider = services.BuildServiceProvider();
            ////输出singleton1 的guid
            //var singleton1 = provider.GetService<IOperationSingleton>();
            //Console.WriteLine($"singleton1:{singleton1.OperationId}");

            //var singleton2 = provider.GetService<IOperationSingleton>();
            //Console.WriteLine($"singleton2:{singleton2.OperationId}");
            //Console.WriteLine($"singleton1==singleton2?:{singleton1 == singleton2}");
            #endregion

            #region 瞬态
            //var services = new ServiceCollection();
            //services.AddTransient<IOperationTransient, Operation>();
            //var provider = services.BuildServiceProvider();
            //var transient1 = provider.GetService<IOperationTransient>();

            //Console.WriteLine($"transient1:{transient1.OperationId}");

            //var transient2 = provider.GetService<IOperationTransient>();
            //Console.WriteLine($"transient2:{transient2.OperationId}");
            //Console.WriteLine($"transient1==transient2?:{transient1 == transient2}");

            #endregion

            #region scoped
       //     var services = new ServiceCollection();
       //     services.AddScoped<IOperationScope, Operation>()
       //      .AddTransient<IOperationTransient, Operation>()
       //      .AddSingleton<IOperationSingleton, Operation>();

       //     var provider = services.BuildServiceProvider();
       //     using (var scop1 = provider.CreateScope())
       //     {
       //         var p = scop1.ServiceProvider;
       //         var scopeobj1 = p.GetServices<IOperationScope>();
       //         var transient1 = p.GetService<IOperationTransient>();
       //         var singleton1 = p.GetService<IOperationSingleton>();
               

       //         var scopobj12= p.GetServices<IOperationScope>();
       //         var transient2 = p.GetService<IOperationTransient>();
       //         var singleton2 = p.GetService<IOperationSingleton>();


       //         Console.WriteLine(
       //$"scope1: { }," +
       //$"transient1: {transient1.OperationId}, " +
       //$"singleton1: {singleton1.OperationId}");

       //         Console.WriteLine($"scope2: { scopobj12 }, " +
       //             $"transient2: {transient2.OperationId}, " +
       //             $"singleton2: {singleton2.OperationId}");
       //     }
                #endregion



                Console.ReadLine();

          

           

        }
    }
}
