using NUnit.Framework;
using QAutomation.Core.Interfaces;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Selenium;
using QAutomation.Selenium.Controls;
using QAutomation.Selenium.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace QAutomation.Test
{
    public abstract class BaseTestFixture
    {
        private Logging.ILogger _setupLog = new NLogWrapper.Logger("set up");
        private Logging.ILogger _teardownLog = new NLogWrapper.Logger("tear down");
        private Logging.ILogger _testLog = new NLogWrapper.Logger("test method");

        protected IUnityContainer _container;

        public Logging.ILogger SetupLog => _setupLog;
        public Logging.ILogger TeardownLog => _teardownLog;
        public Logging.ILogger TestLog => _testLog;

        public BaseTestFixture()
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

        [SetUp]
        public abstract void SetUp();

        [TearDown]
        public abstract void TearDown();
    }
}
