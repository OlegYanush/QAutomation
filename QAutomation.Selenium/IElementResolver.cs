namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;

    public interface IElementResolver
    {
        TUiElement Resolve<TUiElement>(IWebDriver driver, IWebElement element, Locator locator, string description = null)
            where TUiElement : IUiElement;
    }
}
