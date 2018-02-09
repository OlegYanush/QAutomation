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
                case SearchCriteria.Id:
                    return By.Id(locator.Value);
                case SearchCriteria.XPath:
                    return By.XPath(locator.Value);
                case SearchCriteria.ClassName:
                    return By.ClassName(locator.Value);
                case SearchCriteria.CssSelector:
                    return By.CssSelector(locator.Value);
                case SearchCriteria.LinkText:
                    return By.LinkText(locator.Value);
                case SearchCriteria.PartialLinkText:
                    return By.PartialLinkText(locator.Value);
                case SearchCriteria.TagName:
                    return By.TagName(locator.Value);

                default:
                    throw new Exception(string.Format("Unknown web locator type: {0}", locator.Type));
            }
        }
    }
}
