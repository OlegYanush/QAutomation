namespace QAutomation.Appium.Configs
{
    using System;
    using OpenQA.Selenium.Appium.Android;
    using QAutomation.Appium.Engine.Android;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces.Mobile;
    using Unity;

    public class AndroidDriverConfig : MobileDriverConfig
    {
        public IUnityContainer UnityContainer { get; set; }
        public override MobilePlatform Platform => MobilePlatform.Android;

        public override IMobileDriver CreateEmulatorDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new AndroidDriver<AndroidElement>(RemoteAddressServerUri, GetEmulatorCapabilities(), timeout);

            ConfigurateDriverTimeouts(driver);
            return new WrappedAndroidDriver(driver, this, UnityContainer);
        }

        public override IMobileDriver CreateRealDeviceDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new AndroidDriver<AndroidElement>(RemoteAddressServerUri, GetRealDeviceCapabilities(), timeout);

            ConfigurateDriverTimeouts(driver);
            return new WrappedAndroidDriver(driver, this, UnityContainer);
        }
    }
}
