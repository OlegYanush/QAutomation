namespace QAutomation.NLogWrapper
{
    using NLog;
    using System;
    using System.Collections.Generic;

    public class Logger : Logging.ILogger
    {
        private NLog.Logger _wrappedLogger;

        private Dictionary<Logging.LogLevel, LogLevel> _map = new Dictionary<Logging.LogLevel, LogLevel>
        {
            { Logging.LogLevel.TRACE, LogLevel.Trace },
            { Logging.LogLevel.DEBUG, LogLevel.Debug },
            { Logging.LogLevel.INFO, LogLevel.Info },
            { Logging.LogLevel.WARN, LogLevel.Warn },
            { Logging.LogLevel.ERROR, LogLevel.Error }
        };

        public Logger(string name) { _wrappedLogger = LogManager.GetLogger(name); }

        public void DEBUG(string message, Exception innerException = null) => LOG(Logging.LogLevel.DEBUG, message, innerException);

        public void ERROR(string message, Exception innerException = null) => LOG(Logging.LogLevel.ERROR, message, innerException);

        public void INFO(string message, Exception innerException = null) => LOG(Logging.LogLevel.INFO, message, innerException);

        public void TRACE(string message, Exception innerException = null) => LOG(Logging.LogLevel.TRACE, message, innerException);

        public void WARN(string message, Exception innerException = null) => LOG(Logging.LogLevel.WARN, message, innerException);

        public void LOG(Logging.LogLevel level, string message, Exception innerException = null)
            => _wrappedLogger.Log(_map[level], innerException, message);

        public void LOGITEM(Logging.LogLevel level, string message, string pathToFile, Exception innerException = null)
            => LOG(level, string.Concat(message, $"{{rp#file#{pathToFile}}}"), innerException);
    }
}
