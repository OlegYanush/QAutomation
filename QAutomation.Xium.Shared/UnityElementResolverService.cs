namespace QAutomation.Xium.Shared
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

        public TUiElement Resolve<TUiElement>(IWebDriver driver, IWebElement element, Locator locator, string description)
           where TUiElement : IUiElement
        {
            var resolved = _container.Resolve<TUiElement>(new ResolverOverride[]
            {
                new ParameterOverride("driver", driver),
                new ParameterOverride("element", element),
                new ParameterOverride("resolver", this),
                new ParameterOverride("locator", locator),
                new ParameterOverride("description", description ?? string.Empty)
            });

            return resolved;

        }
    }
}
