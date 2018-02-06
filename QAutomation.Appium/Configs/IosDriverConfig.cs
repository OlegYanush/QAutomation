namespace QAutomation.Appium.Configs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Appium.iOS;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces.Mobile;

    public class IosDriverConfig : MobileDriverConfig
    {
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
