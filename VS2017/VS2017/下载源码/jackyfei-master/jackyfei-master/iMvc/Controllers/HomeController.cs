using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace iMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentClass _studentClass;

        public HomeController(IOptionsSnapshot<StudentClass> stuClass)
        {
            _studentClass = stuClass.Value;
        }


        public IActionResult Index()
        {
            return View();
            //return View(_studentClass);
        }
    }
}