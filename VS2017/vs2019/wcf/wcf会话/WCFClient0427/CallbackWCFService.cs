using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contract0427;
namespace WCFClient0427
{
   public class CallbackWCFService:ICallback
    {
        public void DisplayResult(double x, double y, double result)
        {
            Console.WriteLine(DateTime.Now.ToString()+"  {0} * {1} = {2}  ", x, y, result);
        }
    }
}
