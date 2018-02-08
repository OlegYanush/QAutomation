namespace QAutomation.Core
{
    public class TimeoutSettings
    {
        public double ImplicitWaitTimeoutInSec { get; set; }
        public double ExplicitWaitTimeoutInSec { get; set; }

        public double HttpCommandTimeoutInSec { get; set; }
        public double JavaScriptTimeoutInSec { get; set; }

        public double PoolingIntervalInSec { get; set; }
    }
}
