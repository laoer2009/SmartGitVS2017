using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract0427
{
    //  // 回调契约的定义，此时回调契约不需要应用ServiceContractAttribute特性
   public interface ICallback
    {
       [OperationContract(IsOneWay = true)]
       void DisplayResult(double x, double y, double result);
    }
}
