namespace QAutomation.Selenium.Configs
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core.Enums;

    public class ChromeDriverConfig : WebDriverConfig
    {
        public override Browsers Browser => Browsers.Chrome;

        public override IWebDriver CreateLocalDriver()
        {
            ChromeDriverService service;

            string path = Environment.GetEnvironmentVariable("webdriver.chrome.driver", EnvironmentVariableTarget.Machine);
            if (path != null)
                service = ChromeDriverService.CreateDefaultService(path);
            else
                service = ChromeDriverService.CreateDefaultService();

            service.HideCommandPromptWindow = false;
            var options = GetOptions();

            var driver = new ChromeDriver(service, options, TimeSpan.FromSeconds(Timeouts.HttpCommandTimeout));
            ProcessID = service.ProcessId;

            return driver;
        }

        public override IWebDriver CreateRemoteDriver()
        {
            var capabilites = GetOptions().ToCapabilities();
            return new RemoteWebDriver(GridUri, capabilites, TimeSpan.FromSeconds(Timeouts.HttpCommandTimeout));
        }

        protected ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();

            options.AddUserProfilePreference("download.prompt_for_download", true);
            options.AddUserProfilePreference("download.default_directory", "NULL");

            options.AddArgument("disable-infobars");
            options.AddArgument("disable-blink-features=BlockCredentialedSubresources");

            options.Proxy = GetProxy();
            return options;
        }
    }
}
