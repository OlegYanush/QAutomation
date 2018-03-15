namespace QAutomation.Appium.Configs
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core.Enums.Mobile;

    public class AndroidDriverConfig : MobileDriverConfig
    {
        public AndroidDriverConfig()
        {
            Platform = MobilePlatform.Android;
        }

        public string AppActivity { get; set; }
        public string AppPackage { get; set; }

        public string[] AppWaitActivities { get; set; }
        public string AppWaitPackage { get; set; }

        public int AppWaitDurationInSec { get; set; } = 20;
        public int DeviceReadyTimeoutInSec { get; set; } = 5;

        public int AndroidDeviceReadyTimeoutInSec { get; set; } = 30;
        public int AndroidInstallTimeoutInSec { get; set; } = 90;
        public string AndroidInstallPath { get; set; }

        public bool IgnoreUnimportantViews { get; set; }

        public override IWebDriver CreateEmulatorDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new AndroidDriver<AndroidElement>(RemoteAddressServerUri, GetEmulatorCapabilities(), timeout);

            return driver;
        }

        public override IWebDriver CreateRealDeviceDriver()
        {
            var timeout = TimeSpan.FromSeconds(HttpCommandTimeoutInSec);
            var driver = new AndroidDriver<AndroidElement>(RemoteAddressServerUri, GetRealDeviceCapabilities(), timeout);

            return driver;
        }

        protected override DesiredCapabilities GetEmulatorCapabilities()
        {
            var capabilities = base.GetEmulatorCapabilities();

            if (AppActivity != default(string))
                capabilities.SetCapability("appActivity", AppActivity);

            if (AppPackage != default(string))
                capabilities.SetCapability("appPackage", AppPackage);

            if (AppWaitPackage != default(string))
                capabilities.SetCapability("appWaitPackage", AppWaitPackage);

            if (AppWaitActivities != null && AppWaitActivities.Length != 0)
                capabilities.SetCapability("appWaitActivity", string.Join(",", AppWaitActivities));

            capabilities.SetCapability("appWaitDuration", TimeSpan.FromSeconds(AppWaitDurationInSec).TotalMilliseconds);
            capabilities.SetCapability("deviceReadyTimeout", DeviceReadyTimeoutInSec);

            capabilities.SetCapability("androidInstallTimeout", AndroidDeviceReadyTimeoutInSec);
            capabilities.SetCapability("androidInstallTimeout", TimeSpan.FromSeconds(AndroidInstallTimeoutInSec).TotalMilliseconds);

            if (AndroidInstallPath != default(string))
                capabilities.SetCapability("androidInstallPath", AndroidInstallPath);

            return capabilities;
        }

        protected override DesiredCapabilities GetRealDeviceCapabilities()
        {
            var capabilities = base.GetRealDeviceCapabilities();

            if (AppActivity != default(string))
                capabilities.SetCapability("appActivity", AppActivity);

            if (AppPackage != default(string))
                capabilities.SetCapability("appPackage", AppPackage);

            if (AppWaitPackage != default(string))
                capabilities.SetCapability("appWaitPackage", AppWaitPackage);

            if (AppWaitActivities != null && AppWaitPackage.Length != 0)
                capabilities.SetCapability("appWaitActivity", string.Join(",", AppWaitActivities));

            capabilities.SetCapability("appWaitDuration", TimeSpan.FromSeconds(AppWaitDurationInSec).TotalMilliseconds);
            capabilities.SetCapability("deviceReadyTimeout", DeviceReadyTimeoutInSec);

            capabilities.SetCapability("androidInstallTimeout", AndroidDeviceReadyTimeoutInSec);
            capabilities.SetCapability("androidInstallTimeout", TimeSpan.FromSeconds(AndroidInstallTimeoutInSec).TotalMilliseconds);

            if (AndroidInstallPath != default(string))
                capabilities.SetCapability("androidInstallPath", AndroidInstallPath);

            return capabilities;
        }
    }
}
