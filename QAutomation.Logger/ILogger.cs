using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation.Logger
{
    public interface ILogger
    {
        void TRACE(string message, Exception innerException = null);
        void DEBUG(string message, Exception innerException = null);
        void INFO(string message, Exception innerException = null);
        void WARN(string message, Exception innerException = null);
        void ERROR(string message, Exception innerException = null);
    }
}
