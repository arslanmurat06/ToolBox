using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.LoggerFactory
{
    public interface ILoggerFactory
    {
        Logger.ILogger CreateLogger(string loggerName);
    }
}
