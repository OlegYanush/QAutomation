namespace QAutomation.Selenium.Configs
{
    using OpenQA.Selenium;
    using QAutomation.Core.Configuration;
    using QAutomation.Core.Enums;
    using QAutomation.Core.Interfaces;
    using System;

    public abstract class WebDriverConfig : IBrowserDriverConfig
    {
        public abstract Browsers Browser { get; }
        public string Version { get; set; }

        public TimeoutSettings Timeouts { get; set; }

        public bool UseGrid { get; set; }
        public Uri GridUri { get; set; }

        public IWebDriver CreateDriver() => UseGrid ? CreateRemoteDriver() : CreateLocalDriver();

        public abstract IWebDriver CreateLocalDriver();
        public abstract IWebDriver CreateRemoteDriver();

        protected abstract ICapabilities GetCapabilites();

        public override string ToString() => $"{Browser}{(Version != null ? $"({Version})" : string.Empty)}";
    }
}
