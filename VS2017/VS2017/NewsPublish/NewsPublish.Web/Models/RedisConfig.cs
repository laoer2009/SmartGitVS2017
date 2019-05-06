using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPublish.Web.Models
{
    public class RedisConfig
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        public string RedisConnectionString
        {
            get;set;
        }
        /// <summary>
        /// 默认的key值（用来当作RedisKey的前缀）【此部分为自行修改的，无意义】
        /// </summary>
        public  string RedisDefaultKey { get;  set; }
    }
}
