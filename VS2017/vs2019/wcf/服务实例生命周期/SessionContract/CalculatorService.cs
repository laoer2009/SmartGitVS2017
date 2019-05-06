using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SessionContract
{
    //https://www.cnblogs.com/zhili/p/WCFInstanceManager.html
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]//// 显示指定PerSingle方式
   public class CalculatorService : ICalculator, IDisposable
    {
        public CalculatorService()
         {
             Console.WriteLine("Service object is instantiated.");
         }
         ~CalculatorService()
         {
             Console.WriteLine("Service object is finalized.");
         }
  
         public void Dispose()
         {
            //OperationContext
            Console.WriteLine("Time: {0}; Thread ID: {1}; Service object is disposed.", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
                 Thread.Sleep(5000);
        }
         public double Add(double x, double y)
         {
            Console.WriteLine("Time: {0}; Thread ID: {1}; Operation method is invoked.", DateTime.Now, Thread.CurrentThread.ManagedThreadId);
            return x + y;
    
         }

        public void Release()
        {
            OperationContext.Current.InstanceContext.ReleaseServiceInstance();
        }
    }
}
