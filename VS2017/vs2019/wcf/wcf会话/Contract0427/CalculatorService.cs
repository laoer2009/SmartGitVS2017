using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract0427
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,ConcurrencyMode = ConcurrencyMode.Multiple)]
   public class CalculatorService:ICalculator
    {
        public void Mutiple(double a, double b)
        {
           //System.Threading.Thread.Sleep(5000);
            double result = a*b;
            ICallback callback = OperationContext.Current.GetCallbackChannel<ICallback>();
            // 通过客户端实例通道

            // 对客户端操作进行回调
              callback.DisplayResult(a, b, result);
        }


        public void SendByte(byte[] bytes)
        {
           Console.WriteLine("byte complted");
        }

        public int Connect(string uid)
        {
            return 0;
        }

        public int Heart()
        {
            return 0;
        }
    }
}
