namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;

    public interface IElementResolver
    {
        TUiElement Resolve<TUiElement>(ISearchContext searchContext, IWebElement element, Locator locator) where TUiElement : IUiElement;
    }
}
