namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Remote;
    using QAutomation.Core.Exceptions;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Selenium.Extensions;
    using System.Collections.Generic;

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
            var finded = Find(searchContext, locator);
            var wrappedDriver = GetRemoteWebDriver(searchContext);

            return _resolver.Resolve<TUiElement>(wrappedDriver, finded, locator, description);
        }

        public IWebElement Find(ISearchContext searchContext, Locator locator)
        {
            try
            {
                return searchContext.FindElement(locator.ToNativeBy());
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

            var finded = searchContext.FindElements(locator.ToNativeBy());
            var wrappedDriver = GetRemoteWebDriver(searchContext);

            foreach (var element in finded)
                elements.Add(_resolver.Resolve<TUiElement>(wrappedDriver, element, locator, description));

            return elements;
        }

        private IWebDriver GetRemoteWebDriver(ISearchContext context)
            => (context as RemoteWebDriver) ?? (context as RemoteWebElement).WrappedDriver;
    }
}
