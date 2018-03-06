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
                throw new ConfigurationErrorsException("Section with timeout settings doesn't exist in configuration file.");

            Settings = new TimeoutSettings
            {
                ImplicitWait = section.ImplicitTimeout.Value,

                SearchTimeout = section.SearchTimeout.Value,
                PollingInterval = section.PollingInterval.Value,

                JavaScriptTimeout = section.JavascriptTimeout.Value,
                HttpCommandTimeout = section.HttpCommandTimeout.Value
            };
        }
    }
}
