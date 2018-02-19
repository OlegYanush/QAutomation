namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Configuration;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logger;
    using QAutomation.Selenium.Engine;
    using QAutomation.Selenium.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    public class UiElement : IUiElement
    {
        protected IWebDriver _wrappedDriver;
        protected IWebElement _wrappedElement;

        protected ElementFinderService _elementFinderService;

        public Locator Locator { get; private set; }

        public IWebDriver WrappedDriver => _wrappedDriver;
        public IWebElement WrappedElement => _wrappedElement;

        public string Tag => _wrappedElement.TagName;
        public string Content => _wrappedElement.Text;

        public bool Enabled => _wrappedElement.Enabled;
        public bool Displayed => _wrappedElement.Displayed;

        public Size Size => _wrappedElement.Size;
        public Point Location => _wrappedElement.Location;

        public UiElement(IWebDriver driver, IWebElement element, IElementResolver resolver, Locator locator)
        {
            Locator = locator;

            _wrappedDriver = driver;
            _wrappedElement = element;
           
            _elementFinderService = new ElementFinderService(resolver);
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

        protected TUiElement Find<TUiElement>(ISearchContext context, Locator locator, ILogger log)
            where TUiElement : IUiElement
        {
            log?.DEBUG($"Find child element with locator '{locator}'.");

            try
            {
                var element = _elementFinderService.Find<TUiElement>(context, locator);
                log?.INFO($"Child element by locator '{locator}' successfully found.");

                return element;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding child element by locator '{locator}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
        protected IEnumerable<TUiElement> FindAll<TUiElement>(ISearchContext context, Locator locator, ILogger log) where TUiElement : IUiElement
        {
            log?.DEBUG($"Find child elements with locator '{locator}'.");

            try
            {
                var elements = _elementFinderService.FindAll<TUiElement>(context, locator);
                log?.INFO($"Child elements by locator '{locator}' successfully found.");

                return elements;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding child elements by locator '{locator}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }


        public virtual TUiElement Find<TUiElement>(Locator locator, ILogger log)
            where TUiElement : IUiElement => Find<TUiElement>(_wrappedElement, locator, log);

        public virtual IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log)
            where TUiElement : IUiElement => FindAll<TUiElement>(_wrappedElement, locator, log);


        public TUiElement Find<TUiElement>(Locator locator, ILogger log, double timeoutInSec) where TUiElement : IUiElement
        {
            try
            {
                log?.DEBUG($"Set implicit timeout = {timeoutInSec} second(s)");
                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(timeoutInSec));

                return Find<TUiElement>(locator, log);
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                log?.DEBUG($"Reset implicit timeout to {defaultTimeout} second(s).");

                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));
            }
        }
        public IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log, double timeoutInSec) where TUiElement : IUiElement
        {
            try
            {
                log?.DEBUG($"Set implicit timeout = {timeoutInSec} second(s)");
                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(timeoutInSec));

                return FindAll<TUiElement>(locator, log);
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                log?.DEBUG($"Reset implicit timeout to {defaultTimeout} second(s).");

                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));
            }
        }
    }
}
