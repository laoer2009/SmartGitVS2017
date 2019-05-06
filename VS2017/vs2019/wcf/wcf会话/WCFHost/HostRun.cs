using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using Contract0427;
namespace WCFHost
{
   public class HostRun
   {
       CalculatorService _calculatorService;
       CalculatorServiceHost _calculatorServiceHost;
       public HostRun(CalculatorService calculatorService)
       {
           _calculatorService = calculatorService;
       }

       public void Run()
       {
           try
           {
               _calculatorServiceHost = new CalculatorServiceHost(_calculatorService, "localhost:9003");
                //ServiceThrottlingBehavior sb = new ServiceThrottlingBehavior();
                //sb.MaxConcurrentCalls = 10000000;
                //sb.MaxConcurrentInstances = 10000000;
                //sb.MaxConcurrentSessions = 10000000;
                //_calculatorServiceHost.Description.Behaviors.Add(sb);
                _calculatorServiceHost.Opened += _calculatorServiceHost_Opened;
               _calculatorServiceHost.Open();
           }
           catch (Exception ex)
           {
               //要使用采用服务实例的其中一个 ServiceHost 构造函数，服务的 InstanceContextMode 必须设置为 InstanceContextMode.Single。可以通过 ServiceBehaviorAttribute 进行此配置。否则，请考虑使用采用 Type 参数的 ServiceHost 构造函数。
           }
       }

       void _calculatorServiceHost_Opened(object sender, EventArgs e)
       {
          Console.WriteLine("服务开启");
       }


    }
}
