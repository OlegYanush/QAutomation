namespace QAutomation.Selenium.Extensions
{
    using QAutomation.Core.Enums;
    using QAutomation.Core.Locators;
    using System;
    using OpenQA.Selenium;

    public static class LocatorExtensions
    {
        public static By ToNativeBy(this Locator locator)
        {
            switch (locator.Type)
            {
                case LocatorType.Id:
                    return By.Id(locator.Value);
                case LocatorType.XPath:
                    return By.XPath(locator.Value);
                case LocatorType.ClassName:
                    return By.ClassName(locator.Value);
                case LocatorType.CssSelector:
                    return By.CssSelector(locator.Value);
                case LocatorType.LinkText:
                    return By.LinkText(locator.Value);
                case LocatorType.PartialLinkText:
                    return By.PartialLinkText(locator.Value);
                case LocatorType.TagName:
                    return By.TagName(locator.Value);

                default:
                    throw new Exception(string.Format("Unknown web locator type: {0}", locator.Type));
            }
        }
    }
}
