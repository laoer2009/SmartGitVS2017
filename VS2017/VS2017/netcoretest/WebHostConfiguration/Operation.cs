using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebHostConfiguration
{
    public class Operation : IOperation
    {
        public string GetGuid()
        {
            return Guid.NewGuid().ToString();
        }


    }
}
