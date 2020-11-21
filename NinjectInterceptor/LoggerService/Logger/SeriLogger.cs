using Serilog.Debugging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerService.Logger
{
    public class SeriLogger : ILogger
    {
        private readonly string _loggerName;
        private readonly Serilog.ILogger _logger;

        public SeriLogger(string loggerName, Serilog.ILogger logger)
        {
            _loggerName = loggerName;
            _logger = logger;
        }
        public void Debug(string message, params object[] args)
        {
            _logger.ForContext("LogContext", _loggerName).Debug(message,args);
        }

        public void Error(string message, Exception ex, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Fatal(string message, Exception ex, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Info(string message, params object[] args)
        {
            _logger.ForContext("LogContext", _loggerName).Information(message, args);
        }

        public void Warn(string message, params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
