using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerTwo.Models
{
    public class AppSettingModel
    {
        public string WeixinTokken { get; set; }
        public string WeixinEncodingAESKey { get; set; }
        public string WeixinAppid { get; set; }
        public string WeixinAppSecret { get; set; }
    }
}
