using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPublish.Web.Models
{
    [Serializable]
    public class ChartModels
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 对话内容
        /// </summary>
        public string Chat { get; set; }
    }
}
