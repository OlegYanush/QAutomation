using NUnit.Framework;
using QAutomation.Core.Enums;
using QAutomation.Core.Interfaces;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Core.Locators;
using QAutomation.Core.Support.PageObjects;
using QAutomation.Logging;
using QAutomation.Selenium;
using QAutomation.Selenium.Configs;
using QAutomation.Selenium.Controls;
using QAutomation.Selenium.Engine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace QAutomation.Test
{
    public class Page
    {
        [LocatedOf(nameof(Bar))]
        [LocateBy(How = SearchCriteria.Id, Using = "tryhome"), CacheLookup]
        public IUiElement Home { get; set; }

        [LocateBy(".//a[contains(@class,'w3-button w3-light')]")]
        public IList<IUiElement> Links { get; set; }

        [LocateBy(How = SearchCriteria.ClassName, Using = "trytopnav"), CacheLookup]
        public IUiElement Nav { get; set; }

        [LocatedOf(nameof(Nav))]
        [LocateBy(".//div[contains(@class,'w3-bar')]"), CacheLookup]
        public IUiElement Bar { get; set; }

        [LocateBy(How = SearchCriteria.Id, Using = "iframeResult"), CacheLookup]
        public IFrame FrameWrapper { get; set; }

        [LocatedOf(nameof(FrameWrapper))]
        [LocateBy(".//*[@src='https://www.w3schools.com']"), CacheLookup]
        public IFrame ChildFrame { get; set; }

        public Page(IBrowserDriver driver)
        {
            PageFactory.InitUiElements(this, new DefaultUiElementLocator(driver), new DefaultPageObjectDecorator());
        }
    }

    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            var container = new UnityContainer();

            container.RegisterType<IBrowserDriver, WrappedWebDriver>();
            container.RegisterType<IManageCookieService, WrappedWebDriver>();

            container.RegisterType<IManageNavigationService, WrappedWebDriver>();
            container.RegisterType<IUiElementFinderService, WrappedWebDriver>();

            container.RegisterType<IWaitingActionService, WrappedWebDriver>();
            container.RegisterType<IJsExecutor, WrappedWebDriver>();

            container.RegisterType<IUiElement, UiElement>();

            container.RegisterType<IInput, Input>();
            container.RegisterType<IButton, Button>();
            container.RegisterType<ICheckbox, Checkbox>();
            container.RegisterType<IFrame, Frame>();

            container.RegisterInstance(container);
            container.RegisterInstance<WebDriverConfig>(new ChromeDriverConfig { GridUri = new Uri("http://127.0.0.1:4444/wd/hub/"), UseGrid = false });

            var resolver = new UnityElementResolverService(container);

            container.RegisterInstance<IElementResolver>(resolver);
            var driver = container.Resolve<IBrowserDriver>();

            var logger = new NLogWrapper.Logger("logger1");

            driver.Navigate("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_iframe", logger);

            var page = new Page(driver);

            logger.LOGITEM(LogLevel.INFO, "test message", @"C:\Users\Aleh_Yanushkevich\Desktop\node.json");

            var value = page.Home.GetAttribute("title", logger);

            var element = driver.Find<IInput>(Locator.Id("id"), logger);

            //var element = page.ChildFrame.Find<IUiElement>(Locator.Id("nav_references"), logger);

            var img = driver.Find<IUiElement>(Locator.XPath("(.//img)[1]"), logger);

            driver.Quit(logger);

            logger.INFO("INFO message", new ArgumentNullException("Argument is null reference!"));

            Assert.Fail("Some faile in TestMethod.");
        }

        [Test]
        public void TestMethod2()
        {
            var container = new UnityContainer();

            container.RegisterType<IBrowserDriver, WrappedWebDriver>();
            container.RegisterType<IManageCookieService, WrappedWebDriver>();

            container.RegisterType<IManageNavigationService, WrappedWebDriver>();
            container.RegisterType<IUiElementFinderService, WrappedWebDriver>();

            container.RegisterType<IWaitingActionService, WrappedWebDriver>();
            container.RegisterType<IJsExecutor, WrappedWebDriver>();

            container.RegisterType<IUiElement, UiElement>();

            container.RegisterType<IInput, Input>();
            container.RegisterType<IButton, Button>();
            container.RegisterType<ICheckbox, Checkbox>();
            container.RegisterType<IFrame, Frame>();

            container.RegisterInstance(container);
            container.RegisterInstance<WebDriverConfig>(new ChromeDriverConfig { GridUri = new Uri("http://127.0.0.1:4444/wd/hub/"), UseGrid = false });

            var resolver = new UnityElementResolverService(container);

            container.RegisterInstance<IElementResolver>(resolver);
            var driver = container.Resolve<IBrowserDriver>();

            var logger = new NLogWrapper.Logger("logger");

            driver.Navigate("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_iframe", logger);

            var page = new Page(driver);

            logger.LOGITEM(LogLevel.INFO, "test message2", @"C:\Users\Aleh_Yanushkevich\Desktop\ddd.txt");

            var value = page.Home.GetAttribute("title", logger);

            var element = page.ChildFrame.Find<IUiElement>(Locator.Id("nav_references"), logger);

            var img = driver.Find<IUiElement>(Locator.XPath("(.//img)[1]"), logger);

            driver.Quit(logger);

            Assert.Pass("Some passed in TestMethod2.");
        }
    }
}
