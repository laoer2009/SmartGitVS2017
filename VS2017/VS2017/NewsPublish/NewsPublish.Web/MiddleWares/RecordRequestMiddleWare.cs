using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPublish.Web.MiddleWares
{
   /// <summary>
   /// 自定义中间件
   /// </summary>
    public class RecordRequestMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RecordRequestMiddleWare> _logger;
        public RecordRequestMiddleWare(RequestDelegate next,ILogger<RecordRequestMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            var request = context.Request;
            if(request.Method== HttpMethods.Post)
            {
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);

                var bodyString = Encoding.UTF8.GetString(buffer);
                _logger.LogInformation($"http protocal:{request.Protocol},host:{request.Host},path:{request.Path}");
                _logger.LogInformation($"request body content:{bodyString}");
            }
            await _next(context);
        }
    }
}
