using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz
{
    public class EricAnotherSimpleJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            string path = @"F:\quartz.txt";
            if(!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine(DateTime.Now.ToString());
            }
            
            return Task.CompletedTask;
        }
    }
}
