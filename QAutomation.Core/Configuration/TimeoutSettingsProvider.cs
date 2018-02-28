namespace QAutomation.Core.Configuration
{
    using System.Configuration;

    public class TimeoutSettingsProvider : ConfigurationSection
    {
        private const string CONFIGURATION_SECTION_NAME = "TimeoutSettings";

        public static readonly TimeoutSettings Settings;

        static TimeoutSettingsProvider()
        {
            try
            {
                var section = (TimeoutSettingsSection)ConfigurationManager.GetSection(CONFIGURATION_SECTION_NAME);

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
