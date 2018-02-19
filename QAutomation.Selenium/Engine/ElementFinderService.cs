namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Selenium.Extensions;
    using System;
    using System.Collections.Generic;

    public class ElementFinderService
    {
        IElementResolver _resolver;

        public ElementFinderService(IElementResolver resolver)
        {
            _resolver = resolver;
        }

        public TUiObject Find<TUiObject>(ISearchContext searchContext, Locator locator)
         where TUiObject : IUiElement
        {
            IWebElement currentElement = null;

            var currentContext = searchContext;
            Locator currentParent = locator.Parent;

            while (currentParent != null)
            {
                currentElement = currentContext.FindElement(currentParent.ToNativeBy());
                currentContext = (currentElement as ISearchContext);

                currentParent = currentParent.Parent;
            }

            currentElement = currentContext.FindElement(locator.ToNativeBy());
            var resolved = _resolver.Resolve<TUiObject>(searchContext, currentElement, locator);

            return resolved;
        }

        public TUiObject Find<TUiObject>(ISearchContext searchContext, IEnumerable<Locator> locators)
            where TUiObject : IUiElement
        {
            if (locators == null)
                throw new ArgumentNullException(nameof(locators), "List of locators may not be null");

            string errorString = null;

            foreach (var locator in locators)
            {
                try
                {
                    return Find<TUiObject>(searchContext, locator);
                }
                catch (NoSuchElementException)
                {
                    errorString = (errorString == null ? "Could not find element by: " : errorString + ", or: ") + locator;
                }
            }
            throw new NoSuchElementException(errorString);
        }

        public IEnumerable<TUiObject> FindAll<TUiObject>(ISearchContext searchContext, Locator locator)
            where TUiObject : IUiElement
        {
            var elements = searchContext.FindElements(locator.ToNativeBy());
            var resolved = new List<TUiObject>();

            foreach (var element in elements)
                resolved.Add(_resolver.Resolve<TUiObject>(searchContext, element, locator));

            return resolved;
        }

        public IEnumerable<TUiObject> FindAll<TUiObject>(ISearchContext searchContext, IEnumerable<Locator> locators)
          where TUiObject : IUiElement
        {
            if (locators == null)
                throw new ArgumentNullException(nameof(locators), "List of locators may not be null");

            var collection = new List<TUiObject>();

            foreach (var locator in locators)
                collection.AddRange(FindAll<TUiObject>(searchContext, locator));

            return collection;
        }
    }
}
