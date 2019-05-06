using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggerTwo.Models
{
    /// <summary>
    /// 不同日志级别的字体颜色配置类
    /// </summary>
    public class ColoredConsoleLoggerConfiguration
    {
        /// <summary>
        /// 自定义日志级别
        /// </summary>
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;
       /// <summary>
       /// 控制控制台字体输出背景颜色
       /// </summary>
        public ConsoleColor Color { get; set; } = ConsoleColor.Yellow;
    }
}
