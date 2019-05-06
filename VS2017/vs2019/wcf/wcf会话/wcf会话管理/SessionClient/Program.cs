using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SessionContract;
namespace SessionClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // Use ChannelFactory<ICalculator> to create WCF Service proxy 
            ChannelFactory<ICalculator> calculatorChannelFactory = new ChannelFactory<ICalculator>("HttpEndPoint");
            for (int i = 0; i < 30000; i++)
            {
                
           
            Console.WriteLine("Create a calculator proxy :proxy1");
            ICalculator proxy1 = calculatorChannelFactory.CreateChannel();
            Console.WriteLine("Invoke proxy1.Increate() method");
            proxy1.InCrease();
            Console.WriteLine("Invoke proxy1.Increate() method again");
            proxy1.InCrease();
            Console.WriteLine("The result return via proxy1.GetResult() is: {0}", proxy1.GetResult());
                //(proxy1 as IDisposable).Dispose();//信道（basic绑定除外）默认情况下创建的都是会话信道，如果不调用关闭，则最多只能执行处理器数的100倍 即400次，通过配置文件可以更信道的模式  <security mode="None"></security> 设置后可以不用关闭信道,服务端和客户端都要更改
                (proxy1 as ICommunicationObject).Close();
                Console.WriteLine("调用次数  "+DateTime.Now.ToString()+"    "+i.ToString());
            }
          // (proxy1 as IDisposable).Dispose();//服务端会调用 Dispose方法
            //(proxy1 as ICommunicationObject).Close();// 显示关闭Proxy
            //try
            //{
            //    proxy1.InCrease();
            //}
            //catch (Exception ex)
            //{
            //        //无法访问已释放的对象
            //    throw;
            //}
        
            // Console.WriteLine("Create another calculator proxy: proxy2");
            //ICalculator proxy2 = calculatorChannelFactory.CreateChannel();
            //Console.WriteLine("Invoke proxy2.Increate() method");
            //proxy2.InCrease();
            //Console.WriteLine("Invoke proxy2.Increate() method again");
            //proxy2.InCrease();
            //Console.WriteLine("The result return via proxy2.GetResult() is: {0}", proxy2.GetResult());


            Console.ReadLine();
        }
    }
}
