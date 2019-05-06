using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
namespace SessionContract
{
    [ServiceContract]
  public  interface ICalculator
  {
        [OperationContract]
        double Add(double x, double y);
        [OperationContract]
        void Release();
    }
}
