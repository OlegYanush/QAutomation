namespace QAutomation.Selenium.Configs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
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
            throw new NotImplementedException();
        }

        protected override ICapabilities GetCapabilites()
        {
            throw new NotImplementedException();
        }
    }
}
