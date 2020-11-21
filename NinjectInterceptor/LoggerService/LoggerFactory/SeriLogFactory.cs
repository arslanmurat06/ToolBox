using LoggerService.Logger;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.LoggerFactory
{
    public class SeriLogFactory : ILoggerFactory
    {

        Serilog.ILogger _logger;

        public SeriLogFactory()
        {
                _logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public Logger.ILogger CreateLogger(string loggerName)
        {
            return new SeriLogger(loggerName, _logger);
        }
    }
}
