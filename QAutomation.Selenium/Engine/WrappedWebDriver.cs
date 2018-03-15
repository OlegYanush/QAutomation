namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using QAutomation.Selenium.Configs;
    using QAutomation.Xium.Shared;
    using System;

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

        public void SetImplicitWait(double timeoutInSec, ILogger log)
        {
            log?.TRACE($"Set implicit wait timeout to {timeoutInSec} second(s).");
            WrappedDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSec);
        }

        public IUiElement Find(Locator locator, ILogger log) => Find<IUiElement>(locator, log);

        public TUiElement TryFindInParent<TUiElement>(Locator locator, double searchTimeoutInSec, ILogger log)
            where TUiElement : class, IUiElement
        {
            log?.TRACE($"Try find element by locator {locator} with search timeout {searchTimeoutInSec} second(s).");
            try
            {
                SetImplicitWait(searchTimeoutInSec, log);

                var finded = _elementFinderService.Find<TUiElement>(WrappedDriver, locator);
                log?.TRACE($"Element by locator {locator} successfully found.");

                return finded;
            }
            catch (StaleElementReferenceException) { throw; }
            catch (Exception ex)
            {
                log?.TRACE($"Element by locator {locator} not found.", ex);
                return null;
            }
            finally { SetImplicitWait(Config.Timeouts.ImplicitWait, log); }
        }

        public TUiElement TryFindInParent<TUiElement>(IUiElement parent, Locator locator, double searchTimeoutInSec, ILogger log)
            where TUiElement : class, IUiElement
        {
            log?.TRACE($"Try find element by locator {locator} in parent {parent} with search timeout {searchTimeoutInSec} second(s).");
            try
            {
                SetImplicitWait(searchTimeoutInSec, log);

                var finded = parent.Find<TUiElement>(locator, log);
                log?.TRACE($"Element by locator {locator} in parent {parent} successfully found.");

                return finded;
            }
            catch (StaleElementReferenceException) { throw; }
            catch (Exception ex)
            {
                log?.TRACE($"Element by locator {locator} in parent {parent} not found.", ex);
                return null;
            }
            finally { SetImplicitWait(Config.Timeouts.ImplicitWait, log); }
        }
    }
}
