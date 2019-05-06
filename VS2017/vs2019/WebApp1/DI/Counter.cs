using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.DI
{
    public class Counter : ICounter
    {
        public int Get()
        {
            return 2;
        }
    }
}
