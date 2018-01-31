namespace QAutomation.Appium.Engine
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium;
    using QAutomation.Core.Interfaces.Controls;
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
            where TElement : class, IElement
        {
            var element = searchContext.FindElement(by.ToAppiumBy());
            var resolvedElement = Resolve<TElement>(searchContext, element);

            return resolvedElement;
        }

        public IEnumerable<TElement> FindAll<TElement>(ISearchContext searchContext, Core.By by)
            where TElement : class, IElement
        {
            var elements = searchContext.FindElements(by.ToAppiumBy());
            var resolvedElements = new List<TElement>();

            foreach (var element in elements)
                resolvedElements.Add(Resolve<TElement>(searchContext, element));

            return resolvedElements;
        }

        public TElement Resolve<TElement>(ISearchContext searchContext, IWebElement element)
            where TElement : class, IElement
        {
            var resolved = _unityContainer.Resolve<TElement>(new ResolverOverride[]
            {
                new ParameterOverride("driver", searchContext),
                new ParameterOverride("element", element),
                new ParameterOverride("container", _unityContainer)
            });

            return resolved;
        }
    }
}
