namespace QAutomation.Test
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium;
    using QAutomation.Selenium.Controls;
    using QAutomation.Selenium.Engine;
    using QAutomation.Xium.Shared;
    using Unity;

    public static class UnityContainerFactory
    {
        private static IUnityContainer _container;

        static UnityContainerFactory()
        {
            _container = new UnityContainer();

            _container.RegisterType<IBrowserDriver, WrappedWebDriver>();
            _container.RegisterType<IManageCookieService, WrappedWebDriver>();

            _container.RegisterType<IManageNavigationService, WrappedWebDriver>();
            _container.RegisterType<IUiElementFinderService, WrappedWebDriver>();

            _container.RegisterType<IWaitingActionService, WrappedWebDriver>();
            _container.RegisterType<IJsExecutor, WrappedWebDriver>();

            _container.RegisterType<IUiElement, UiElement>();

            _container.RegisterType<IInput, Input>();
            _container.RegisterType<IButton, Button>();
            _container.RegisterType<ICheckbox, Checkbox>();
            _container.RegisterType<IFrame, Frame>();

            _container.RegisterType<IElementResolver, UnityElementResolverService>();
        }

        public static IUnityContainer GetContainer() => _container;
    }
}
