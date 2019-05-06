using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz配置
{
    [DisallowConcurrentExecution]
   public class QuartzJobTime:IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("QuartzJobTime"+DateTime.Now.ToString());
            System.Threading.Thread.Sleep(10000);
            await Task.CompletedTask;
        }
    }
}
