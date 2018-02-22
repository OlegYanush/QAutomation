using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using QAutomation.Core;
using QAutomation.Core.Interfaces;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Core.Locators;
using QAutomation.Selenium.Configs;
using QAutomation.Selenium.Controls;
using QAutomation.Selenium.Engine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using QAutomation.Core.Enums;
using QAutomation.Selenium;
using QAutomation.Core.Support.PageObjects;
using Unity.Injection;

namespace Test
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);

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

            driver.Navigate("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_iframe", null);

            var page = new Page(driver);

            var value = page.Home.GetAttribute("title", null);

            var element = page.ChildFrame.Find<IUiElement>(Locator.Id("nav_references"), null);

            var img = driver.Find<IUiElement>(Locator.XPath("(.//img)[1]"), null);

            Console.WriteLine(img.GetAttribute("style", null));

            driver.Quit(null);
        }
    }
}
