using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
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

namespace Test
{
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

            container.RegisterInstance(container);
            container.RegisterInstance(typeof(WebDriverConfig), new FirefoxDriverConfig());
            //container.RegisterInstance(new ChromeDriverConfig());

            var driver = container.Resolve<IBrowserDriver>();

            driver.Navigate("https://www.bing.com", null);

            var input = driver.FindElementById<IInput>("sb_form_q", null);

            input.SendKeys("Manchester United", null);
            var searchBtn = driver.FindElementById<IButton>("sb_form_go", null);

            searchBtn.Click(null);

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

            Console.WriteLine(window.GetSize(null));

            driver.Quit(null);
        }
    }
}
