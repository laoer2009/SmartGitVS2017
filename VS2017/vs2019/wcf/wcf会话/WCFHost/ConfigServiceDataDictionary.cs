using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace WCFHost
{
   public static class ConfigServiceDataDictionary
    {
          public static Binding Binding
        {
            get
            {
                var tmp = new NetTcpBinding(SecurityMode.None);
                tmp.Security.Mode = SecurityMode.None;

                tmp.MaxReceivedMessageSize = 2147483647;
                tmp.TransferMode = TransferMode.Buffered;
                tmp.ReceiveTimeout = TimeSpan.FromMinutes(2);

     

         
                return tmp;
            }
        }

        public static string FullAddress(string address)
        {
            //net.tcp://localhost:9003/CalculatorService
            return string.Format("net.tcp://{0}/CalculatorService", address);

        }
    }
}
