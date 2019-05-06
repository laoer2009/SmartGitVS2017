using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz配置
{
    public class QuartzJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            using (StreamWriter sw = new StreamWriter(@"F:\quartz.txt", true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("");
                sw.Close();
            }
            await Task.CompletedTask;
        }
    }
}
