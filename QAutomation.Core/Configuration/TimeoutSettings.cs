namespace QAutomation.Core.Configuration
{
    public class TimeoutSettings
    {
        public double ImplicitWait { get; set; }
        public double PageLoadTimeout { get; set; }

        public double SearchTimeout { get; set; }
        public double PollingInterval { get; set; }

        public double JavaScriptTimeout { get; set; }
        public double HttpCommandTimeout { get; set; }
    }
}
