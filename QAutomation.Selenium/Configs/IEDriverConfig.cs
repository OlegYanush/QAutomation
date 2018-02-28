namespace QAutomation.Selenium.Configs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using QAutomation.Core.Enums;

    public class IEDriverConfig : WebDriverConfig
    {
        public override Browsers Browser => Browsers.InternetExplorer;

        public override IWebDriver CreateLocalDriver()
        {
            throw new NotImplementedException();
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
