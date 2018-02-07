using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using QAutomation.Appium;
using QAutomation.Appium.Configs;
using QAutomation.Appium.Controls;
using QAutomation.Appium.Engine;
using QAutomation.Appium.Engine.Android;
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
            var container = new UnityContainer();

            container.RegisterType<IUiObject, UiObject>();
            container.RegisterType<IButton, Button>();
            container.RegisterType<IInput, Input>();

            var config = new AndroidDriverConfig(container)
            {
                PathToApp = Path.Combine(Directory.GetCurrentDirectory(), "whatsapp.apk"),
                DeviceName = "Android Emulator",
                AppWaitActivities = new string[] { "*.EULA" },
                RemoteAddressServerUri = new Uri("http://localhost:4723/wd/hub/"),
                HttpCommandTimeoutInSec = 120
            };

            var driver = config.CreateEmulatorDriver();

            var wrappedDriver = driver as WrappedAndroidDriver;

            //var capabilities = new DesiredCapabilities();

            //capabilities.SetCapability("app", Path.Combine(Directory.GetCurrentDirectory(), "whatsapp.apk"));
            //capabilities.SetCapability("platformName", "android");

            //capabilities.SetCapability("deviceName", "android emulator");
            //capabilities.SetCapability("appWaitActivity", "*.EULA");

            //var driver = new AndroidDriver<OpenQA.Selenium.Appium.Android.AndroidElement>(new Uri("http://localhost:4723/wd/hub/"), capabilities, TimeSpan.FromMinutes(2));
            //var unityContainer = new UnityContainer();
            //var wrapper = new AndroidDriver(driver, unityContainer);

            try
            {
                var uiObject = driver.FindElementByXPath<IUiObject>("//*", null, 5);

                var button = uiObject.Find<IButton>(new UiSelector().ResourceId("android:id/button2"), null);

                button.Click(null);

                //var element = wrapper.FindByXPath<IUiObject>("//*");

                //var child = element.Find<UiObject>(new UiSelector().ResourceId("android:id/button2"), null);

                //child.WrappedElement.Click();

                //var title = driver.Title;
            }
            catch (Exception ex)
            {
            }
            finally { wrappedDriver.WrappedDriver.Quit(); }
        }
    }
}
