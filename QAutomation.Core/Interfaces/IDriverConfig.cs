namespace QAutomation.Core.Interfaces
{
    public interface IDriverConfig
    {
        double ImplicitWaitTimeoutInSec { get; set; }
        double ExplicitWaitTimeoutInSec { get; set; }

        double HttpCommandTimeoutInSec { get; set; }
        double JavaScriptTimeoutInSec { get; set; }

        double PoolingIntervalInSec { get; set; }
    }
}
