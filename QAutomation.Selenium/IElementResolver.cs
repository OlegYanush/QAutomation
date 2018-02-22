namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;

    public interface IElementResolver
    {
        TUiElement Resolve<TUiElement>(IWebDriver driver, IWebElement element) where TUiElement : IUiElement;
    }
}
