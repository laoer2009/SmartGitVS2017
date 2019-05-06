using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SessionContract
{
    //https://www.cnblogs.com/zhili/p/WCFInstanceManager.html
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]//// 显示指定PerSingle方式
   public class CalculatorService:ICalculator,IDisposable
    {
       private int _nCount = 0;
       public CalculatorService()
       {
           Console.WriteLine("CalulatorService object has been created");
       }
        public void InCrease()
        {
            // 输出Session ID 
            Console.WriteLine("The Add method is invoked and the current session ID is: {0}",OperationContext.Current.SessionId);
            _nCount++;
        }
        public int GetResult()
        {
            Console.WriteLine("The GetResult method is invoked and the current session ID is: {0}", OperationContext.Current.SessionId);
            return _nCount;
        }
        public void Dispose()
        {
           
            Console.WriteLine("CalulatorService object has been Disposed");
        }
    }
}
