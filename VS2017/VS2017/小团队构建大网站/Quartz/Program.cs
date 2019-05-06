using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz
{
    class Program
    {
        //https://www.cnblogs.com/mingmingruyuedlut/p/8037263.html
        static void Main(string[] args)
        {
            TestAsyncJob();
            Console.ReadKey();
        }

        static async Task TestAsyncJob()
        {
            var props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            StdSchedulerFactory schedFact = new StdSchedulerFactory(props);

            IScheduler sched = await schedFact.GetScheduler();
            await sched.Start();

            IJobDetail job = JobBuilder.Create<EricSimpleJob>()
                   .WithIdentity("EricJob", "EricGroup")
                   .Build();

            IJobDetail anotherjob = JobBuilder.Create<EricAnotherSimpleJob>()
                .WithIdentity("EricAnotherJob", "EricGroup")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
               .WithIdentity("EricTrigger", "EricGroup")
               .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
               .Build();

            ITrigger anothertrigger = TriggerBuilder.Create()
                .WithIdentity("EricAnotherTrigger", "EricGroup")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(5).RepeatForever())
                .Build();

            await sched.ScheduleJob(job, trigger);
            await sched.ScheduleJob(anotherjob, anothertrigger);
        }
    }
}
