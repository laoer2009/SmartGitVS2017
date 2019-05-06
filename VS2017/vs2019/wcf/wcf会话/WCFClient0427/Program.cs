using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using Contract0427;
using System.Timers;

namespace WCFClient0427
{
    class Program
    {
       static Timer _heartTimer;
        static void Main(string[] args)
        {

            ServerProxy proxy = new  ServerProxy();
            _heartTimer = new Timer();
            _heartTimer.Interval = TimeSpan.FromSeconds(2).TotalMilliseconds;
            
            _heartTimer.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                    try
                    {
                        if (proxy.Connect()==0)
                        {
                        Console.WriteLine(DateTime.Now.ToString());
                            proxy.Heart();
                        }
                        else
                        {
                          
                        }
                    }
                    catch (Exception ex)
                    {
                       
                    }

                (sender as Timer).Start();
            };
            _heartTimer.Start();


            Console.ReadKey();

           // InstanceContext contextCallBack = new InstanceContext(new CallbackWCFService());
            //using (DuplexChannelFactory<ICalculator> channelFactory = new DuplexChannelFactory<ICalculator>(contextCallBack, "NetTcpBinding_ICalculator"))
            //{
            //    for (int i = 0; i < 20000; i++)
            //    {
            //        ICalculator calculatorChannel = channelFactory.CreateChannel();
            //        //using (calculatorChannel as IDisposable)
            //        {
            //            calculatorChannel.Mutiple(1, 2);
            //            string str = "aaaaaaaaaaaaaaa";

            //            byte[] bytes = Encoding.UTF8.GetBytes(str);
            //            calculatorChannel.SendByte(bytes);
            //            //(calculatorChannel as ICommunicationObject).Close();
            //        }
            //    }
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(delegate
            //    {
            //        using (DuplexChannelFactory<ICalculator> channelFactory =new DuplexChannelFactory<ICalculator>(contextCallBack, "NetTcpBinding_ICalculator"))
            //        {
            //             ICalculator calculator=  channelFactory.CreateChannel();
            //             calculator.Mutiple(1, 2);
            //        }
            //    });
            //}
            Console.ReadKey();
        }
    }
}
