using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Contract0427;
namespace WCFHost
{
   public class CalculatorServiceHost:ServiceHost
   {
       string _address;

       public CalculatorServiceHost(CalculatorService service, string addresss) : base(service)
       {
           _address = addresss;
           ConfigService();
       }

       private void ConfigService()
       {
           base.AddServiceEndpoint(typeof (ICalculator), ConfigServiceDataDictionary.Binding,
               ConfigServiceDataDictionary.FullAddress(_address));
       }
   }
}
