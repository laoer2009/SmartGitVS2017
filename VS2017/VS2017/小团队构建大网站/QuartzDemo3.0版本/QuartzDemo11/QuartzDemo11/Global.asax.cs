using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Quartz;
using Quartz.Impl;
using Quartz.Xml;
using Quartz.Simpl;
using System.Threading.Tasks;

namespace QuartzDemo11
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RunpProgramRunExample().GetAwaiter().GetResult();
        }

        //IScheduler scheduler;
        private static async Task RunpProgramRunExample()
        {
            try
            {

                //通过工厂获取一个调度器的实例
                XMLSchedulingDataProcessor processor = new XMLSchedulingDataProcessor(new SimpleTypeLoadHelper());
                StdSchedulerFactory factory = new StdSchedulerFactory();
                IScheduler scheduler = await factory.GetScheduler();
                await processor.ProcessFileAndScheduleJobs("~/quartz_jobs.xml", scheduler);
                // and start it off
                await scheduler.Start();


                // some sleep to show what's happening
                //await Task.Delay(TimeSpan.FromSeconds(60));

                // and last shut down the scheduler when you are ready to close your program
                await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {

                await Console.Error.WriteLineAsync(se.ToString());
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}