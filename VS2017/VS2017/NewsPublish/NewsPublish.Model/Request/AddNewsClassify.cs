using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPublish.Model.Request
{
    /// <summary>
    /// 添加新闻类别
    /// </summary>
    public class AddNewsClassify
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        public string Remark { get; set; }
    }
}
