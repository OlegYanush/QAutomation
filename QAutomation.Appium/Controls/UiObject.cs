namespace QAutomation.Appium.Controls
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using QAutomation.Appium.Engine;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Unity;

    public class UiObject : IUiElement
    {
        protected IWebElement _wrappedElement;
        protected ElementFinderService _elementFinderService;

        public string Name { get; set; }

        public string Tag => _wrappedElement.TagName;
        public string Content => _wrappedElement.Text;

        public IWebElement WrappedElement => _wrappedElement;

        public bool Displayed => _wrappedElement.Displayed;
        public bool Enabled => _wrappedElement.Enabled;

        public Size Size => _wrappedElement.Size;
        public Point Location => _wrappedElement.Location;

        public UiObject(IWebElement element, IUnityContainer container)
        {
            _wrappedElement = element;
            _elementFinderService = new ElementFinderService(container);
        }

        public TUiObject Find<TUiObject>(Locator locator, ILogger log) where TUiObject : IUiElement
        {
            return _elementFinderService.Find<TUiObject>(_wrappedElement, locator);
        }
        public IEnumerable<TUiObject> FindAll<TUiObject>(Locator locator, ILogger log) where TUiObject : IUiElement
        {
            return _elementFinderService.FindAll<TUiObject>(_wrappedElement, locator);
        }

        public void Focus(ILogger log)
        {
            log?.DEBUG($"Set focus on element with name = '{Name}'.");
            try
            {
                var remoteWebDriver = (_wrappedElement as RemoteWebElement).WrappedDriver;
                new Actions(remoteWebDriver).MoveToElement(_wrappedElement).Perform();

                log?.DEBUG($"Setting focus on element with name = '{Name}' successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during setting focus on element with name = '{Name}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
        public string GetAttribute(string attribute, ILogger log)
        {
            log?.DEBUG($"Get value for attribute with name = '{attribute}'.");

            try
            {
                var attributeValue = _wrappedElement.GetAttribute(attribute);
                log?.DEBUG($"Getting value for attribute with name successfully completed. Value = '{attributeValue}'.");

                return attributeValue;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during getting value for attribute with name = '{attribute}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public TUiObject Find<TUiObject>(Locator locator, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
        {
            log?.DEBUG($"Find child element with locator {locator}.");

            TimeSpan defaultImplicitTimeout = TimeSpan.Zero;
            IWebDriver remoteWebDriver = null;

            try
            {
                if (timeoutInSec > -1)
                {
                    remoteWebDriver = (_wrappedElement as RemoteWebElement).WrappedDriver;
                    defaultImplicitTimeout = remoteWebDriver.Manage().Timeouts().ImplicitWait;

                    remoteWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSec);
                }

                var element = _elementFinderService.Find<TUiObject>(_wrappedElement, locator);
                log?.DEBUG($"Finding child element with locator {locator} successfully completed.");

                return element;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding child element with locator {locator}.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
            finally
            {
                if (timeoutInSec > -1)
                    remoteWebDriver.Manage().Timeouts().ImplicitWait = defaultImplicitTimeout;
            }
        }
        public IEnumerable<TUiObject> FindAll<TUiObject>(Locator locator, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
        {
            log?.DEBUG($"Find child elements with locator {locator}.");

            TimeSpan defaultImplicitTimeout = TimeSpan.Zero;
            IWebDriver remoteWebDriver = null;

            try
            {
                if (timeoutInSec > -1)
                {
                    remoteWebDriver = (_wrappedElement as RemoteWebElement).WrappedDriver;
                    defaultImplicitTimeout = remoteWebDriver.Manage().Timeouts().ImplicitWait;

                    remoteWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSec);
                }

                var elements = _elementFinderService.FindAll<TUiObject>(_wrappedElement, locator);
                log?.DEBUG($"Finding child elements with locator {locator} successfully completed.");

                return elements;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding childs element with locator {locator}.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
            finally
            {
                if (timeoutInSec > -1)
                    remoteWebDriver.Manage().Timeouts().ImplicitWait = defaultImplicitTimeout;
            }
        }
    }
}
