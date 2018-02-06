namespace QAutomation.Appium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core;
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

        public TUiObject Resolve<TUiObject>(IWebElement element) where TUiObject : IUiObject
        {
            var resolved = _unityContainer.Resolve<TUiObject>(new ResolverOverride[]
            {
                new ParameterOverride("element", element),
                new ParameterOverride("container", _unityContainer)
            });

            return resolved;
        }

        public TUiObject Find<TUiObject>(ISearchContext searchContext, Locator locator)
         where TUiObject : IUiObject
        {
            var element = searchContext.FindElement(locator.ToNativeBy());
            var resolved = Resolve<TUiObject>(element);

            return resolved;
        }

        public IEnumerable<TUiObject> FindAll<TUiObject>(ISearchContext searchContext, Locator locator)
            where TUiObject : IUiObject
        {
            var elements = searchContext.FindElements(locator.ToNativeBy());
            var resolved = new List<TUiObject>();

            foreach (var element in elements)
                resolved.Add(Resolve<TUiObject>(element));

            return resolved;
        }
    }
}
