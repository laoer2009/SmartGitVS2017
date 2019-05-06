using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using SessionContract;

namespace SessionHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
               
                host.Opened += delegate
                {
                     Console.WriteLine("The Calculator Service has been started, begun to listen request..."); 
                 };
 ServiceThrottlingBehavior sb = new   ServiceThrottlingBehavior();
                  //获取或设置一个值，该值指定服务中可以一次执行的最多 System.ServiceModel.InstanceContext 对象数。
                // 服务中一次可执行的最大 System.ServiceModel.InstanceContext 对象数。 默认为 System.ServiceModel.Description.ServiceThrottlingBehavior.MaxConcurrentSessions(默认为处理器的4倍，400)
              //     的值和 System.ServiceModel.Description.ServiceThrottlingBehavior.MaxConcurrentCalls（64）
             //     值的总和。
           //sb.MaxConcurrentInstances  464
         
                 host.Open();
                 Console.ReadLine();
             }
        }
    }
}
