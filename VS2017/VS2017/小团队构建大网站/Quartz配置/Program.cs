using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
using Quartz.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz配置
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //通过工厂获取一个调度器的实例
            XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(new SimpleTypeLoadHelper());
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = await factory.GetScheduler();
            await processor.ProcessFileAndScheduleJobs("~/quartz_jobs.xml", scheduler);
            // and start it off
            await scheduler.Start();

            Console.ReadKey();

        }
    }
}
