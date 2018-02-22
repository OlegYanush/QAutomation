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
                var wrappedDriver = (searchContext as RemoteWebDriver) ?? (searchContext as RemoteWebElement).WrappedDriver;

                return _resolver.Resolve<TUiElement>(wrappedDriver, finded);
            }
            catch (NoSuchElementException ex)
            {
                throw new UiElementNotFoundException($"Element with locator '{locator}' not found.", ex);
            }
        }

        public IEnumerable<TUiElement> FindAll<TUiElement>(ISearchContext searchContext, Locator locator)
            where TUiElement : IUiElement
        {
            List<TUiElement> elements = new List<TUiElement>();

            var finded = searchContext.FindElements(locator.ToNativeBy());
            var wrappedDriver = (searchContext as RemoteWebDriver) ?? (searchContext as RemoteWebElement).WrappedDriver;

            foreach (var element in finded)
                elements.Add(_resolver.Resolve<TUiElement>(wrappedDriver, element));

            return elements;
        }
    }
}
