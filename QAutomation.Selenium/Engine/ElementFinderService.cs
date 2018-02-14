namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Selenium.Extensions;
    using System;
    using System.Collections.Generic;
    using Unity;
    using Unity.Resolution;

    public class ElementFinderService
    {
        private readonly IUnityContainer _unityContainer;

        public ElementFinderService(IUnityContainer container)
        {
            _unityContainer = container;
        }

        public TUiObject Find<TUiObject>(ISearchContext searchContext, Locator locator)
         where TUiObject : IUiElement
        {
            var element = searchContext.FindElement(locator.ToNativeBy());
            var resolved = Resolve<TUiObject>(searchContext, element);

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
                resolved.Add(Resolve<TUiObject>(searchContext, element));

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

        private TUiObject Resolve<TUiObject>(ISearchContext searchContext, IWebElement element) where TUiObject : IUiElement
        {
            var resolved = _unityContainer.Resolve<TUiObject>(new ResolverOverride[]
            {
                new ParameterOverride("driver", searchContext),
                new ParameterOverride("element", element),
                new ParameterOverride("container", _unityContainer)
            });

            return resolved;
        }
    }
}
