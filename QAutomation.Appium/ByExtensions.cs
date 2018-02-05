using QAutomation.Core;
using QAutomation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation.Appium
{
    public static class ByExtensions
    {
        public static OpenQA.Selenium.By ToNativeBy(this Locator locator)
        {
            switch (locator.Type)
            {
                case LocatorType.Id:
                    return OpenQA.Selenium.By.Id(locator.Value);
                case LocatorType.XPath:
                    return OpenQA.Selenium.By.XPath(locator.Value);
                case LocatorType.ClassName:
                    return OpenQA.Selenium.By.ClassName(locator.Value);
                case LocatorType.CssSelector:
                    return OpenQA.Selenium.By.CssSelector(locator.Value);
                case LocatorType.UiSelector:
                    return OpenQA.Selenium.Appium.MobileBy.AndroidUIAutomator(locator.Value);
                case LocatorType.UiAutomation:
                    return OpenQA.Selenium.Appium.MobileBy.IosUIAutomation(locator.Value);
                case LocatorType.AccessibilityId:
                    return OpenQA.Selenium.Appium.MobileBy.AccessibilityId(locator.Value);

                default:
                    throw new Exception(string.Format("Unknown locator type: {0}", locator.Type));
            }
        }

        public static OpenQA.Selenium.By ToNativeBy(this Core.By by)
        {
            switch (by.Type)
            {
                case SearchType.Id:
                    return OpenQA.Selenium.By.Id(by.Value);
                case SearchType.Tag:
                    return OpenQA.Selenium.By.TagName(by.Value);
                case SearchType.CssClass:
                    return OpenQA.Selenium.By.ClassName(by.Value);
                case SearchType.XPath:
                    return OpenQA.Selenium.By.XPath(by.Value);
                case SearchType.CssSelector:
                    return OpenQA.Selenium.By.CssSelector(by.Value);
                case SearchType.Name:
                    return OpenQA.Selenium.By.Name(by.Value);
                case SearchType.AccessibilyId:
                    return OpenQA.Selenium.Appium.MobileBy.AccessibilityId(by.Value);
                case SearchType.AndroidUIAutomator:
                    return OpenQA.Selenium.Appium.MobileBy.AndroidUIAutomator(by.Value);
                case SearchType.IosAutomation:
                    return OpenQA.Selenium.Appium.MobileBy.IosUIAutomation(by.Value);
                case SearchType.IosNSPredicate:
                    return OpenQA.Selenium.Appium.MobileBy.IosNSPredicate(by.Value);

                default:
                    throw new Exception(string.Format("Unknown search type: {0}", by.Type));
            }
        }
    }
}
