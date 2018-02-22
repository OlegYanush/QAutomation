using QAutomation.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation.NLogger
{
    public class NLogger : ILogger
    {
        private NLog.Logger _wrappedLogger;


        public void DEBUG(string message, Exception innerException = null)
        {
            _wrappedLogger.Debug(innerException, message);
        }

        public void ERROR(string message, Exception innerException = null)
        {
            _wrappedLogger.Error(innerException, message);
        }

        public void INFO(string message, Exception innerException = null)
        {
            _wrappedLogger.Info(innerException, message);
        }

        public void LOG(LogLevel level, string message, Exception innerException = null)
        {
            throw new NotImplementedException();
        }

        public void TRACE(string message, Exception innerException = null)
        {
            _wrappedLogger.Trace(innerException, message);
        }

        public void WARN(string message, Exception innerException = null)
        {
            _wrappedLogger.Warn(innerException, message);
        }
    }
}
