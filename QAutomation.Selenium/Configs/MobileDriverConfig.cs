namespace QAutomation.Selenium.Configs
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces;
    using System;

    public abstract class MobileDriverConfig : IDriverConfig
    {
        public TimeoutSettings Timeouts { get; set; }

        public bool UseGrid { get; set; }
        public Uri GridUri { get; set; }

        public IWebDriver CreateDriver() => UseGrid ? CreateRemoteDriver() : CreateLocalDriver();

        public abstract IWebDriver CreateLocalDriver();
        public abstract IWebDriver CreateRemoteDriver();

        protected abstract ICapabilities GetCapabilites();
    }
}
