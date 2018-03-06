namespace QAutomation.Selenium.Extensions
{
    using OpenQA.Selenium;
    using System;

    public static class WebDriverExtension
    {
        public static void SetImplicitWait(this IWebDriver driver, TimeSpan timeout)
            => driver.Manage().Timeouts().ImplicitWait = timeout;
    }
}
