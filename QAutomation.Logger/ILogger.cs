namespace QAutomation.Logger
{
    using System;

    public interface ILogger
    {
        void TRACE(string message, Exception innerException = null);
        void DEBUG(string message, Exception innerException = null);
        void INFO(string message, Exception innerException = null);
        void WARN(string message, Exception innerException = null);
        void ERROR(string message, Exception innerException = null);

        void LOG(LogLevel level, string message, Exception innerException = null);
    }
}
