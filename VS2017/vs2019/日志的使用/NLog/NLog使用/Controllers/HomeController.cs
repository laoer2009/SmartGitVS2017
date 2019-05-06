using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog使用.Models;

namespace NLog使用.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        public HomeController(ILogger<HomeController> loggger)
        {
            _logger = loggger;
        }
        public IActionResult Index()
        {

            try
            {
                int a = 0;
                int b = 10;
             var q=   b / a;
            }
            catch (Exception ex)
            {
                NLogHelper.nlog.Info("NLOgHELPER异常");
                NLogHelper.nlog.Error(ex.ToString());
                //_logger.LogInformation("yich");
                //_logger.LogError(ex.ToString());
            }
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
