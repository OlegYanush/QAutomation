namespace QAutomation.Selenium.Configs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;

    class FirefoxDriverConfig : MobileDriverConfig
    {
        public override IWebDriver CreateLocalDriver()
        {
            var driver = new FirefoxDriver();

            return driver;
        }

        public override IWebDriver CreateRemoteDriver()
        {
            var driver = new RemoteWebDriver(GridUri, GetCapabilites(), TimeSpan.FromSeconds(Timeouts.HttpCommandTimeoutInSec));

            return driver;
        }

        protected override ICapabilities GetCapabilites()
        {
            var options = new FirefoxOptions();

            return options.ToCapabilities();
        }
    }
}
