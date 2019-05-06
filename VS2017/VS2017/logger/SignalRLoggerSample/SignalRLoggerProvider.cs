using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace SignalRLoggerSample
{
    public class SignalRLoggerProvider : ILoggerProvider
    {
        public SignalRLoggerProvider()
        {

        }
        public ILogger CreateLogger(string categoryName)
        {
            return new SignalRLogger();
        }

        public void Dispose()
        {
           
        }
    }
}
