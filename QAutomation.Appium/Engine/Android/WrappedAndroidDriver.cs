namespace QAutomation.Appium.Engine.Android
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Android;
    using QAutomation.Appium.Configs;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Interfaces.Mobile;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using Unity;

    public partial class WrappedAndroidDriver : IMobileDriver
    {
        private AndroidDriverConfig _config;
        private AndroidDriver<AndroidElement> _nativeDriver;

        private ElementFinderService _elementFinderService;

        public AndroidDriverConfig Config => _config;
        public AndroidDriver<AndroidElement> WrappedDriver => _nativeDriver;

        public WrappedAndroidDriver(AndroidDriver<AndroidElement> nativeDriver, AndroidDriverConfig config, IUnityContainer container)
        {
            _config = config;
            _nativeDriver = nativeDriver;
            _elementFinderService = new ElementFinderService(container);
        }

        private void SetImplicitWaitTimeout(double timeoutInSec)
            => _nativeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSec);

        private void ResetImplicitWaitTimeout()
        {
            //var timeouts = _nativeDriver.Manage().Timeouts();

            //if (timeouts.ImplicitWait.TotalSeconds != _config.ImplicitWaitTimeoutInSec)
            SetImplicitWaitTimeout(_config.ImplicitWaitTimeoutInSec);
        }

        private TUiObject Find<TUiObject>(Func<ISearchContext, Locator, TUiObject> finderFunc, Locator locator, ILogger log, double timeoutInSec = -1)
            where TUiObject : IUiElement
        {
            log?.DEBUG($"Find element with locator = {locator}.");

            try
            {
                if (timeoutInSec > -1)
                    SetImplicitWaitTimeout(timeoutInSec);

                var element = finderFunc.Invoke(_nativeDriver, locator);
                log?.INFO($"Element with locator = '{locator}' successfully found.");

                return element;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding elment with locator = {locator}.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
            finally { ResetImplicitWaitTimeout(); }
        }

        private IEnumerable<TUiObject> FindAll<TUiObject>(Func<ISearchContext, Locator, IEnumerable<TUiObject>> finderFunc, Locator locator, ILogger log, double timeoutInSec = -1)
          where TUiObject : IUiElement
        {
            log?.DEBUG($"Find elements with locator = {locator}.");

            try
            {
                if (timeoutInSec > -1)
                    SetImplicitWaitTimeout(timeoutInSec);

                var elements = finderFunc.Invoke(_nativeDriver, locator);
                log?.INFO($"Elements with locator = '{locator}' successfully found.");

                return elements;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding elments with locator = {locator}.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
            finally { ResetImplicitWaitTimeout(); }
        }
    }
}
