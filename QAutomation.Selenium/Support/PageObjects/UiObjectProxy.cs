namespace QAutomation.Selenium.Support.PageObjects
{
    using QAutomation.Core.Locators;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;

    internal abstract class UiObjectProxy : RealProxy
    {
        private readonly IUiElementLocator _locator;
        private readonly IEnumerable<Locator> _locators;

        private readonly bool _cache;

        protected UiObjectProxy(Type classToProxy, IEnumerable<Locator> locators, IUiElementLocator locator, bool cache)
            : base(classToProxy)
        {
            _locator = locator;
            _locators = locators;

            _cache = cache;
        }

        protected IUiElementLocator Locator => _locator;
        protected IEnumerable<Locator> Locators => _locators;

        protected bool Cache => _cache;

        protected static ReturnMessage InvokeMethod(IMethodCallMessage msg, object representedValue)
        {
            if (msg == null)
                throw new ArgumentNullException("msg", "The message containing invocation information cannot be null");

            MethodInfo proxiedMethod = msg.MethodBase as MethodInfo;
            return new ReturnMessage(proxiedMethod.Invoke(representedValue, msg.Args), null, 0, msg.LogicalCallContext, msg);
        }
    }
}
