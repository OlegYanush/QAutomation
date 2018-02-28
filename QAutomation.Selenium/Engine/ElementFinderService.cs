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

        public TUiElement Find<TUiElement>(ISearchContext searchContext, Locator locator)
         where TUiElement : IUiElement
        {
            try
            {
                var finded = searchContext.FindElement(locator.ToNativeBy());
                var wrappedDriver = GetRemoteWebDriver(searchContext);

                return _resolver.Resolve<TUiElement>(wrappedDriver, finded);
            }
            catch (NoSuchElementException ex)
            {
                throw new UiElementNotFoundException($"Element by locator {locator} not found.", ex);
            }
        }

        public IEnumerable<TUiElement> FindAll<TUiElement>(ISearchContext searchContext, Locator locator)
            where TUiElement : IUiElement
        {
            List<TUiElement> elements = new List<TUiElement>();

            var finded = searchContext.FindElements(locator.ToNativeBy());
            var wrappedDriver = GetRemoteWebDriver(searchContext);

            foreach (var element in finded)
                elements.Add(_resolver.Resolve<TUiElement>(wrappedDriver, element));

            return elements;
        }

        private IWebDriver GetRemoteWebDriver(ISearchContext context)
            => (context as RemoteWebDriver) ?? (context as RemoteWebElement).WrappedDriver;
    }
}
