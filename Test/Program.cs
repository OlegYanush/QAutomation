using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using QAutomation.Core;
using QAutomation.Core.Interfaces;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Core.Locators;
using QAutomation.Selenium.Attributes;
using QAutomation.Selenium.Configs;
using QAutomation.Selenium.Controls;
using QAutomation.Selenium.Engine;
using QAutomation.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using QAutomation.Core.Enums;
using QAutomation.Selenium.Support;
using QAutomation.Selenium;

namespace Test
{
    public class Page
    {
        [QAutomationFindBy(How = SearchCriteria.XPath, Using = "//input[@class='b_searchbox']")]
        public IList<IUiElement> Element { get; set; }

        [QAutomationFindBy(How = SearchCriteria.Name, Using = "option2")]
        public ICheckbox Checkbox { get; set; }

        public Page(WrappedWebDriver driver, IUnityContainer container)
        {
            PageFactory.InitElements(this, new DefaultElementLocator(driver.WrappedDriver)
                ,
                new QAutomationPageMemberObjectDecorator());
        }

        //new QAutomationElementLocator(driver.WrappedDriver, new UnityElementResolverService(container))
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

            //var page = new Page(driver as WrappedWebDriver, container);

            //driver.SwitchToFrame(new Frame("iframeResult"), null);

            var frame = driver.Find<IFrame>(Locator.Name("iframeResult"), null);

            var childFrame = frame.Find<IUiElement>(Locator.XPath(".//*[@src = 'https://www.w3schools.com']"), null);

            driver.Quit(null);
            //var element = page.Element[0].Content;

            //page.Checkbox.SetState(CheckboxState.UnSelected, null);

            //page.Element[0].SendKeys("Manchester United", null);

            //var input = driver.FindElementByXPath<IInput>("//input[@class='b_searchbox']", null);

            //input.SendKeys("Manchester United", null);
            //page.Button.Click(null);


            //var driver = new WebDriverWrapper(condig)

            //var container = new UnityContainer();

            //container.RegisterType<IUiElement, UiObject>();
            //container.RegisterType<IButton, Button>();
            //container.RegisterType<IInput, Input>();

            //var config = new AndroidDriverConfig(container)
            //{
            //    PathToApp = Path.Combine(Directory.GetCurrentDirectory(), "whatsapp.apk"),
            //    DeviceName = "Android Emulator",
            //    AppWaitActivities = new string[] { "*.EULA" },
            //    RemoteAddressServerUri = new Uri("http://localhost:4723/wd/hub/"),
            //    HttpCommandTimeoutInSec = 120
            //};

            //var driver = config.CreateEmulatorDriver();

            //var wrappedDriver = driver as WrappedAndroidDriver;

            //var capabilities = new DesiredCapabilities();

            //capabilities.SetCapability("app", Path.Combine(Directory.GetCurrentDirectory(), "whatsapp.apk"));
            //capabilities.SetCapability("platformName", "android");

            //capabilities.SetCapability("deviceName", "android emulator");
            //capabilities.SetCapability("appWaitActivity", "*.EULA");

            //var driver = new AndroidDriver<OpenQA.Selenium.Appium.Android.AndroidElement>(new Uri("http://localhost:4723/wd/hub/"), capabilities, TimeSpan.FromMinutes(2));
            //var unityContainer = new UnityContainer();
            //var wrapper = new AndroidDriver(driver, unityContainer);

            //    try
            //    {
            //        var uiObject = driver.FindElementByXPath<IUiElement>("//*", null, 5);

            //        var button = uiObject.Find<IButton>(new UiSelector().ResourceId("android:id/button2"), null);

            //        button.Click(null);

            //        //var element = wrapper.FindByXPath<IUiObject>("//*");

            //        //var child = element.Find<UiObject>(new UiSelector().ResourceId("android:id/button2"), null);

            //        //child.WrappedElement.Click();

            //        //var title = driver.Title;
            //    }
            //    catch (Exception ex)
            //    {
            //    }
            //    finally { wrappedDriver.WrappedDriver.Quit(); }
            var window = driver.Window;

            window.FullScreen(null);

            window.Maximize(null);

            Console.WriteLine(window.GetSize(null));

            var location = window.GetPosition(null);

            window.SetPosition(new System.Drawing.Point(0, 0), null);

            location = window.GetPosition(null);

            var handle = window.GetHandle(null);

            window.SetSize(new System.Drawing.Size(1920, 1080), null);

            driver.Back(null);

            var handls = driver.GetAllWindowHandles(null);

            driver.Forward(null);

            var source = driver.GetPageSource(null);

            var title = driver.GetPageTitle(null);
            var url = driver.GetPageUrl(null);

            driver.DeleteAllCookies(null);
            var result = driver.ExecuteJavaScript("document.readyState", null);

            driver.Quit(null);
        }
    }
}
