namespace QAutomation.Core.Configuration
{
    using System.Configuration;

    public class TimeoutSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty(nameof(ImplicitTimeout))]
        public ValueConfigurationElement<double> ImplicitTimeout
            => (ValueConfigurationElement<double>)this[nameof(ImplicitTimeout)];

        [ConfigurationProperty(nameof(ExplicitTimeout))]
        public ValueConfigurationElement<double> ExplicitTimeout
            => (ValueConfigurationElement<double>)this[nameof(ExplicitTimeout)];

        [ConfigurationProperty(nameof(JavascriptTimeout))]
        public ValueConfigurationElement<double> JavascriptTimeout
            => (ValueConfigurationElement<double>)this[nameof(JavascriptTimeout)];

        [ConfigurationProperty(nameof(PoolingInterval))]
        public ValueConfigurationElement<double> PoolingInterval
            => (ValueConfigurationElement<double>)this[nameof(PoolingInterval)];

        [ConfigurationProperty(nameof(HttpCommandTimeout))]
        public ValueConfigurationElement<double> HttpCommandTimeout
            => (ValueConfigurationElement<double>)this[nameof(HttpCommandTimeout)];
    }
}
