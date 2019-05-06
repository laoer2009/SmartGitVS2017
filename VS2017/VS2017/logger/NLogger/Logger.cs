using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using log4net.Core;

namespace NLogger
{
    //https://www.cnblogs.com/linezero/p/log4net.html
    //https://www.cnblogs.com/pudefu/p/9300697.html
    public class Logger
    {
        private static readonly log4net.ILog _logger;

        static Logger()
        {
            if (_logger == null)
            {
                var repository = LogManager.CreateRepository("NETCoreRepository");
                    //log4net从log4net.config文件中读取配置信息
                XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));
                _logger = LogManager.GetLogger(repository.Name, "InfoLogger");
              //  ILog log = LogManager.GetLogger(repository.Name, "NETCorelog4net_laoer");
            }
        }
        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public static void Info(string message, Exception exception = null)
        {
            if (exception == null)
                _logger.Info(message);
            else
                _logger.Info(message, exception);
        }
    }
}
