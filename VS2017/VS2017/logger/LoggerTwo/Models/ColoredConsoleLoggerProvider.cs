using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions;
using Microsoft.Extensions.Logging;

namespace LoggerTwo.Models
{
    /// <summary>
    /// Logger提供器类
    /// </summary>
    public class ColoredConsoleLoggerProvider: ILoggerProvider
    {
        private readonly ColoredConsoleLoggerConfiguration _config;

        public ColoredConsoleLoggerProvider(ColoredConsoleLoggerConfiguration config)
        {
            _config = config;
        }
        public ILogger CreateLogger(string categoryName)
        {
            return new ColoredConsoleLogger(categoryName, _config);
        }
        public void Dispose()
        {

        }
    }
}
