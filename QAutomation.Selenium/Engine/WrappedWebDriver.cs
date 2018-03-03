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

        public TUiElement TryFind<TUiElement>(Locator locator, double searchTimeoutInSec, ILogger log)
            where TUiElement : IUiElement
        {
            log?.TRACE($"Try find element by locator {locator} with search timeout {searchTimeoutInSec} second(s).");
            try
            {
                log?.TRACE($"Set implicit wait timeout to {searchTimeoutInSec} second(s).");
                WrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(searchTimeoutInSec));

                var finded = _elementFinderService.Find<TUiElement>(WrappedDriver, locator);
                log?.DEBUG($"Element by locator {locator} successfully found.");

                return finded;
            }
            catch (StaleElementReferenceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                log?.TRACE($"Element by locator {locator} not found.", ex);
                return default(TUiElement);
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                WrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));

                log?.TRACE($"Reset implicit wait timeout to {defaultTimeout} second(s).");
            }
        }

        public TUiElement TryFindInParent<TUiElement>(IUiElement parent, Locator locator, double searchTimeoutInSec, ILogger log)
            where TUiElement : IUiElement
        {
            log?.TRACE($"Try find element by locator {locator} in parent {parent} with search timeout {searchTimeoutInSec} second(s).");
            try
            {
                log?.TRACE($"Set implicit wait timeout to {searchTimeoutInSec} second(s).");
                WrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(searchTimeoutInSec));

                var finded = parent.Find<TUiElement>(locator, log);
                log?.DEBUG($"Element by locator {locator} in parent {parent} successfully found.");

                return finded;
            }
            catch (StaleElementReferenceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                log?.TRACE($"Element by locator {locator} in parent {parent} not found.", ex);
                return default(TUiElement);
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                WrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));

                log?.TRACE($"Reset implicit wait timeout to {defaultTimeout} second(s).");
            }
        }

        public TUiElement WaitForElementState<TUiElement>(Locator locator, UiElementState state, ILogger log, double timeoutInSec = 0, double poolingIntervalInSec = 0)
            where TUiElement : class, IUiElement
        {
            log?.TRACE($"Waiting state {state} for element by locator {locator}.");
            try
            {
                if (state == UiElementState.None)
                    throw new Exception($"Couldn't wait for state: {nameof(UiElementState.None)}.");

                var settings = TimeoutSettingsProvider.Settings;

                timeoutInSec = timeoutInSec == 0 ? settings.ExplicitWait : timeoutInSec;
                poolingIntervalInSec = poolingIntervalInSec == 0 ? settings.PoolingInterval : poolingIntervalInSec;

                double sleepTime = poolingIntervalInSec;
                var stopwatch = Stopwatch.StartNew();

                while (stopwatch.Elapsed.TotalMilliseconds <= timeoutInSec)
                {
                    var element = TryFind<TUiElement>(locator, poolingIntervalInSec, log);

                    if (element != null)
                    {
                        switch (state)
                        {
                            case UiElementState.Preset:
                                return element;
                            case UiElementState.Visible:
                                if (element.Displayed) return element;
                                break;
                            case UiElementState.Enabled:
                                if (element.Enabled) return element;
                                break;
                            case UiElementState.Disabled:
                                if (!element.Enabled) return element;
                                break;
                            case UiElementState.NotVisible:
                                if (!element.Displayed) return element;
                                break;
                        }
                    }
                    else if (state.HasFlag(UiElementState.Absent))
                        return element;

                    Thread.Sleep(TimeSpan.FromSeconds(sleepTime));
                }

                throw new WebDriverTimeoutException($"Timeout {timeoutInSec} reached.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during waiting {state} state for element by locator {locator}.", ex);
                throw;
            }
        }
    }
}
