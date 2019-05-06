using System;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace ConsoleLogger
{
    class Program
    {
        //https://www.cnblogs.com/linezero/p/log4net.html
        static void Main(string[] args)
        {
            ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
            // 默认简单配置，输出至控制台
            //BasicConfigurator.Configure(repository);
            XmlConfigurator.Configure(repository, new System.IO.FileInfo("log4net.config"));
            ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net_laoer");
            log.Info("NETCorelog4net log");
            log.Info("test log");
            log.Error("error");
            log.Info("linezero");
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
