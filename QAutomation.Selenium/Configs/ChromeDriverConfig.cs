namespace QAutomation.Selenium.Configs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core.Enums;

    public class ChromeDriverConfig : WebDriverConfig
    {
        public override Browser Browser => Browser.Chrome;

        public override IWebDriver CreateLocalDriver()
        {
            var driver = new ChromeDriver();

            return driver;
        }

        public override IWebDriver CreateRemoteDriver()
        {
            return new RemoteWebDriver(GridUri, GetOptions());
        }

        protected override ICapabilities GetCapabilites()
        {
            throw new NotImplementedException();
        }

        protected DriverOptions GetOptions()
        {
            var options = new ChromeOptions();

            return options;
        }
    }
}
