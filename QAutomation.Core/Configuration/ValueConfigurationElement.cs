namespace QAutomation.Core.Configuration
{
    using System.Configuration;

    public class ValueConfigurationElement<T> : ConfigurationElement
    {
        public ValueConfigurationElement() { }

        [ConfigurationProperty("value")]
        public T Value => (T)this["value"];
    }
}
