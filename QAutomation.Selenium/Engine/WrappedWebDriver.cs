namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using QAutomation.Selenium.Configs;
    using System;
    using Unity;

    public partial class WrappedWebDriver : IBrowserDriver
    {
        private WebDriverConfig _config;
        private IWebDriver _wrappedDriver;

        private Core.Interfaces.IWindow _currentWindow;
        private ElementFinderService _elementFinderService;

        public IBrowserDriverConfig Config => _config;
        public IWebDriver WrappedDriver => _wrappedDriver;

        public WrappedWebDriver(WebDriverConfig config, IElementResolver resolver)
        {
            _config = config;
            _wrappedDriver = _config.CreateDriver();

            _currentWindow = new BrowserWindow(_wrappedDriver);
            _elementFinderService = new ElementFinderService(resolver);
        }

        public IUiElement Find(Locator locator, ILogger log) => Find<IUiElement>(locator, log);
    }
}
