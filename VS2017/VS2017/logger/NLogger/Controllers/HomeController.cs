using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLogger.Models;

namespace NLogger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }
        public IActionResult Index()
        {
            //日志级别：Trace -》Debug -》 Info -》Warn -》 Error -》 Critical日志级别由小到大， Trace 就包含了所有日志。
            //Trace|Debug|Info|Warn|Error|Fatal"
            logger.LogTrace("跟踪日志-----------");
            logger.LogDebug("调试日志-----------");
            logger.LogInformation("普通信息日志-----------");
            logger.LogWarning("警告日志-----------");
            logger.Log(LogLevel.Warning, "Log日志------------------");
            logger.LogError("错误日志-----------");
            logger.LogCritical("异常日志-----------");
    
           
         
          


            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
