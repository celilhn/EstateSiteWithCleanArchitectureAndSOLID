using Application.Interfaces;
using NLog;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Application.Logging
{
    public class LoggerManager : ILoggerManager
    {
        private ILogger logger;
        public LoggerManager()
        {
            LogManager.LoadConfiguration(String.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "/nlog.config"));
            logger = LogManager.GetCurrentClassLogger();
        }

        public void SetLogger(string logName)
        {
            logger = LogManager.GetLogger(logName);
        }

        public void LogDebug(string message)
        {
            logger.Debug(DateTime.Now.ToLongDateString() + message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogException(Exception exception)
        {
            logger.Error(exception);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogWarn(string message)
        {
            logger.Warn(message);
        }
    }
}
