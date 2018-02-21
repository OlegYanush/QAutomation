namespace QAutomation.Core.Support.PageObjects
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Messaging;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;

    internal class UiElementListProxy<T> : UiObjectProxy where T : IUiElement
    {
        private List<T> _collection = null;

        public List<T> Elements
        {
            get
            {
                if (!Cache || _collection == null)
                    _collection = new List<T>(Locator.LocateElements<T>(Locators));

                return _collection;
            }
        }

        internal UiElementListProxy(Type classToProxy, IEnumerable<Locator> locators, IUiElementLocator locator, bool cache, IUiElement parent = null)
            : base(classToProxy, locators, locator, cache, parent) { }

        public static object CreateProxy(Type classToProxy, IEnumerable<Locator> locators, IUiElementLocator locator, bool cache, IUiElement parent = null)
            => new UiElementListProxy<T>(classToProxy, locators, locator, cache, parent).GetTransparentProxy();

        public override IMessage Invoke(IMessage msg) => InvokeMethod(msg as IMethodCallMessage, Elements);
    }
}
