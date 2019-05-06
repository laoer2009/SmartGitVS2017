using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoggerTwo.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LoggerTwo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger = null;
        private readonly IOptions<AppSetting2> _settings;
        //  读取配置文件内容  https://www.cnblogs.com/yuangang/p/5736892.html
        public HomeController(ILogger<HomeController> logger, IOptions<AppSetting2> settings)
        {
            _logger = logger;
            _settings = settings;
        }
        public IActionResult Index()
        {
            _logger.LogInformation(".Net Core  pppp内置日志组件……ConsoleColor.Blue");
            _logger.LogWarning(".Net Core Logging warning……ConsoleColor.Red");
            _logger.LogDebug(".Net Core Logging Debug…… ConsoleColor.Yellow");
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
