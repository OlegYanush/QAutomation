namespace QAutomation.Appium.Configs
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.iOS;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces.Mobile;
    using Unity;

    public class IosDriverConfig : MobileDriverConfig
    {
        public IosDriverConfig()
        {
            Platform = MobilePlatform.IOS;
        }

        public override IWebDriver CreateEmulatorDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new IOSDriver<IOSElement>(RemoteAddressServerUri, GetEmulatorCapabilities(), timeout);

            return driver;
        }

        public override IWebDriver CreateRealDeviceDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new IOSDriver<IOSElement>(RemoteAddressServerUri, GetRealDeviceCapabilities(), timeout);

            return driver;
        }
    }
}
