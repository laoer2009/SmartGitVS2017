using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Contract0427;
namespace WCFHost
{
   public class ServiceModule:Autofac.Module
    {
       protected override void Load(ContainerBuilder builder)
       {
           //builder.RegisterType<BaseRepository>().As<IBaseRepository>();
           builder.RegisterType<CalculatorService>().As<ICalculator>().AsSelf().SingleInstance();
           base.Load(builder);
       }
    }
}
