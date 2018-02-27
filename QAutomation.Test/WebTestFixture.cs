namespace QAutomation.Test
{
    using QAutomation.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity.Resolution;
    using Unity;
    using QAutomation.Selenium;
    using QAutomation.Selenium.Configs;

    public abstract class WebTestFixture : BaseTestFixture
    {
        private IBrowserDriver _driver;

        public IBrowserDriver WebDriver => _driver;

        public WebTestFixture(WebDriverConfig config)
        {
            var resolver = _container.Resolve<IElementResolver>(new ParameterOverride("resolver", _container));

            _driver = _container.Resolve<IBrowserDriver>(new ResolverOverride[]
            {
                new ParameterOverride("config", config),
                new ParameterOverride("resolver", resolver)
            });
        }
    }
}
