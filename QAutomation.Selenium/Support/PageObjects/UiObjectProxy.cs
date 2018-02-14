namespace QAutomation.Selenium.Support.PageObjects
{
    using OpenQA.Selenium;
    using QAutomation.Core.Locators;
    using QAutomation.Selenium.Engine;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.Remoting.Messaging;
    using System.Runtime.Remoting.Proxies;
    using Unity;

    internal abstract class UiObjectProxy : RealProxy
    {
        private readonly ElementFinderService _elementFinderService;
        private readonly IEnumerable<Locator> _locators;

        private ISearchContext _searchContext;
        private readonly bool _cache;

        protected UiObjectProxy(Type classToProxy, IEnumerable<Locator> locators, ISearchContext searchContext, IUnityContainer container, bool cache)
            : base(classToProxy)
        {
            _elementFinderService = new ElementFinderService(container);
            _searchContext = searchContext;

            _locators = locators;
            _cache = cache;
        }

        protected ElementFinderService ElementFinderService => _elementFinderService;
        protected ISearchContext SearchContext => _searchContext;

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
