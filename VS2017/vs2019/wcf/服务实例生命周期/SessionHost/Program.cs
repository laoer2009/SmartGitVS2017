using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
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
 
                 host.Open();
                 Console.ReadLine();
             }
        }
    }
}
