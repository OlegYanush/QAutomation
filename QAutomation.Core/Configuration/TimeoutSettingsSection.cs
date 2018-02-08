namespace QAutomation.Core.Configuration
{
    using System.Configuration;

    public class TimeoutSettingsSection : ConfigurationSection
    {
        [ConfigurationProperty("ImplicitTimeout")]
        public ValueConfigurationElement<double> ImplicitTimeout => (ValueConfigurationElement<double>) this["ImplicitTimeout"];

        [ConfigurationProperty("ExplicitTimeout")]
        public ValueConfigurationElement<double> ExplicitTimeout => (ValueConfigurationElement<double>)this["ExplicitTimeout"];

        [ConfigurationProperty("JavascriptTimeout")]
        public ValueConfigurationElement<double> JavascriptTimeout => (ValueConfigurationElement<double>)this["JavascriptTimeout"];

        [ConfigurationProperty("PoolingInterval")]
        public ValueConfigurationElement<double> PoolingInterval => (ValueConfigurationElement<double>)this["PoolingInterval"];

        [ConfigurationProperty("HttpCommandTimeout")]
        public ValueConfigurationElement<double> HttpCommandTimeout => (ValueConfigurationElement<double>)this["HttpCommandTimeout"];
    }
}
