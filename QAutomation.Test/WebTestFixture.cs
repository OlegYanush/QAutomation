namespace QAutomation.Test
{
    using QAutomation.Core.Interfaces;
    using Unity.Resolution;
    using Unity;
    using QAutomation.Selenium;
    using QAutomation.Selenium.Configs;
    using QAutomation.Xium.Shared;

    public abstract class WebTestFixture : BaseTestFixture
    {
        private IBrowserDriver _driver;

        public IBrowserDriver WebDriver => _driver;

        public WebTestFixture(WebDriverConfig config)
        {
            var container = UnityContainerFactory.GetContainer();

            var resolver = container.Resolve<IElementResolver>(new ParameterOverride("resolver", container));

            _driver = container.Resolve<IBrowserDriver>(new ResolverOverride[]
            {
                new ParameterOverride("config", config),
                new ParameterOverride("resolver", resolver)
            });
        }
    }
}
