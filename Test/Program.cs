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

namespace Test
{
    public class Page
    {
        [LocatedOf(nameof(Bar))]
        [SearchBy(How = SearchCriteria.Id, Using = "tryhome"), CacheLookup]
        public IUiElement Home { get; set; }

        [SearchBy(".//a[contains(@class,'w3-button w3-light')]")]
        public IList<IUiElement> Links { get; set; }

        [SearchBy(How = SearchCriteria.ClassName, Using = "trytopnav"), CacheLookup]
        public IUiElement Nav { get; set; }

        [LocatedOf(nameof(Nav))]
        [SearchBy(".//div[contains(@class,'w3-bar')]"), CacheLookup]
        public IUiElement Bar { get; set; }

        [SearchBy(How = SearchCriteria.Id, Using = "iframeResult"), CacheLookup]
        public IFrame FrameWrapper { get; set; }

        [LocatedOf(nameof(FrameWrapper))]
        [SearchBy(".//*[@src='https://www.w3schools.com']"), CacheLookup]
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


            //var locator = new Locator("b_searchboxForm", SearchCriteria.ClassName);

            //var childLocator = Locator.Id("sb_form_q", locator);

            driver.Navigate("https://www.w3schools.com/tags/tryit.asp?filename=tryhtml_iframe", null);

            //var element = driver.Find<IInput>(childLocator, null);

            var page = new Page(driver);

            //driver.SwitchToFrame(new Frame("iframeResult"), null);

            var value = page.Home.GetAttribute("title", null);

            var element = page.ChildFrame.Find<IUiElement>(Locator.Id("nav_references"), null);

            Console.WriteLine(element.Tag);

            //var frame = driver.Find<IFrame>(Locator.Name("iframeResult"), null);

            //var childFrame = frame.Find<IUiElement>(Locator.XPath(".//*[@src = 'https://www.w3schools.com']"), null);
            //var childFame1 = frame.Find<IFrame>(Locator.XPath(".//*[@src = 'https://www.w3schools.com']"), null);

            //var e = childFame1.Find<IUiElement>(Locator.ClassName("w3-center"), null);

            driver.Quit(null);

            Console.ReadKey();
        }
    }
}
