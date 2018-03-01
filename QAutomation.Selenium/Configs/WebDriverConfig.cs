namespace QAutomation.Selenium.Configs
{
    using OpenQA.Selenium;
    using QAutomation.Core.Configuration;
    using QAutomation.Core.Enums;
    using QAutomation.Core.Interfaces;
    using System;

    public abstract class WebDriverConfig : IBrowserDriverConfig
    {
        public int ProcessID { get; set; }

        public abstract Browsers Browser { get; }
        public string Version { get; set; } = "any";

        public int Height { get; set; } = -1;
        public int Width { get; set; } = -1;

        public bool IsJavaScriptEnabled { get; set; } = true;
        public bool MakeScreenshotOnFail { get; set; } = true;

        public bool IsHighlight { get; set; } = false;

        public string Proxy { get; set; }
        public string ProxyAutoConfigUrl { get; set; }

        public TimeoutSettings Timeouts { get; set; }

        public bool UseGrid { get; set; }
        public Uri GridUri { get; set; }

        public IWebDriver CreateDriver()
        {
            var driver = UseGrid
                ? CreateRemoteDriver()
                : CreateLocalDriver();

            if (Width == -1 && Height == -1)
            {
                if (Browser == Browsers.Firefox)
                {
                    driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
                    driver.Manage().Window.Position = new System.Drawing.Point(0, 0);
                }
                else
                    driver.Manage().Window.Maximize();
            }
            else if (Width > 0 && Height > 0)
            {
                driver.Manage().Window.Size = new System.Drawing.Size(Width, Height);
                driver.Manage().Window.Position = new System.Drawing.Point(0, 0);
            }

            if (IsJavaScriptEnabled)
                driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(Timeouts.JavaScriptTimeout);

            return driver;
        }

        public abstract IWebDriver CreateLocalDriver();
        public abstract IWebDriver CreateRemoteDriver();

        public Proxy GetProxy()
        {
            if (Proxy != null || ProxyAutoConfigUrl != null)
            {
                var proxy = new Proxy();
                proxy.AddBypassAddresses("localhost", "127.0.0.1");

                if (ProxyAutoConfigUrl != null)
                {
                    proxy.Kind = ProxyKind.ProxyAutoConfigure;
                    proxy.ProxyAutoConfigUrl = ProxyAutoConfigUrl;
                }
                if (Proxy != null)
                {
                    proxy.Kind = ProxyKind.Manual;
                    proxy.HttpProxy = Proxy;
                    proxy.SslProxy = Proxy;
                }
                return proxy;
            }
            return null;
        }

        public override string ToString()
        {
            string baseFormat = $"{Browser}{(Version != null ? $"({Version})" : string.Empty)}";

            return Width != -1 && Height != -1
                ? $"{baseFormat} {Width}x{Height}"
                : baseFormat;
        }
    }
}
