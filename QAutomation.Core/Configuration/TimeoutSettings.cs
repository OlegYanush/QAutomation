namespace QAutomation.Core.Configuration
{
    public class TimeoutSettings
    {
        public double ImplicitWait { get; set; }

        public double ExplicitWait { get; set; }
        public double PoolingInterval { get; set; }

        public double HttpCommandTimeout { get; set; }
        public double JavaScriptTimeout { get; set; }
    }
}
