using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Contract0427;
namespace WCFHost
{
    //http://www.cnblogs.com/zhili/p/WCFCallbackOperacation.html
    class Program
    {
        static void Main(string[] args)
        {
            //using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            //{
            //    host.Opened += delegate
            //    {
            //        Console.WriteLine("Service start now....");
            //    };

            //    host.Open();
            //    Console.Read();
            //}

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new ServiceModule());
            var builder = containerBuilder.Build();
            var calculatorService = builder.Resolve<CalculatorService>();
            HostRun hostRun = new HostRun(calculatorService);

            hostRun.Run();

            Console.ReadKey();

        }
    }
}
