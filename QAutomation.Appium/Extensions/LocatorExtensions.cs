namespace QAutomation.Appium.Extensions
{
    using QAutomation.Core;
    using QAutomation.Core.Enums;
    using System;

    public static class LocatorExtensions
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
    }
}
