namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Selenium.Extensions;
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

        public TUiObject Find<TUiObject>(ISearchContext searchContexnt, Locator locator)
         where TUiObject : IUiElement
        {
            var element = searchContexnt.FindElement(locator.ToNativeBy());
            var resolved = Resolve<TUiObject>(searchContexnt, element);

            return resolved;
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
