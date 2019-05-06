using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz
{
    [DisallowConcurrentExecution]
    public class EricSimpleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello Eric, Job executed."+DateTime.Now.ToString());
            System.Threading.Thread.Sleep(10000);//DisallowConcurrentExecution 任务串行处理  间隔事件为5+10
            await Task.CompletedTask;
        }
    }
}
