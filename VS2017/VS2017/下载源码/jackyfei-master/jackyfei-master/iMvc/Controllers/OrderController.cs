using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace iMvc.Controllers
{
    public interface IUserRepository
    {
    }

    public class EfUserRepository : IUserRepository
    {

    }

    public class MemoryUserRepository : IUserRepository
    {

    }
    
    public class Order
    { }

    public class OrderController : Controller
    {
        private readonly IUserRepository _userRepository;

        public OrderController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public IActionResult Index()
        {
            return View();
            //return View(_studentClass);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add([FromBody]Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            return Ok();
        }

    }
}