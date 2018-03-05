namespace QAutomation.Selenium.Engine
{
    using QAutomation.Core.Configuration;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using QAutomation.Selenium.Extensions;
    using System;
    using System.Collections.Generic;

    public partial class WrappedWebDriver : IUiElementFinderService
    {
        public TUiElement Find<TUiElement>(Locator locator, ILogger log, string description = null)
            where TUiElement : IUiElement
        {
            log?.TRACE($"Find element by locator {locator}.");
            try
            {
                var element = _elementFinderService.Find<TUiElement>(_wrappedDriver, locator, description);
                log?.TRACE($"Element by locator {locator} successfully found.");

                return element;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding element by locator {locator}.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public TUiElement Find<TUiElement>(Locator locator, ILogger log, double timeoutInSec, string description = null)
            where TUiElement : IUiElement
        {
            log?.TRACE($"Set implicit wait to {timeoutInSec} second(s).");
            try
            {
                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(timeoutInSec));
                return Find<TUiElement>(locator, log, description);
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                log?.TRACE($"Reset implicit wait to {defaultTimeout} second(s).");

                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));
            }
        }

        public IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log, string description = null)
            where TUiElement : IUiElement
        {
            log?.TRACE($"Find elements by locator {locator}.");
            try
            {
                var elements = _elementFinderService.FindAll<TUiElement>(_wrappedDriver, locator, description);
                log?.TRACE($"Elements by locator {locator} successfully found.");

                return elements;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during finding elements by locator {locator}.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log, double timeoutInSec, string description = null)
            where TUiElement : IUiElement
        {
            log?.TRACE($"Set implicit wait to {timeoutInSec} second(s).");
            try
            {
                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(timeoutInSec));
                return FindAll<TUiElement>(locator, log, description);
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                log?.TRACE($"Reset implicit wait to {defaultTimeout} second(s).");

                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));
            }
        }

        public TUiElement FindElementByClassName<TUiElement>(string className, ILogger log, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.ClassName(className), log, description);

        public TUiElement FindElementByClassName<TUiElement>(string className, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.ClassName(className), log, timeoutInSec, description);

        public TUiElement FindElementByCssSelector<TUiElement>(string cssSelector, ILogger log, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.CssSelector(cssSelector), log, description);

        public TUiElement FindElementByCssSelector<TUiElement>(string cssSelector, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.CssSelector(cssSelector), log, timeoutInSec, description);

        public TUiElement FindElementById<TUiElement>(string id, ILogger log, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.Id(id), log, description);

        public TUiElement FindElementById<TUiElement>(string id, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.Id(id), log, timeoutInSec, description);

        public TUiElement FindElementByLinkText<TUiElement>(string linkText, ILogger log, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.LinkText(linkText), log, description);

        public TUiElement FindElementByLinkText<TUiElement>(string linkText, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.LinkText(linkText), log, timeoutInSec, description);

        public TUiElement FindElementByName<TUiElement>(string name, ILogger log, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.Name(name), log, description);

        public TUiElement FindElementByName<TUiElement>(string name, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.Name(name), log, timeoutInSec, description);

        public TUiElement FindElementByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.PartialLinkText(partialLinkText), log, description);

        public TUiElement FindElementByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.PartialLinkText(partialLinkText), log, timeoutInSec, description);

        public TUiElement FindElementByTagName<TUiElement>(string tagName, ILogger log, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.TagName(tagName), log, description);


        public TUiElement FindElementByTagName<TUiElement>(string tagName, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.TagName(tagName), log, timeoutInSec, description);

        public TUiElement FindElementByXPath<TUiElement>(string xpath, ILogger log, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.XPath(xpath), log, description);

        public TUiElement FindElementByXPath<TUiElement>(string xpath, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => Find<TUiElement>(Locator.XPath(xpath), log, timeoutInSec, description);

        public IEnumerable<TUiElement> FindElementsByClassName<TUiElement>(string className, ILogger log, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.ClassName(className), log, description);

        public IEnumerable<TUiElement> FindElementsByClassName<TUiElement>(string className, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.ClassName(className), log, timeoutInSec, description);

        public IEnumerable<TUiElement> FindElementsByCssSelector<TUiElement>(string cssSelector, ILogger log, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.CssSelector(cssSelector), log, description);

        public IEnumerable<TUiElement> FindElementsByCssSelector<TUiElement>(string cssSelector, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.CssSelector(cssSelector), log, timeoutInSec, description);

        public IEnumerable<TUiElement> FindElementsById<TUiElement>(string id, ILogger log, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.Id(id), log, description);

        public IEnumerable<TUiElement> FindElementsById<TUiElement>(string id, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.Id(id), log, timeoutInSec, description);

        public IEnumerable<TUiElement> FindElementsByLinkText<TUiElement>(string linkText, ILogger log, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.LinkText(linkText), log, description);

        public IEnumerable<TUiElement> FindElementsByLinkText<TUiElement>(string linkText, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.LinkText(linkText), log, timeoutInSec, description);

        public IEnumerable<TUiElement> FindElementsByName<TUiElement>(string name, ILogger log, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.Name(name), log, description);

        public IEnumerable<TUiElement> FindElementsByName<TUiElement>(string name, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.Name(name), log, timeoutInSec, description);

        public IEnumerable<TUiElement> FindElementsByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.PartialLinkText(partialLinkText), log, description);

        public IEnumerable<TUiElement> FindElementsByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.PartialLinkText(partialLinkText), log, timeoutInSec, description);

        public IEnumerable<TUiElement> FindElementsByTagName<TUiElement>(string tagName, ILogger log, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.TagName(tagName), log, description);

        public IEnumerable<TUiElement> FindElementsByTagName<TUiElement>(string tagName, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.TagName(tagName), log, timeoutInSec, description);

        public IEnumerable<TUiElement> FindElementsByXPath<TUiElement>(string xpath, ILogger log, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.XPath(xpath), log, description);

        public IEnumerable<TUiElement> FindElementsByXPath<TUiElement>(string xpath, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement => FindAll<TUiElement>(Locator.XPath(xpath), log, timeoutInSec, description);
    }
}
