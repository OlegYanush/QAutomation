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

        public TUiElement Find<TUiElement>(ISearchContext searchContext, Locator locator, IUiElement parent = null)
         where TUiElement : IUiElement
        {
            TUiElement element;

            try
            {
                if (parent != null)
                    element = parent.Find<TUiElement>(locator, null);
                else
                {
                    var finded = searchContext.FindElement(locator.ToNativeBy());
                    var wrappedDriver = (searchContext as RemoteWebDriver) ?? (searchContext as RemoteWebElement).WrappedDriver;

                    element = _resolver.Resolve<TUiElement>(wrappedDriver, finded, parent);
                }
                return element;
            }
            catch (NoSuchElementException ex)
            {
                throw new UiElementNotFoundException($"Element with locator '{locator}' not found.", ex);
            }
        }

        public IEnumerable<TUiElement> FindAll<TUiElement>(ISearchContext searchContext, Locator locator, IUiElement parent = null)
            where TUiElement : IUiElement
        {
            List<TUiElement> elements = new List<TUiElement>();

            if (parent != null)
                elements.AddRange(parent.FindAll<TUiElement>(locator, null));
            else
            {
                var finded = searchContext.FindElements(locator.ToNativeBy());
                var wrappedDriver = (searchContext as RemoteWebDriver) ?? (searchContext as RemoteWebElement).WrappedDriver;

                foreach (var element in finded)
                    elements.Add(_resolver.Resolve<TUiElement>(wrappedDriver, element, parent));
            }
            return elements;
        }
    }
}
