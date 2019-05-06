using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLog使用
{
    public static class NLogHelper
    {
        //https://blog.csdn.net/ChaITSimpleLove/article/details/79392887
        public static Logger nlog = LogManager.GetCurrentClassLogger();
    }
}
