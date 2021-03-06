﻿namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using Unity;
    using Unity.Resolution;

    public class UnityElementResolverService : IElementResolver
    {
        private IUnityContainer _container;

        public UnityElementResolverService(IUnityContainer container)
        {
            _container = container;
        }

        public TUiElement Resolve<TUiElement>(IWebDriver driver, IWebElement element)
           where TUiElement : IUiElement
        {
            var resolved = _container.Resolve<TUiElement>(new ResolverOverride[]
            {
                new ParameterOverride("driver", driver),
                new ParameterOverride("element", element),
                new ParameterOverride("resolver", this),
            });

            return resolved;
        }
    }
}
