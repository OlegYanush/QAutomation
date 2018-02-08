namespace QAutomation.Core.Configuration
{
    using System.Configuration;

    public class TimeoutSettingsProvider : ConfigurationSection
    {
        public static readonly TimeoutSettings Settings;

        static TimeoutSettingsProvider()
        {
            try
            {
                var section = (TimeoutSettingsSection)ConfigurationManager.GetSection("TimeoutSettings");

                Settings = new TimeoutSettings
                {
                    ExplicitWaitTimeoutInSec = section.ExplicitTimeout.Value,
                    ImplicitWaitTimeoutInSec = section.ImplicitTimeout.Value,

                    HttpCommandTimeoutInSec = section.HttpCommandTimeout.Value,

                    JavaScriptTimeoutInSec = section.JavascriptTimeout.Value,
                    PoolingIntervalInSec = section.JavascriptTimeout.Value
                };
            }
            catch { throw; }
        }
    }
}
