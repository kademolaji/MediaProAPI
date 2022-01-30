using Serilog;
using Serilog.Core;
using Serilog.Formatting.Compact;
using SpotzerMediaPro.Common.Interfaces;
using System;
using System.IO;

namespace SpotzerMediaPro.Common.Helpers
{
    public class LoggerService : ILoggerService
    {

        private static Logger _logger;
        private readonly string _prefix;

        public LoggerService()
        {
            if (_logger == null)
            {
                CreateLogger();
            }
        }

        public void CreateLogger()
        {
            
                _logger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .WriteTo.Debug(new RenderedCompactJsonFormatter())
                    .WriteTo.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log-{Date}.txt"), rollingInterval: RollingInterval.Day)
                    .CreateLogger();
        }

        public LoggerService(string prefix) : this()
        {
            _prefix = $"[{prefix}]";
        }

        public void Info(string message)
        {
            _logger.Information($"{_prefix}{message}");
        }

        public void Debug(string message)
        {
            _logger.Debug($"{_prefix}{message}");
        }

        public void Warn(string message)
        {
            _logger.Warning($"{_prefix}{message}");
        }

        public void Error(string message)
        {
            _logger.Error($"{_prefix}{message}");
        }
    }
}
