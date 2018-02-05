using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using QAutomation.Appium;
using QAutomation.Appium.Controls;
using QAutomation.Appium.Engine;
using QAutomation.Core;
using QAutomation.Core.Interfaces.Controls;
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
            //var service = ChromeDriverService.CreateDefaultService();

            //service.EnableVerboseLogging = true;
            //service.LogPath = "chrome.log";

            //var driver = new ChromeDriver(service, new ChromeOptions(), TimeSpan.FromSeconds(120));
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(100));

            //var stopwatch = Stopwatch.StartNew();
            //IWebElement element = null;

            //try
            //{
            //    driver.Url = "https://bing.com";
            //    element = driver.FindElementById("invalidId");
            //}
            //catch (Exception ex)
            //{
            //    stopwatch.Stop();

            //}

            //Console.WriteLine(stopwatch.Elapsed.TotalSeconds);

            //driver.Quit();
            var capabilities = new DesiredCapabilities();

            capabilities.SetCapability("app", Path.Combine(Directory.GetCurrentDirectory(), "whatsapp.apk"));
            capabilities.SetCapability("platformName", "android");

            capabilities.SetCapability("deviceName", "android emulator");
            capabilities.SetCapability("appWaitActivity", "*.EULA");

            var driver = new AndroidDriver<OpenQA.Selenium.Appium.Android.AndroidElement>(new Uri("http://localhost:4723/wd/hub/"), capabilities, TimeSpan.FromMinutes(2));

            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IElement, Element>();
            unityContainer.RegisterType<IUiObject, UiObject>();

            //unityContainer.RegisterType<IMobileElement, QAutomation.Appium.Controls.AndroidElement>();



            try
            {

            }
            catch (Exception ex)
            {
            }

            driver.Quit();
        }
    }
}
