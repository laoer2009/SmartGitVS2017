using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerTwo.Models
{
    public class AppSetting2
    {
        public RedisCaching RedisCaching { get; set; }
    }
    public class RedisCaching
    {
        public bool Enabled { get; set; }
        public string Conn { get; set; }
    }
}
