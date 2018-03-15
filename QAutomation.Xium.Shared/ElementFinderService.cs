namespace QAutomation.Xium.Shared
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core.Exceptions;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ElementFinderService
    {
        IElementResolver _resolver;

        public ElementFinderService(IElementResolver resolver)
        {
            _resolver = resolver;
        }

        public TUiElement Find<TUiElement>(ISearchContext searchContext, Locator locator, string description = null)
         where TUiElement : IUiElement
        {
            try
            {
                var finded = searchContext.FindElement(locator.ToSeleniumBy());
                var wrappedDriver = ExtractWebDriver(searchContext);

                return _resolver.Resolve<TUiElement>(wrappedDriver, finded, locator, description);
            }
            catch (NoSuchElementException ex)
            {
                throw new UiElementNotFoundException($"Element by locator {locator} not found.", ex);
            }
        }

        public IEnumerable<TUiElement> FindAll<TUiElement>(ISearchContext searchContext, Locator locator, string description = null)
            where TUiElement : IUiElement
        {
            List<TUiElement> elements = new List<TUiElement>();

            var finded = searchContext.FindElements(locator.ToSeleniumBy());
            var wrappedDriver = ExtractWebDriver(searchContext);

            foreach (var element in finded)
                elements.Add(_resolver.Resolve<TUiElement>(wrappedDriver, element, locator, description));

            return elements;
        }

        private IWebDriver ExtractWebDriver(ISearchContext context)
            => (context as RemoteWebDriver) ?? (context as RemoteWebElement).WrappedDriver;
    }
}
