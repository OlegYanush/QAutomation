namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Configuration;
    using QAutomation.Core.Enums;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using QAutomation.Xium.Shared;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;

    public class UiElement : IUiElement, IWraps<IWebElement>
    {
        protected Locator _locator;
        protected bool _isLocatorChanged;

        protected IWebDriver _wrappedDriver;
        protected IWebElement _wrappedElement;

        protected ElementFinderService _elementFinderService;

        public Locator Locator
        {
            get { return _locator; }
            set
            {
                if (!_locator.Equals(value))
                {
                    _locator = value;
                    _isLocatorChanged = true;
                }
            }
        }
        public string Description { get; set; }

        public IWebDriver WrappedDriver => _wrappedDriver;
        public IWebElement Wrapped => _wrappedElement;

        public string Tag => _wrappedElement.TagName;
        public string Content => _wrappedElement.Text;

        public UiElementState State
        {
            get
            {
                var accumulator = UiElementState.None;

                if (Wrapped == null)
                    accumulator |= UiElementState.Absent;
                else
                {
                    accumulator |= UiElementState.Present;
                    accumulator |= (Wrapped.Displayed ? UiElementState.Visible : UiElementState.NotVisible);
                    accumulator |= (Wrapped.Enabled ? UiElementState.Enabled : UiElementState.Disabled);
                }

                return accumulator;
            }
        }

        public Size Size => _wrappedElement.Size;
        public Point Location => _wrappedElement.Location;


        public UiElement(IWebDriver driver, IWebElement element, IElementResolver resolver, Locator locator)
        {
            _locator = locator;

            _wrappedDriver = driver;
            _wrappedElement = element;

            _elementFinderService = new ElementFinderService(resolver);
        }

        public UiElement(IWebDriver driver, IWebElement element, IElementResolver resolver, Locator locator, string description)
            : this(driver, element, resolver, locator)
        {
            Description = description;
        }

        public string GetAttribute(string attribute, ILogger log)
        {
            log?.TRACE($"Get value for attribute with name = '{attribute}'.");

            try
            {
                var attributeValue = _wrappedElement.GetAttribute(attribute);
                log?.TRACE($"Getting value for attribute with name = '{attribute}' successfully completed. Value = '{attributeValue}'.");

                return attributeValue;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during getting value for attribute with name = '{attribute}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        protected TUiElement Find<TUiElement>(ISearchContext context, Locator locator, ILogger log, string description = null)
            where TUiElement : IUiElement
        {
            log?.TRACE($"Find element by locator {locator} in parent {this}.");

            try
            {
                var element = _elementFinderService.Find<TUiElement>(context, locator, description);
                log?.TRACE($"Element by locator {locator} in parent {this} successfully found.");

                return element;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding element by locator {locator} in parent {this}.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
        protected IEnumerable<TUiElement> FindAll<TUiElement>(ISearchContext context, Locator locator, ILogger log, string description = null)
            where TUiElement : IUiElement
        {
            log?.TRACE($"Find elements by locator {locator} in parent {this}.");

            try
            {
                var elements = _elementFinderService.FindAll<TUiElement>(context, locator, description);
                log?.TRACE($"Find elements by locator {locator} in parent {this} successfully found.");

                return elements;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding elements by locator {locator} in parent {this}.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public virtual TUiElement Find<TUiElement>(Locator locator, ILogger log, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(_wrappedElement, locator, log, description);

        public virtual IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(_wrappedElement, locator, log, description);

        public TUiElement Find<TUiElement>(Locator locator, ILogger log, double timeoutInSec, string description = null)
            where TUiElement : IUiElement
        {
            try
            {
                SetImplicitWait(timeoutInSec, log);
                return Find<TUiElement>(locator, log, description);
            }
            finally { SetImplicitWait(TimeoutSettingsProvider.Settings.ImplicitWait, log); }
        }
        public IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log, double timeoutInSec, string description = null)
            where TUiElement : IUiElement
        {
            try
            {
                SetImplicitWait(timeoutInSec, log);
                return FindAll<TUiElement>(locator, log, description);
            }
            finally { SetImplicitWait(TimeoutSettingsProvider.Settings.ImplicitWait, log); }
        }

        public override string ToString()
        {
            var part = string.IsNullOrEmpty(Description)
                ? $"ui element with locator {Locator}"
                : Description;

            return $"[{part} and {GetType().Name.Split('.').Last()} type]";
        }

        private void SetImplicitWait(double timeoutInSec, ILogger log)
        {
            log?.TRACE($"Set implicit wait timeout to {timeoutInSec} second(s).");
            WrappedDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSec);
        }
    }
}
