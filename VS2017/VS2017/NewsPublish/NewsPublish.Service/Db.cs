using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer;
using NewsPublish.Model.Entity;
namespace NewsPublish.Service
{
    /// <summary>
    /// 数据库访问上下文
    /// </summary>
   public class Db:DbContext
    {
        public Db() { }
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=.;initial catalog =NewsPublish;uid = sa;pwd = 123;", it => it.UseRowNumberForPaging());

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Model.Entity.Banner> Banner { get; set; }
        public virtual DbSet<NewsClassify> NewsClassify { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsComment> NewsComment { get; set; }
    }
}
