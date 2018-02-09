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
                    ExplicitWait = section.ExplicitTimeout.Value,
                    ImplicitWait = section.ImplicitTimeout.Value,

                    HttpCommandTimeout = section.HttpCommandTimeout.Value,

                    JavaScriptTimeout = section.JavascriptTimeout.Value,
                    PoolingInterval = section.JavascriptTimeout.Value
                };
            }
            catch { throw; }
        }
    }
}
