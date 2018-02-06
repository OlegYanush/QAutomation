namespace QAutomation.Appium.Configs
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces.Mobile;
    using System;

    public abstract class MobileDriverConfig : IMobileDriverConfig
    {
        public abstract MobilePlatform Platform { get; }
        public string Version { get; set; }

        public bool UseEmulator { get; set; }
        public Core.Enums.Mobile.ScreenOrientation Orientation { get; set; } = Core.Enums.Mobile.ScreenOrientation.Landscape;

        public double ImplicitWaitTimeoutInSec { get; set; }
        public double ExplicitWaitTimeoutInSec { get; set; }

        public double HttpCommandTimeoutInSec { get; set; }
        public double JavaScriptTimeoutInSec { get; set; }

        public double PoolingIntervalInSec { get; set; }

        public Uri RemoteAddressServerUri { get; set; }

        public string DeviceName { get; set; }
        public string AutomationName { get; set; }

        public string DeviceId { get; set; }
        public string PathToApp { get; set; }

        public string BrowserName { get; set; }
        public string Locale { get; set; }

        public bool NoReset { get; set; }
        public bool FullReset { get; set; }

        public IMobileDriver CreateDriver() => UseEmulator ? CreateEmulatorDriver() : CreateRealDeviceDriver();

        public abstract IMobileDriver CreateEmulatorDriver();
        public abstract IMobileDriver CreateRealDeviceDriver();

        protected virtual DesiredCapabilities GetEmulatorCapabilities()
        {
            return null;
        }

        protected virtual DesiredCapabilities GetRealDeviceCapabilities()
        {
            return null;
        }

        protected void ConfigurateDriverTimeouts(IWebDriver driver)
        {
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(JavaScriptTimeoutInSec);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutInSec);
        }
    }
}
