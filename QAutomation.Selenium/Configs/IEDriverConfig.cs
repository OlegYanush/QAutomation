namespace QAutomation.Selenium.Configs
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.IE;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core.Enums;

    public class IEDriverConfig : WebDriverConfig
    {
        public string IEDriverServer { get; set; }

        public override Browsers Browser => Browsers.InternetExplorer;

        public IEDriverConfig() { Version = "11"; }

        public override IWebDriver CreateLocalDriver()
        {
            InternetExplorerDriverService service;
            if (IEDriverServer != null)
                service = InternetExplorerDriverService.CreateDefaultService(IEDriverServer);
            else
            {
                string path = Environment.GetEnvironmentVariable("webdriver.ie.driver", EnvironmentVariableTarget.Machine);
                if (path != null)
                    service = InternetExplorerDriverService.CreateDefaultService(path);
                else
                    service = InternetExplorerDriverService.CreateDefaultService();
            }

            var driver = new InternetExplorerDriver(service, GetOptions(), TimeSpan.FromSeconds(Timeouts.HttpCommandTimeout));
            ProcessID = service.ProcessId;

            return driver;
        }

        public override IWebDriver CreateRemoteDriver()
        {
            var options = GetOptions();

            return new RemoteWebDriver(GridUri, options.ToCapabilities(), TimeSpan.FromSeconds(Timeouts.HttpCommandTimeout));
        }

        protected InternetExplorerOptions GetOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                InitialBrowserUrl = "about:blank",
                EnableNativeEvents = true,
                EnsureCleanSession = true,
                EnablePersistentHover = false,
            };

            switch (Version)
            {
                case "9":
                case "10":
                    options.UsePerProcessProxy = false;
                    break;
                case "11":
                    options.UsePerProcessProxy = true;
                    break;
            }

            options.Proxy = GetProxy();
            return options;
        }
    }
}
