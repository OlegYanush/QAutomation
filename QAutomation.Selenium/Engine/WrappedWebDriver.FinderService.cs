namespace QAutomation.Selenium.Engine
{
    using QAutomation.Core.Configuration;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logger;
    using QAutomation.Selenium.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class WrappedWebDriver : IUiElementFinderService
    {
        public TUiElement Find<TUiElement>(Locator locator, ILogger log) where TUiElement : IUiElement
        {
            log?.DEBUG($"Find element by locator '{locator}'.");
            try
            {
                var element = _elementFinderService.Find<TUiElement>(_wrappedDriver, locator);
                log?.INFO($"Element by locator '{locator}' successfully found.");

                return element;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during finding element by locator '{locator}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public TUiElement Find<TUiElement>(Locator locator, ILogger log, double timeoutInSec) where TUiElement : IUiElement
        {
            log?.DEBUG($"Set implicit wait to {timeoutInSec} second(s).");
            try
            {
                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(timeoutInSec));
                return Find<TUiElement>(locator, log);
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                log?.DEBUG($"Reset implicit wait to {defaultTimeout} second(s).");

                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));
            }
        }

        public IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log) where TUiElement : IUiElement
        {
            log?.DEBUG($"Find elements by locator '{locator}'.");
            try
            {
                var elements = _elementFinderService.FindAll<TUiElement>(_wrappedDriver, locator);
                log?.INFO($"Elements by locator '{locator}' successfully found.");

                return elements;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during finding elements by locator '{locator}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log, double timeoutInSec) where TUiElement : IUiElement
        {
            log?.DEBUG($"Set implicit wait to {timeoutInSec} second(s).");
            try
            {
                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(timeoutInSec));
                return FindAll<TUiElement>(locator, log);
            }
            finally
            {
                var defaultTimeout = TimeoutSettingsProvider.Settings.ImplicitWait;
                log?.DEBUG($"Reset implicit wait to {defaultTimeout} second(s).");

                _wrappedDriver.SetImplicitWait(TimeSpan.FromSeconds(defaultTimeout));
            }
        }

        public TUiElement FindElementByClassName<TUiElement>(string className, ILogger log) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.ClassName(className), log);

        public TUiElement FindElementByClassName<TUiElement>(string className, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.ClassName(className), log, timeoutInSec);

        public TUiElement FindElementByCssSelector<TUiElement>(string cssSelector, ILogger log) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.CssSelector(cssSelector), log);

        public TUiElement FindElementByCssSelector<TUiElement>(string cssSelector, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.CssSelector(cssSelector), log, timeoutInSec);

        public TUiElement FindElementById<TUiElement>(string id, ILogger log) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.Id(id), log);

        public TUiElement FindElementById<TUiElement>(string id, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.Id(id), log, timeoutInSec);

        public TUiElement FindElementByLinkText<TUiElement>(string linkText, ILogger log) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.LinkText(linkText), log);

        public TUiElement FindElementByLinkText<TUiElement>(string linkText, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.LinkText(linkText), log, timeoutInSec);

        public TUiElement FindElementByName<TUiElement>(string name, ILogger log) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.Name(name), log);

        public TUiElement FindElementByName<TUiElement>(string name, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.Name(name), log, timeoutInSec);

        public TUiElement FindElementByPartialLinkText<TUiElement>(string partialLinkText, ILogger log) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.PartialLinkText(partialLinkText), log);

        public TUiElement FindElementByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.PartialLinkText(partialLinkText), log, timeoutInSec);

        public TUiElement FindElementByTagName<TUiElement>(string tagName, ILogger log) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.TagName(tagName), log);


        public TUiElement FindElementByTagName<TUiElement>(string tagName, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.TagName(tagName), log, timeoutInSec);

        public TUiElement FindElementByXPath<TUiElement>(string xpath, ILogger log) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.XPath(xpath), log);

        public TUiElement FindElementByXPath<TUiElement>(string xpath, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => Find<TUiElement>(Locator.XPath(xpath), log, timeoutInSec);

        public IEnumerable<TUiElement> FindElementsByClassName<TUiElement>(string className, ILogger log) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.ClassName(className), log);

        public IEnumerable<TUiElement> FindElementsByClassName<TUiElement>(string className, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.ClassName(className), log, timeoutInSec);

        public IEnumerable<TUiElement> FindElementsByCssSelector<TUiElement>(string cssSelector, ILogger log) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.CssSelector(cssSelector), log);

        public IEnumerable<TUiElement> FindElementsByCssSelector<TUiElement>(string cssSelector, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.CssSelector(cssSelector), log, timeoutInSec);

        public IEnumerable<TUiElement> FindElementsById<TUiElement>(string id, ILogger log) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.Id(id), log);

        public IEnumerable<TUiElement> FindElementsById<TUiElement>(string id, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.Id(id), log, timeoutInSec);

        public IEnumerable<TUiElement> FindElementsByLinkText<TUiElement>(string linkText, ILogger log) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.LinkText(linkText), log);

        public IEnumerable<TUiElement> FindElementsByLinkText<TUiElement>(string linkText, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.LinkText(linkText), log, timeoutInSec);

        public IEnumerable<TUiElement> FindElementsByName<TUiElement>(string name, ILogger log) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.Name(name), log);

        public IEnumerable<TUiElement> FindElementsByName<TUiElement>(string name, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.Name(name), log, timeoutInSec);

        public IEnumerable<TUiElement> FindElementsByPartialLinkText<TUiElement>(string partialLinkText, ILogger log) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.PartialLinkText(partialLinkText), log);

        public IEnumerable<TUiElement> FindElementsByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.PartialLinkText(partialLinkText), log, timeoutInSec);

        public IEnumerable<TUiElement> FindElementsByTagName<TUiElement>(string tagName, ILogger log) where TUiElement : IUiElement
             => FindAll<TUiElement>(Locator.TagName(tagName), log);

        public IEnumerable<TUiElement> FindElementsByTagName<TUiElement>(string tagName, ILogger log, int timeoutInSec) where TUiElement : IUiElement
             => FindAll<TUiElement>(Locator.TagName(tagName), log, timeoutInSec);

        public IEnumerable<TUiElement> FindElementsByXPath<TUiElement>(string xpath, ILogger log) where TUiElement : IUiElement
             => FindAll<TUiElement>(Locator.XPath(xpath), log);

        public IEnumerable<TUiElement> FindElementsByXPath<TUiElement>(string xpath, ILogger log, int timeoutInSec) where TUiElement : IUiElement
            => FindAll<TUiElement>(Locator.XPath(xpath), log, timeoutInSec);
    }
}
