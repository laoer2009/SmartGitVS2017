using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRLoggerSample
{
    public class SignalRLogger : ILogger
    {
        HubConnection _connection;

        public SignalRLogger()
        {
            //这里使用HubConnectionBuilder创建了一个SignalR连接
            _connection = new HubConnectionBuilder().WithUrl("http://localhost:5000/LogHub").Build();
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            _connection.StartAsync().Wait();
            //连接启动成功之后，我们使用connection.SendAsync方法，将当前产生的日志信息发送到SignalR服务器
            var task = _connection.SendAsync("writeLog", new { Level = logLevel, Content = formatter(state, exception) });
            task.Wait();
        }
    }
}
