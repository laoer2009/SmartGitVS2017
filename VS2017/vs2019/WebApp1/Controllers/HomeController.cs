using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp1.Models;

namespace WebApp1.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;
        public HomeController(ILoggerFactory factory)
        {
            _logger= factory.CreateLogger("WebApp1.Controllers.HomeController");
        }
        public IActionResult Index()
        {
            _logger.LogWarning("aaaaaaaaaaaaaaaaaaaaaaa");
            _logger.LogError("aaaaaaaaaaaaaaaaaaaaaaa");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
