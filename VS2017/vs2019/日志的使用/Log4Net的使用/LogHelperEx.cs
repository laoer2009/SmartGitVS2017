using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using log4net.Repository;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using log4net.Config;

namespace Log4Net的使用
{
    /// <summary>
    /// https://www.cnblogs.com/recordman/p/10128163.html
    /// Log4Net Helper 2018-12-16 19:15:00  
    /// 日志等级：OFF > FATAL > ERROR > WARN > INFO > DEBUG > ALL
    /// </summary>
    public static class LogHelperEx
    {
        private static ILog logger;

        static LogHelperEx()
        {
            if (logger == null)
            {
                ILoggerRepository repository = LogManager.CreateRepository("NETCoreRepository");
                XmlConfigurator.Configure(repository, new FileInfo("Config//log4netTwo.config"));
                logger = LogManager.GetLogger(repository.Name, "NETCorelog4net");

            }
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Debug(string message, Exception exception = null)
        {
            //  if (logger.IsDebugEnabled)
            {
                if (exception == null)
                    logger.Debug(message);
                else
                    logger.Debug(FormartLog(message, exception));
            }
        }

        /// <summary>
        /// 一般信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Info(string message, Exception exception = null)
        {
            if (logger.IsInfoEnabled)
            {
                if (exception == null)
                    logger.Info(message);
                else
                    logger.Info(FormartLog(message, exception));
            }
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Warn(string message, Exception exception = null)
        {
            if (logger.IsWarnEnabled)
            {
                if (exception == null)
                    logger.Warn(message);
                else
                    logger.Warn(FormartLog(message, exception));
            }
        }

        /// <summary>
        /// 一般错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Error(string message, Exception exception = null)
        {
            if (logger.IsErrorEnabled)
            {
                if (exception == null)
                    logger.Error(message);
                else
                    logger.Error(FormartLog(message, exception));
            }
        }

        /// <summary>
        /// 致命错误
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Fatal(string message, Exception exception = null)
        {
            if (logger.IsFatalEnabled)
            {
                if (exception == null)
                    logger.Fatal(message);
                else
                    logger.Fatal(FormartLog(message, exception));
            }
        }


        /// <summary>
        /// 自定义返回格式
        /// </summary>
        /// <param name="throwMsg"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static string FormartLog(string throwMsg, Exception ex)
        {
            return string.Format("【自定义内容】：{0} \r\n【异常类型】：{1} \r\n【异常信息】：{2} \r\n【堆栈调用】：{3}", new object[] { throwMsg, ex.GetType().Name, ex.Message, ex.StackTrace });
        }
    }
}
