namespace QAutomation.Core.Configuration
{
    using System.Configuration;

    public class TimeoutSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty(nameof(ImplicitTimeout))]
        public ValueConfigurationElement<double> ImplicitTimeout => (ValueConfigurationElement<double>)this[nameof(ImplicitTimeout)];

        [ConfigurationProperty(nameof(PageLoadTimeout))]
        public ValueConfigurationElement<double> PageLoadTimeout => (ValueConfigurationElement<double>)this[nameof(PageLoadTimeout)];

        [ConfigurationProperty(nameof(SearchTimeout))]
        public ValueConfigurationElement<double> SearchTimeout => (ValueConfigurationElement<double>)this[nameof(SearchTimeout)];

        [ConfigurationProperty(nameof(PollingInterval))]
        public ValueConfigurationElement<double> PollingInterval => (ValueConfigurationElement<double>)this[nameof(PollingInterval)];

        [ConfigurationProperty(nameof(JavascriptTimeout))]
        public ValueConfigurationElement<double> JavascriptTimeout => (ValueConfigurationElement<double>)this[nameof(JavascriptTimeout)];

        [ConfigurationProperty(nameof(HttpCommandTimeout))]
        public ValueConfigurationElement<double> HttpCommandTimeout => (ValueConfigurationElement<double>)this[nameof(HttpCommandTimeout)];
    }
}
