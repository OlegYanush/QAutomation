namespace QAutomation.Core.Configuration
{
    using System.Configuration;

    public class TimeoutSettingsProvider : ConfigurationSection
    {
        private const string CONFIGURATION_SECTION_NAME = "TimeoutSettings";

        public static readonly TimeoutSettings Settings;

        static TimeoutSettingsProvider()
        {
            var section = ConfigurationManager.GetSection(CONFIGURATION_SECTION_NAME) as TimeoutSettingsSection;

            if (section == null)
                throw new ConfigurationErrorsException("Section with timeout settings section doesn't exist in app configuration file.");

            Settings = new TimeoutSettings
            {
                ExplicitWait = section.ExplicitTimeout.Value,
                ImplicitWait = section.ImplicitTimeout.Value,

                HttpCommandTimeout = section.HttpCommandTimeout.Value,

                JavaScriptTimeout = section.JavascriptTimeout.Value,
                PoolingInterval = section.JavascriptTimeout.Value
            };
        }
    }
}
