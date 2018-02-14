namespace QAutomation.Selenium.Support.PageObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using Unity;

    internal class UiElementProxy<T> : UiObjectProxy where T : IUiElement
    {
        private T _cachedElement;

        public UiElementProxy(Type classToProxy, IEnumerable<Locator> locators, ISearchContext searchContext, IUnityContainer container, bool cache)
           : base(classToProxy, locators, searchContext, container, cache) { }

        public T Element
        {
            get
            {
                if (!Cache || _cachedElement == null)
                    _cachedElement = ElementFinderService.Find<T>(SearchContext, Locators);

                return _cachedElement;
            }
        }

        public static object CreateProxy(Type classToProxy, IEnumerable<Locator> locators, ISearchContext context, IUnityContainer container, bool cache)
            => new UiElementProxy<T>(classToProxy, locators, context, container, cache).GetTransparentProxy();

        public override IMessage Invoke(IMessage msg)
        {
            return InvokeMethod(msg as IMethodCallMessage, Element);
        }
    }
}
