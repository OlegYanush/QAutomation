namespace QAutomation.Selenium.Configs
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core.Enums;

    public class FirefoxDriverConfig : WebDriverConfig
    {
        public override Browsers Browser => Browsers.Firefox;

        public override IWebDriver CreateLocalDriver()
        {
            FirefoxDriverService service;
            string path = Environment.GetEnvironmentVariable("webdriver.gecko.driver", EnvironmentVariableTarget.Machine);
            if (path != null)
                service = FirefoxDriverService.CreateDefaultService(path);
            else
                service = FirefoxDriverService.CreateDefaultService();

            service.HideCommandPromptWindow = true;

            var ops = new FirefoxOptions { Profile = CreateProfile() };
            ops.SetPreference("security.enterprise_roots.enabled", true);

            var driver = new FirefoxDriver(service, ops, TimeSpan.FromSeconds(Timeouts.HttpCommandTimeout));
            ProcessID = service.ProcessId;

            return driver;
        }

        public override IWebDriver CreateRemoteDriver()
        {
            var ops = new FirefoxOptions { Profile = CreateProfile() };
            ops.SetPreference("security.enterprise_roots.enabled", true);

            return new RemoteWebDriver(GridUri, ops.ToCapabilities(), TimeSpan.FromSeconds(Timeouts.HttpCommandTimeout));
        }

        private FirefoxProfile CreateProfile()
        {
            FirefoxProfile profile = new FirefoxProfile
            {
                EnableNativeEvents = true,
                DeleteAfterUse = true,
                AcceptUntrustedCertificates = true
            };

            if (Proxy != null || ProxyAutoConfigUrl != null)
            {
                profile.SetPreference("network.proxy.no_proxies_on", "localhost, 127.0.0.1");

                if (ProxyAutoConfigUrl != null)
                {
                    profile.SetPreference("network.proxy.type", 2);
                    profile.SetPreference("network.proxy.autoconfig_url", ProxyAutoConfigUrl);
                }
                if (Proxy != null)
                {
                    profile.SetPreference("network.proxy.type", 1);

                    profile.SetPreference("network.proxy.http", Proxy);
                    profile.SetPreference("network.proxy.ssl", Proxy);
                }
            }

            return profile;
        }
    }
}
