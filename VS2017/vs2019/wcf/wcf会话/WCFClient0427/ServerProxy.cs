using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract0427;
using System.IO;
namespace WCFClient0427
{
   public class ServerProxy:BaseWork
   {
       ICalculator _proxy = null;
       DuplexChannelFactory<ICalculator> channelFactory = null;
        private static readonly object _obj = new    object();
       public ServerProxy()
       {
           InstanceContext contextCallBack = new InstanceContext(new CallbackWCFService());
           channelFactory = new DuplexChannelFactory<ICalculator>(contextCallBack, "NetTcpBinding_ICalculator");

       }

       public int Connect()
       {
            if (_proxy != null)
            {
                try
                {
                    (_proxy as ICommunicationObject).Close();
                }
                catch
                {
                    (_proxy as ICommunicationObject).Abort();
                }
            }
            lock (_obj)
            {
                _proxy = channelFactory.CreateChannel();

                var state = (_proxy as ICommunicationObject).State;
                // return _proxy.Connect("aaaaaaaaaaaaaaaaaaaaaaaa");
                //return InvokeNotRelease<ICalculator,int>(_proxy, (p) =>
                //{
                //    return p.Connect("pp");
                //});
                byte[] b = new byte[1024 * 1024 * 2];
                FileStream fs = new FileStream(@"D:\1.txt", FileMode.Open, FileAccess.Read);
              
                    fs.Read(b, 0, (int)fs.Length);
                fs.Close();
                _proxy.SendByte(b);
                return 0;
            }
       
      
       }

       public int Heart()
       {
           return _proxy.Heart();
       }
  
   }
}
