using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerTwo.Models
{
    //在ASP.NET Core中，我们可以通过实现ILogger, ILoggerProvider 2个接口来创建我们自己的日志提供器。
    /// <summary>
    /// 
    /// </summary>
    public class ColoredConsoleLogger:ILogger
    {
        private readonly string _name;
        private readonly ColoredConsoleLoggerConfiguration _config;
        public ColoredConsoleLogger(string name, ColoredConsoleLoggerConfiguration config)
        {
            _name = name;
            _config = config;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == _config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //日志级别不同则不输出日志
           if(!IsEnabled(logLevel))
            {
                return;
            }
            var color = Console.ForegroundColor;
            Console.ForegroundColor = _config.Color;
            Console.WriteLine($"{logLevel.ToString()} - {_name} - {formatter(state, exception)}");
            Console.ForegroundColor = color;
        }
    }
}
