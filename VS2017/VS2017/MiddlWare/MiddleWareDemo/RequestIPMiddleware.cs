using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MiddleWareDemo
{
    public class RequestIpMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        // public delegate Task RequestDelegate(HttpContext context)
        public RequestIpMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestIpMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Use IP" + context.Connection.RemoteIpAddress.ToString());
            await _next.Invoke(context);
        }
    }
}
