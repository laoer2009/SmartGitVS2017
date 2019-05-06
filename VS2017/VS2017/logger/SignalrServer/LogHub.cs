using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace SignalrServer
{
    //https://www.cnblogs.com/lwqlun/p/9683482.html
    //自定义一个与SignalR集成的日志提供器，我们希望产生的日志通过一个SignalR服务器推送到一个网页中。
    public class LogHub:Hub
    {
        /// <summary>
        /// 这里我们创建了一个写日志的方法，它会把日志推送到所有连接到SignalR服务器的客户端，
        /// 并调用客户端的showLog方法来展示推送的日志信息
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        public async Task WriteLog(Log log)
        {
            await Clients.All.SendAsync("showLog", log);
        }
    }
    public class Log
    {
        public LogLevel Level { get; set; }

        public string Content { get; set; }
    }
}
