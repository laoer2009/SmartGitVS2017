using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient0427
{
   public class BaseWork
    {
        protected int InvokeNotRelease<ICO, T>(ICO proxy, Func<ICO, int> func)
        {
            if (proxy == null)
            {
                return 0;
            }

            try
            {
                var rst = func(proxy);

                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
