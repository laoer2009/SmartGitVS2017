using iMvc.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace iMvcTest
{
    public class OrderControllerTest
    {
        [Fact]
        public void Add_IsSuccess()
        {
            var repositroy = new EfUserRepository();
            //var repositroy = new MemoryUserRepository();
            var order_controller = new OrderController(repositroy);

            var result = order_controller.Add(new Order());

            Assert.IsType<OkResult>(result);

        }
    }



}
   
