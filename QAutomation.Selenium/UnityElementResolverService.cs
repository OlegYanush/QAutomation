namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using Unity;
    using Unity.Resolution;

    public class UnityElementResolverService : IElementResolver
    {
        private IUnityContainer _container;

        public UnityElementResolverService(IUnityContainer container)
        {
            _container = container;
        }

        public TUiElement Resolve<TUiElement>(ISearchContext searchContext, IWebElement element, Locator locator)
            where TUiElement : IUiElement
        {
            var resolved = _container.Resolve<TUiElement>(new ResolverOverride[]
            {
                new ParameterOverride("driver", searchContext),
                new ParameterOverride("element", element),
                new ParameterOverride("resolver", this),
                new ParameterOverride("locator", locator)
            });

            return resolved;
        }
    }
}
