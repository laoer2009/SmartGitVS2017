using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contract0427
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface ICalculator
    {
        [OperationContract]
        void Mutiple(double a, double b);
        [OperationContract]
        void SendByte(byte[] bytes);

        [OperationContract]
        int Connect(string uid);
        [OperationContract]
        int Heart();
    }
}
