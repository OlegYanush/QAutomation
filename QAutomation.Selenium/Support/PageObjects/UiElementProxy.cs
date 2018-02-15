namespace QAutomation.Selenium.Support.PageObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;

    internal class UiElementProxy<T> : UiObjectProxy where T : IUiElement
    {
        private T _cachedElement;

        public T Element
        {
            get
            {
                if (!Cache || _cachedElement == null)
                    _cachedElement = Locator.LocateElement<T>(Locators);

                return _cachedElement;
            }
        }

        public UiElementProxy(Type classToProxy, IEnumerable<Locator> locators, IUiElementLocator locator, bool cache)
           : base(classToProxy, locators, locator, cache) { }

        public static object CreateProxy(Type classToProxy, IEnumerable<Locator> locators, IUiElementLocator locator, bool cache)
            => new UiElementProxy<T>(classToProxy, locators, locator, cache).GetTransparentProxy();

        public override IMessage Invoke(IMessage msg)
        {
            return InvokeMethod(msg as IMethodCallMessage, Element);
        }
    }
}
