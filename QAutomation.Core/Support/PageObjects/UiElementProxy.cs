namespace QAutomation.Core.Support.PageObjects
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
                {
                    _cachedElement = Parent != null
                        ? Locator.LocateElementInParent<T>(Parent, Locators)
                        : Locator.LocateElement<T>(Locators);
                }

                return _cachedElement;
            }
        }

        public UiElementProxy(Type classToProxy, IEnumerable<Locator> locators, IUiElementLocator locator, bool cache, IUiElement parent = null)
           : base(classToProxy, locators, locator, cache, parent) { }

        public static object CreateProxy(Type classToProxy, IEnumerable<Locator> locators, IUiElementLocator locator, bool cache, IUiElement parent = null)
            => new UiElementProxy<T>(classToProxy, locators, locator, cache, parent).GetTransparentProxy();

        public override IMessage Invoke(IMessage msg) => InvokeMethod(msg as IMethodCallMessage, Element);
    }
}
