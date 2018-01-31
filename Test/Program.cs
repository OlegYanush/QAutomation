using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using QAutomation.Appium.Controls;
using QAutomation.Appium.Engine;
using QAutomation.Core.Interfaces.Controls;
using System;
using System.Collections.Generic;
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
            var capabilities = new DesiredCapabilities();

            capabilities.SetCapability("app", Path.Combine(Directory.GetCurrentDirectory(), "whatsapp.apk"));
            capabilities.SetCapability("platformName", "android");

            capabilities.SetCapability("deviceName", "android emulator");
            capabilities.SetCapability("appWaitActivity", "*.EULA");

            var driver = new AndroidDriver<OpenQA.Selenium.Appium.Android.AndroidElement>(new Uri("http://localhost:4723/wd/hub/"), capabilities);

            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IElement, Element>();

            unityContainer.RegisterType<IMobileElement, QAutomation.Appium.Controls.AndroidElement>();
            unityContainer.RegisterType<IMobileElement, QAutomation.Appium.Controls.IOSElement>();

            var appiumDriver = new AndroidAppiumDriver<QAutomation.Appium.Controls.AndroidElement>(driver, unityContainer);

            var element = appiumDriver.FindElementByXPath("//*", null);

          

            

            driver.Url = "http://bing.com";
            driver.Quit();
        }
    }
}
