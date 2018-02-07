namespace QAutomation.Appium.Configs
{
    using System;
    using OpenQA.Selenium.Appium.iOS;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces.Mobile;
    using Unity;

    public class IosDriverConfig : MobileDriverConfig
    {
        public IosDriverConfig(IUnityContainer container)
           : base(container) { }

        public override MobilePlatform Platform => MobilePlatform.IOS;

        public override IMobileDriver CreateEmulatorDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new IOSDriver<IOSElement>(RemoteAddressServerUri, GetEmulatorCapabilities(), timeout);

            ConfigurateDriverTimeouts(driver);
            return null;
        }

        public override IMobileDriver CreateRealDeviceDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new IOSDriver<IOSElement>(RemoteAddressServerUri, GetRealDeviceCapabilities(), timeout);

            ConfigurateDriverTimeouts(driver);
            return null;
        }
    }
}
