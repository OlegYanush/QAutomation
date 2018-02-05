namespace QAutomation.Appium
{
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core;
    using QAutomation.Core.Enums;
    using QAutomation.Core.New;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;

    public class AndroidDriverConfig : MobileDriverConfig
    {
        public override Platform Platform => Platform.Android;

        public IUnityContainer Container { get; set; }

        public override IMobileDriver CreateEmulatorDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);

            var driver = new AndroidDriver<AndroidElement>(RemoteAddressServerUri, GetEmulatorCapabilities(), timeout);
            return new AndroidDriver(driver, Container);
        }

        public override IMobileDriver CreateRealDeviceDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);

            var driver = new AndroidDriver<AndroidElement>(RemoteAddressServerUri, GetRealDeviceCapabilities(), timeout);
            return new AndroidDriver(driver, Container);
        }

        private DesiredCapabilities GetRealDeviceCapabilities()
        {
            return null;
        }

        private DesiredCapabilities GetEmulatorCapabilities()
        {
            return null;
        }
    }
}
