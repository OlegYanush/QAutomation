namespace QAutomation.Appium.Configs
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core.Configuration;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces.Mobile;
    using System;
    using Unity;

    public abstract class MobileDriverConfig : IMobileDriverConfig
    {
        public abstract IWebDriver CreateEmulatorDriver();
        public abstract IWebDriver CreateRealDeviceDriver();

        public MobilePlatform Platform { get; protected set; }
        public string Version { get; set; }

        public bool UseEmulator { get; set; }
        public Core.Enums.Mobile.ScreenOrientation Orientation { get; set; } = Core.Enums.Mobile.ScreenOrientation.Portrait;

        public double ImplicitWaitTimeoutInSec { get; set; } = 60;
        public double ExplicitWaitTimeoutInSec { get; set; } = 60;

        public double HttpCommandTimeoutInSec { get; set; } = 65;
        public double JavaScriptTimeoutInSec { get; set; } = 60;

        public double PoolingIntervalInSec { get; set; } = 2;

        public Uri RemoteAddressServerUri { get; set; }

        public string DeviceName { get; set; }
        public string AutomationName { get; set; } = AutomationEngine.Appium;

        public string DeviceId { get; set; }
        public string PathToApp { get; set; }

        public string BrowserName { get; set; }
        public string Locale { get; set; }

        public bool NoReset { get; set; }
        public bool FullReset { get; set; }

        public bool AutoWebView { get; set; }

        public TimeoutSettings Timeouts => throw new NotImplementedException();

        public IWebDriver CreateDriver() => UseEmulator ? CreateEmulatorDriver() : CreateRealDeviceDriver();

        protected virtual DesiredCapabilities GetEmulatorCapabilities()
        {
            var capabilities = new DesiredCapabilities();

            capabilities.SetCapability("automationName", AutomationName);
            capabilities.SetCapability("platformName", Platform);

            capabilities.SetCapability("platformVersion", Version);
            capabilities.SetCapability("deviceName", DeviceName);

            capabilities.SetCapability("newCommandTimeout", HttpCommandTimeoutInSec);
            capabilities.SetCapability("orientation", Orientation.ToString().ToUpperInvariant());

            capabilities.SetCapability("fullReset", FullReset);
            capabilities.SetCapability("noReset", NoReset);

            capabilities.SetCapability("autoWebview", AutoWebView);

            capabilities.SetCapability("locale", Locale);
            capabilities.SetCapability("orientation", Orientation.ToString().ToUpperInvariant());

            if (DeviceId != default(string))
                capabilities.SetCapability("udid", DeviceId);

            if (PathToApp != default(string))
                capabilities.SetCapability("app", PathToApp);
            else
                capabilities.SetCapability("browserName", BrowserName);

            return capabilities;
        }

        protected virtual DesiredCapabilities GetRealDeviceCapabilities()
        {
            var capabilities = new DesiredCapabilities();

            capabilities.SetCapability("automationName", AutomationName);
            capabilities.SetCapability("platformName", Platform);

            capabilities.SetCapability("platformVersion", Version);
            capabilities.SetCapability("deviceName", DeviceName);

            capabilities.SetCapability("newCommandTimeout", HttpCommandTimeoutInSec);
            capabilities.SetCapability("autoWebview", AutoWebView);

            capabilities.SetCapability("fullReset", FullReset);
            capabilities.SetCapability("noReset", NoReset);

            if (DeviceId != default(string))
                capabilities.SetCapability("udid", DeviceId);

            if (PathToApp != default(string))
                capabilities.SetCapability("app", PathToApp);
            else
                capabilities.SetCapability("browserName", BrowserName);

            return capabilities;
        }

        protected void ConfigurateDriverTimeouts(IWebDriver driver)
        {
            //driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(JavaScriptTimeoutInSec);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ImplicitWaitTimeoutInSec);
        }
    }
}
