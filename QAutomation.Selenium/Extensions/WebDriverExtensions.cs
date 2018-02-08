namespace QAutomation.Selenium.Extensions
{
    using OpenQA.Selenium;
    using System;

    public static class WebDriverExtensions
    {
        public static void SetImplicitWait(this IWebDriver driver, TimeSpan timeout)
        {
            driver.Manage().Timeouts().ImplicitWait = timeout;
        }
    }
}
