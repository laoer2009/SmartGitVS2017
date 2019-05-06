using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace NewsPublish.Web.Controllers
{
    public class RedisSessionController : Controller
    {
        IDistributedCache _cache;
        public RedisSessionController(IDistributedCache cache)
        {
            _cache = cache;
        }
        public IActionResult Index()
        {
            _cache.SetString("aa", "bb");
            
            return View();
        }
    }
}