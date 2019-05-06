using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
namespace NewsPublish.Web.Controllers
{
    //[Route("[controller]")]
    public class EnviromentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly DbContext _context;
        public EnviromentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        //[HttpGet("Index")]
        //[ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            var even =_configuration["Enviroment"];
            return View(nameof(Index),even);
            

        }
    }
}