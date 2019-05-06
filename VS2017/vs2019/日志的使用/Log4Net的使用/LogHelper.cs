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
    public static class LogHelper
    {

        static LogHelper()
        {
            if (LogHelper._log == null)
            {
                ILoggerRepository repository = LogManager.CreateRepository("CommonLogger");
                XmlConfigurator.Configure(repository, new FileInfo("Config//log4netTwo.config"));
                LogHelper._log = LogManager.GetLogger(repository.Name, "CommonLogger");
            }
        }

        /// <summary>
        /// 注册Log4配置文件
        /// </summary>
        /// <param name="filePath">配置文件路径</param>
        public static void RegisterLog4Config(string filePath)
        {
           // XmlConfigurator.Configure(repository, new FileInfo("Config//log4netTwo.config"));
          // XmlConfigurator.ConfigureAndWatch(new FileInfo(filePath));
        }

        /// <summary>
        /// 是否启用调试模式
        /// </summary>
        // Token: 0x17000001 RID: 1
        // (get) Token: 0x06000066 RID: 102 RVA: 0x000036B2 File Offset: 0x000018B2
        public static bool IsDebugEnabled
        {
            get
            {
                return LogHelper._log.IsDebugEnabled;
            }
        }

        /// <summary>
        /// 记录调试日志
        /// </summary>
        /// <param name="message"></param>
        // Token: 0x06000067 RID: 103 RVA: 0x000036BE File Offset: 0x000018BE
        public static void Debug(string message)
        {
            LogHelper._log.Debug(message);
        }

        /// <summary>
        /// 记录调试日志
        /// </summary>
        /// <param name="format">参数化</param>
        /// <param name="args">值</param>
        // Token: 0x06000068 RID: 104 RVA: 0x000036CB File Offset: 0x000018CB
        public static void DebugFormat(string format, params object[] args)
        {
            LogHelper._log.DebugFormat(format, args);
        }

        /// <summary>
        /// 记录消息日志
        /// </summary>
        /// <param name="message"></param>
        // Token: 0x06000069 RID: 105 RVA: 0x000036D9 File Offset: 0x000018D9
        public static void Info(string message)
        {
            LogHelper._log.Info(message);
        }

        /// <summary>
        /// 记录消息日志
        /// </summary>
        /// <param name="format">参数化</param>
        /// <param name="args">值</param>
        // Token: 0x0600006A RID: 106 RVA: 0x000036E6 File Offset: 0x000018E6
        public static void InfoFormat(string format, params object[] args)
        {
            LogHelper._log.InfoFormat(format, args);
        }

        /// <summary>
        /// 记录警告日志
        /// </summary>
        /// <param name="message"></param>
        // Token: 0x0600006B RID: 107 RVA: 0x000036F4 File Offset: 0x000018F4
        public static void Warning(string message)
        {
            LogHelper._log.Warn(message);
        }

        /// <summary>
        /// 记录警告日志
        /// </summary>
        /// <param name="format">参数化</param>
        /// <param name="args">值</param>
        // Token: 0x0600006C RID: 108 RVA: 0x00003701 File Offset: 0x00001901
        public static void WarningFormat(string format, params object[] args)
        {
            LogHelper._log.WarnFormat(format, args);
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="message"></param>
        // Token: 0x0600006D RID: 109 RVA: 0x0000370F File Offset: 0x0000190F
        public static void Error(string message)
        {
            LogHelper._log.Error(message);
        }

        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="format">参数化</param>
        /// <param name="args">值</param>
        // Token: 0x0600006E RID: 110 RVA: 0x0000371C File Offset: 0x0000191C
        public static void ErrorFormat(string format, params object[] args)
        {
            LogHelper._log.ErrorFormat(format, args);
        }

        /// <summary>
        /// 记录指定的一个Exception的日志
        /// </summary>
        /// <param name="exception"></param>
        public static void Exception(Exception exception)
        {
            LogHelper._log.Error(string.Format("已捕获异常{0}：{1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), exception.Message), exception);
        }

        /// <summary>
        /// 记录指定的一个Exception的日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>

        public static void Exception(string message, Exception exception)
        {
            LogHelper._log.Error(message, exception);
        }

        /// <summary>
        /// 创建一个记录实体
        /// </summary>

        private static readonly ILog _log;

        /// <summary>
        /// 数据库日志
        /// </summary>

        public class DbLog
        {
            // Token: 0x06000072 RID: 114 RVA: 0x0000377C File Offset: 0x0000197C
            static DbLog()
            {
                if (LogHelper.DbLog._dblog == null)
                {
                    LogHelper.DbLog._dblog = LogManager.GetLogger("DBLogger", "DBLogger");
                }
            }

            /// <summary>
            /// 是否启用调试模式
            /// </summary>
            // Token: 0x17000002 RID: 2
            // (get) Token: 0x06000073 RID: 115 RVA: 0x00003794 File Offset: 0x00001994
            public static bool IsDebugEnabled
            {
                get
                {
                    return LogHelper.DbLog._dblog.IsDebugEnabled;
                }
            }

            /// <summary>
            /// 记录调试日志
            /// </summary>
            /// <param name="message"></param>
            // Token: 0x06000074 RID: 116 RVA: 0x000037A0 File Offset: 0x000019A0
            public static void Debug(string message)
            {
                LogHelper.DbLog._dblog.Debug(message);
            }

            /// <summary>
            /// 记录调试日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>
            // Token: 0x06000075 RID: 117 RVA: 0x000037AD File Offset: 0x000019AD
            public static void DebugFormat(string format, params object[] args)
            {
                LogHelper.DbLog._dblog.DebugFormat(format, args);
            }

            /// <summary>
            /// 记录消息日志
            /// </summary>
            /// <param name="message"></param>
            // Token: 0x06000076 RID: 118 RVA: 0x000037BB File Offset: 0x000019BB
            public static void Info(string message)
            {
                LogHelper.DbLog._dblog.Info(message);
            }

            /// <summary>
            /// 记录消息日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>
            // Token: 0x06000077 RID: 119 RVA: 0x000037C8 File Offset: 0x000019C8
            public static void InfoFormat(string format, params object[] args)
            {
                LogHelper.DbLog._dblog.InfoFormat(format, args);
            }

            /// <summary>
            /// 记录警告日志
            /// </summary>
            /// <param name="message"></param>
            // Token: 0x06000078 RID: 120 RVA: 0x000037D6 File Offset: 0x000019D6
            public static void Warning(string message)
            {
                LogHelper.DbLog._dblog.Warn(message);
            }

            /// <summary>
            /// 记录警告日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>
            // Token: 0x06000079 RID: 121 RVA: 0x000037E3 File Offset: 0x000019E3
            public static void WarningFormat(string format, params object[] args)
            {
                LogHelper.DbLog._dblog.WarnFormat(format, args);
            }

            /// <summary>
            /// 记录错误日志
            /// </summary>
            /// <param name="message"></param>
            // Token: 0x0600007A RID: 122 RVA: 0x000037F1 File Offset: 0x000019F1
            public static void Error(string message)
            {
                LogHelper.DbLog._dblog.Error(message);
            }

            /// <summary>
            /// 记录错误日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>
            // Token: 0x0600007B RID: 123 RVA: 0x000037FE File Offset: 0x000019FE
            public static void ErrorFormat(string format, params object[] args)
            {
                LogHelper.DbLog._dblog.ErrorFormat(format, args);
            }

            /// <summary>
            /// 记录指定的一个Exception的日志
            /// </summary>
            /// <param name="exception"></param>
            // Token: 0x0600007C RID: 124 RVA: 0x0000380C File Offset: 0x00001A0C
            public static void Exception(Exception exception)
            {
                LogHelper.DbLog._dblog.Error(exception.Message, exception);
            }

            /// <summary>
            /// 记录指定的一个Exception的日志
            /// </summary>
            /// <param name="message"></param>
            /// <param name="exception"></param>
            // Token: 0x0600007D RID: 125 RVA: 0x0000381F File Offset: 0x00001A1F
            public static void Exception(string message, Exception exception)
            {
                LogHelper.DbLog._dblog.Error(message, exception);
            }

            // Token: 0x04000005 RID: 5
            private static readonly ILog _dblog;
        }

        /// <summary>
        /// TCP协议日志
        /// </summary>

        public class TcpLog
        {

            static TcpLog()
            {
                if (LogHelper.TcpLog._tcplog == null)
                {
                    LogHelper.TcpLog._tcplog = LogManager.GetLogger("TCPLogger", "TCPLogger");
                }
            }

            /// <summary>
            /// 是否启用调试模式
            /// </summary>

            public static bool IsDebugEnabled
            {
                get
                {
                    return LogHelper.TcpLog._tcplog.IsDebugEnabled;
                }
            }

            /// <summary>
            /// 记录调试日志
            /// </summary>
            /// <param name="message"></param>

            public static void Debug(string message)
            {
                LogHelper.TcpLog._tcplog.Debug(message);
            }

            /// <summary>
            /// 记录调试日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void DebugFormat(string format, params object[] args)
            {
                LogHelper.TcpLog._tcplog.DebugFormat(format, args);
            }

            /// <summary>
            /// 记录消息日志
            /// </summary>
            /// <param name="message"></param>

            public static void Info(string message)
            {
                LogHelper.TcpLog._tcplog.Info(message);
            }

            /// <summary>
            /// 记录消息日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void InfoFormat(string format, params object[] args)
            {
                LogHelper.TcpLog._tcplog.InfoFormat(format, args);
            }

            /// <summary>
            /// 记录警告日志
            /// </summary>
            /// <param name="message"></param>

            public static void Warning(string message)
            {
                LogHelper.TcpLog._tcplog.Warn(message);
            }

            /// <summary>
            /// 记录警告日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void WarningFormat(string format, params object[] args)
            {
                LogHelper.TcpLog._tcplog.WarnFormat(format, args);
            }

            /// <summary>
            /// 记录错误日志
            /// </summary>
            /// <param name="message"></param>

            public static void Error(string message)
            {
                LogHelper.TcpLog._tcplog.Error(message);
            }

            /// <summary>
            /// 记录错误日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void ErrorFormat(string format, params object[] args)
            {
                LogHelper.TcpLog._tcplog.ErrorFormat(format, args);
            }

            /// <summary>
            /// 记录指定的一个Exception的日志
            /// </summary>
            /// <param name="exception"></param>

            public static void Exception(Exception exception)
            {
                LogHelper.TcpLog._tcplog.Error(exception.Message, exception);
            }

            /// <summary>
            /// 记录指定的一个Exception的日志
            /// </summary>
            /// <param name="message"></param>
            /// <param name="exception"></param>

            public static void Exception(string message, Exception exception)
            {
                LogHelper.TcpLog._tcplog.Error(message, exception);
            }


            private static readonly ILog _tcplog;
        }

        /// <summary>
        /// xmpp协议日志
        /// </summary>

        public class Xmpplog
        {

            static Xmpplog()
            {
                if (LogHelper.Xmpplog._xmpplog == null)
                {
                    LogHelper.Xmpplog._xmpplog = LogManager.GetLogger("XMPPLogger", "XMPPLogger");
                }
            }

            /// <summary>
            /// 是否启用调试模式
            /// </summary>
            // Token: 0x17000004 RID: 4

            public static bool IsDebugEnabled
            {
                get
                {
                    return LogHelper.Xmpplog._xmpplog.IsDebugEnabled;
                }
            }

            /// <summary>
            /// 记录调试日志
            /// </summary>
            /// <param name="message"></param>

            public static void Debug(string message)
            {
                LogHelper.Xmpplog._xmpplog.Debug(message);
            }

            /// <summary>
            /// 记录调试日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void DebugFormat(string format, params object[] args)
            {
                LogHelper.Xmpplog._xmpplog.DebugFormat(format, args);
            }

            /// <summary>
            /// 记录消息日志
            /// </summary>
            /// <param name="message"></param>

            public static void Info(string message)
            {
                LogHelper.Xmpplog._xmpplog.Info(message);
            }

            /// <summary>
            /// 记录消息日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void InfoFormat(string format, params object[] args)
            {
                LogHelper.Xmpplog._xmpplog.InfoFormat(format, args);
            }

            /// <summary>
            /// 记录警告日志
            /// </summary>
            /// <param name="message"></param>

            public static void Warning(string message)
            {
                LogHelper.Xmpplog._xmpplog.Warn(message);
            }

            /// <summary>
            /// 记录警告日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void WarningFormat(string format, params object[] args)
            {
                LogHelper.Xmpplog._xmpplog.WarnFormat(format, args);
            }

            /// <summary>
            /// 记录错误日志
            /// </summary>
            /// <param name="message"></param>

            public static void Error(string message)
            {
                LogHelper.Xmpplog._xmpplog.Error(message);
            }

            /// <summary>
            /// 记录错误日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void ErrorFormat(string format, params object[] args)
            {
                LogHelper.Xmpplog._xmpplog.ErrorFormat(format, args);
            }

            /// <summary>
            /// 记录指定的一个Exception的日志
            /// </summary>
            /// <param name="exception"></param>

            public static void Exception(Exception exception)
            {
                LogHelper.Xmpplog._xmpplog.Error(exception.Message, exception);
            }

            /// <summary>
            /// 记录指定的一个Exception的日志
            /// </summary>
            /// <param name="message"></param>
            /// <param name="exception"></param>

            public static void Exception(string message, Exception exception)
            {
                LogHelper.Xmpplog._xmpplog.Error(message, exception);
            }

            // Token: 0x04000007 RID: 7
            private static readonly ILog _xmpplog;
        }

        /// <summary>
        /// License日志
        /// </summary>

        public class Licenselog
        {

            static Licenselog()
            {
                if (LogHelper.Licenselog._licenselog == null)
                {
                    LogHelper.Licenselog._licenselog = LogManager.GetLogger("LicenseLogger", "LicenseLogger");
                }
            }

            /// <summary>
            /// 是否启用调试模式
            /// </summary>
            // Token: 0x17000005 RID: 5

            public static bool IsDebugEnabled
            {
                get
                {
                    return LogHelper.Licenselog._licenselog.IsDebugEnabled;
                }
            }

            /// <summary>
            /// 记录调试日志
            /// </summary>
            /// <param name="message"></param>

            public static void Debug(string message)
            {
                LogHelper.Licenselog._licenselog.Debug(message);
            }

            /// <summary>
            /// 记录调试日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void DebugFormat(string format, params object[] args)
            {
                LogHelper.Licenselog._licenselog.DebugFormat(format, args);
            }

            /// <summary>
            /// 记录消息日志
            /// </summary>
            /// <param name="message"></param>

            public static void Info(string message)
            {
                LogHelper.Licenselog._licenselog.Info(message);
            }

            /// <summary>
            /// 记录消息日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void InfoFormat(string format, params object[] args)
            {
                LogHelper.Licenselog._licenselog.InfoFormat(format, args);
            }

            /// <summary>
            /// 记录警告日志
            /// </summary>
            /// <param name="message"></param>

            public static void Warning(string message)
            {
                LogHelper.Licenselog._licenselog.Warn(message);
            }

            /// <summary>
            /// 记录警告日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void WarningFormat(string format, params object[] args)
            {
                LogHelper.Licenselog._licenselog.WarnFormat(format, args);
            }

            /// <summary>
            /// 记录错误日志
            /// </summary>
            /// <param name="message"></param>

            public static void Error(string message)
            {
                LogHelper.Licenselog._licenselog.Error(message);
            }

            /// <summary>
            /// 记录错误日志
            /// </summary>
            /// <param name="format">参数化</param>
            /// <param name="args">值</param>

            public static void ErrorFormat(string format, params object[] args)
            {
                LogHelper.Licenselog._licenselog.ErrorFormat(format, args);
            }

            /// <summary>
            /// 记录指定的一个Exception的日志
            /// </summary>
            /// <param name="exception"></param>

            public static void Exception(Exception exception)
            {
                LogHelper.Licenselog._licenselog.Error(exception.Message, exception);
            }

            /// <summary>
            /// 记录指定的一个Exception的日志
            /// </summary>
            /// <param name="message"></param>
            /// <param name="exception"></param>

            public static void Exception(string message, Exception exception)
            {
                LogHelper.Licenselog._licenselog.Error(message, exception);
            }


            private static readonly ILog _licenselog;
        }
    }
 }
