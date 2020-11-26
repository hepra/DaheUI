using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIFrameworkCore.DependencyInjectionExtension
{
    public interface ILoggerInfo
    {
        void Debug(string message);
        void Debug(Exception exception, string message);
        void Error(string message);
        void Error(Exception exception, string message);
        void Fatal(string message);
        void Fatal(Exception exception, string message);
        void Info(string message);
        void Info(Exception exception, string message);
        void Trace(string message);
        void Trace(Exception exception, string message);
        void Warn(string message);
        void Warn(Exception exception, string message);
    }

    internal class LoggerInfo: ILoggerInfo
    {
        private ILogger logger;

        public LoggerInfo(ILogger logger)
        {
            this.logger = logger;
        }

        public void Debug(string message)
        {
            logger.Debug(message);
        }

        public void Debug(Exception exception, string message)
        {
            logger.Debug(exception, message);
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Error(Exception exception, string message)
        {
            logger.Error(exception, message);
        }

        public void Fatal(string message)
        {
            logger.Fatal(message);
        }

        public void Fatal(Exception exception, string message)
        {
            logger.Fatal(exception, message);
        }

        public void Info(string message)
        {
            logger.Info(message);
        }

        public void Info(Exception exception, string message)
        {
            logger.Info(exception, message);
        }

        public void Trace(string message)
        {
            logger.Trace(message);
        }

        public void Trace(Exception exception, string message)
        {
            logger.Trace(exception, message);
        }

        public void Warn(string message)
        {
            logger.Warn(message);
        }

        public void Warn(Exception exception, string message)
        {
            logger.Warn(exception, message);
        }
    }

    public interface ILoggerWarpFactory
    {
        ILoggerInfo GetLogger(string name = "Default");
    }

    [NoProxy]
    [Singleton(typeof(ILoggerWarpFactory))]
    internal class LoggerWarpFactory : ILoggerWarpFactory
    {
        public LoggerWarpFactory()
        {
            var configure = new LoggingConfiguration();

            var fileTarget = new FileTarget()
            {
                FileName = "logger.txt",
                Layout = "${longdate} ${logger} ${message}"
            };
            //var asyncTarget = new AsyncTargetWrapper(fileTarget);
            configure.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget, "Default");
            LogManager.Configuration = configure;
        }

        public ILoggerInfo GetLogger(string name = "Default")
        {
            if (!name.Equals("Default"))
            {
                var config = LogManager.Configuration;

                if (!config.LoggingRules.Any(_target=>_target.LoggerNamePattern == name))
                {
                    var fileTarget = new FileTarget()
                    {
                        FileName = $"{name}.txt",
                        Layout = "${longdate} ${logger} ${message}"
                    };
                    //var asyncTarget = new AsyncTargetWrapper(fileTarget);
                    config.AddRule(LogLevel.Debug, LogLevel.Fatal, fileTarget, name);

                    LogManager.ReconfigExistingLoggers();
                }
            }

            var _logger = LogManager.GetLogger(name);

            return new LoggerInfo(_logger);
        }
    }
}
