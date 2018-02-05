namespace QAutomation.Appium.Engine
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Support.UI;
    using QAutomation.Core;
    using QAutomation.Core.Interfaces.Controls;
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

        public TElement Find<TElement>(ISearchContext searchContext, Core.By by)
            where TElement : IElement
        {
            var element = searchContext.FindElement(by.ToNativeBy());
            var resolvedElement = Resolve<TElement>(searchContext, element);

            return resolvedElement;
        }

        public IEnumerable<TElement> FindAll<TElement>(ISearchContext searchContext, Core.By by)
            where TElement : IElement
        {
            var elements = searchContext.FindElements(by.ToNativeBy());
            var resolvedElements = new List<TElement>();

            foreach (var element in elements)
                resolvedElements.Add(Resolve<TElement>(searchContext, element));

            return resolvedElements;
        }

        public TElement Resolve<TElement>(ISearchContext searchContext, IWebElement element)
            where TElement : IElement
        {
            var resolved = _unityContainer.Resolve<TElement>(new ResolverOverride[]
            {
                new ParameterOverride("driver", searchContext),
                new ParameterOverride("element", element),
                new ParameterOverride("container", _unityContainer)
            });

            return resolved;
        }

        public TElement NewResolve<TElement>(ISearchContext searchContext, IWebElement element)
          where TElement : IUiObject
        {
            var resolved = _unityContainer.Resolve<TElement>(new ResolverOverride[]
            {
                new ParameterOverride("context", searchContext),
                new ParameterOverride("element", element),
                new ParameterOverride("container", _unityContainer)
            });

            return resolved;
        }

        public IEnumerable<TUiObject> FindAll<TUiObject>(ISearchContext searchContext, Locator locator)
            where TUiObject : IUiObject
        {
            var elements = searchContext.FindElements(locator.ToNativeBy());
            var resolved = new List<TUiObject>();

            foreach (var element in elements)
                resolved.Add(NewResolve<TUiObject>(searchContext, element));

            return resolved;
        }
        public TUiObject Find<TUiObject>(ISearchContext searchContext, Locator locator)
            where TUiObject : IUiObject
        {
            var element = searchContext.FindElement(locator.ToNativeBy());
            var resolved = NewResolve<TUiObject>(searchContext, element);

            return resolved;
        }
    }
}
