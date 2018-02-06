namespace QAutomation.Appium.Configs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium.Appium.Android;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces.Mobile;

    public class AndroidDriverConfig : MobileDriverConfig
    {
        public override MobilePlatform Platform => MobilePlatform.Android;

        public override IMobileDriver CreateEmulatorDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new AndroidDriver<AndroidElement>(RemoteAddressServerUri, GetEmulatorCapabilities(), timeout);

            ConfigurateDriverTimeouts(driver);
            return null;
        }

        public override IMobileDriver CreateRealDeviceDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new AndroidDriver<AndroidElement>(RemoteAddressServerUri, GetRealDeviceCapabilities(), timeout);

            ConfigurateDriverTimeouts(driver);
            return null;
        }
    }
}
