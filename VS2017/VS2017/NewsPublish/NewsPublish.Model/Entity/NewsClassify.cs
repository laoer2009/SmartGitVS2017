using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPublish.Model.Entity
{
    /// <summary>
    /// 新闻类别
    /// </summary>
    public class NewsClassify
    {
        public NewsClassify()
        {
            this.News = new HashSet<News>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<News> News { get; set; }
    }
}
