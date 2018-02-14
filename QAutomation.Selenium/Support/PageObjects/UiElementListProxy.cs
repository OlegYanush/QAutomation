namespace QAutomation.Selenium.Support.PageObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using Unity;

    internal class UiElementListProxy<T> : UiObjectProxy where T : IUiElement
    {
        private List<T> _collection = null;

        public List<T> Elements
        {
            get
            {
                if (!Cache || _collection == null)
                    _collection = new List<T>(ElementFinderService.FindAll<T>(SearchContext, Locators));

                return _collection;
            }
        }

        internal UiElementListProxy(Type classToProxy, IEnumerable<Locator> locators, ISearchContext searchContext, IUnityContainer container, bool cache)
            : base(classToProxy, locators, searchContext, container, cache) { }

        public static object CreateProxy(Type classToProxy, IEnumerable<Locator> locators, ISearchContext context, IUnityContainer container, bool cache)
            => new UiElementListProxy<T>(classToProxy, locators, context, container, cache).GetTransparentProxy();

        public override IMessage Invoke(IMessage msg)
        {
            return InvokeMethod(msg as IMethodCallMessage, Elements);
        }
    }
}
