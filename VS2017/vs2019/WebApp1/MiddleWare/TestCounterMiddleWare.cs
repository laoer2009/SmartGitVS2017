using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp1.DI;
namespace WebApp1.MiddleWare
{
   /// <summary>
   /// 在自定义中间件中使用注入
   /// </summary>
    public class TestCounterMiddleWare
    {
        private readonly RequestDelegate _next;

        public TestCounterMiddleWare(RequestDelegate next)
        {

            _next = next;
        }

        //public async Task InvokeAsync(HttpContext context)
        //{
        //    int counter = _counter.Get();
        //    await _next(context);
        //}
        public async Task InvokeAsync(HttpContext context,ICounter counter)
        {
            int count = counter.Get();
            await _next(context);
        }
    }
}
