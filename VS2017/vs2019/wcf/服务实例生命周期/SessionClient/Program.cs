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
            using (ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("HttpEndPoint"))
            {
               // ChannelFactory<ICalculator> channelFactory = new ChannelFactory<ICalculator>("HttpEndPoint");
                ICalculator calculator = channelFactory.CreateChannel();
                using (calculator as IDisposable)
                {
                   
                    calculator.Add(1, 2);
                    calculator.Add(3, 4);
                    calculator.Release();
                }
                
               
                //Console.WriteLine("x + y = {2} when x = {0} and y = {1}", 1, 2, calculator.Add(1, 2));
                //Console.WriteLine("x + y = {2} when x = {0} and y = {1}: {3}", 1, 2, calculator.Add(1, 2));
            }

            Console.ReadLine();
        }
    }
}
