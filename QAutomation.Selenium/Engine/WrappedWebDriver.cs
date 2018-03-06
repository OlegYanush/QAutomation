namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Configuration;
    using QAutomation.Core.Enums;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using QAutomation.Selenium.Configs;
    using QAutomation.Selenium.Extensions;
    using System;
    using System.Diagnostics;
    using System.Threading;

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

        public TUiElement TryFindInParent<TUiElement>(Locator locator, double searchTimeoutInSec, ILogger log)
            where TUiElement : class, IUiElement
        {
            log?.TRACE($"Try find element by locator {locator} with search timeout {searchTimeoutInSec} second(s).");
            try
            {
                log?.TRACE($"Set implicit wait timeout to {searchTimeoutInSec} second(s).");
                WrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(searchTimeoutInSec));

                var finded = _elementFinderService.Find<TUiElement>(WrappedDriver, locator);
                log?.TRACE($"Element by locator {locator} successfully found.");

                return finded;
            }
            catch (StaleElementReferenceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                log?.TRACE($"Element by locator {locator} not found.", ex);
                return null;
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                WrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));

                log?.TRACE($"Reset implicit wait timeout to {defaultTimeout} second(s).");
            }
        }

        public TUiElement TryFindInParent<TUiElement>(IUiElement parent, Locator locator, double searchTimeoutInSec, ILogger log)
            where TUiElement : class, IUiElement
        {
            log?.TRACE($"Try find element by locator {locator} in parent {parent} with search timeout {searchTimeoutInSec} second(s).");
            try
            {
                log?.TRACE($"Set implicit wait timeout to {searchTimeoutInSec} second(s).");
                WrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(searchTimeoutInSec));

                var finded = parent.Find<TUiElement>(locator, log);
                log?.TRACE($"Element by locator {locator} in parent {parent} successfully found.");

                return finded;
            }
            catch (StaleElementReferenceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                log?.TRACE($"Element by locator {locator} in parent {parent} not found.", ex);
                return null;
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                WrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));

                log?.TRACE($"Reset implicit wait timeout to {defaultTimeout} second(s).");
            }
        }


    }
}
