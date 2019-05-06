using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.IO;
using System.Threading.Tasks;

namespace QuartzDemo11
{
    public class QuartzJobTime:IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            using (StreamWriter sw = new StreamWriter(@"F:\YYYest.txt", true, System.Text.Encoding.UTF8))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine("");
                sw.Close();
            }
            await Task.Delay(1);
        }
    }
}