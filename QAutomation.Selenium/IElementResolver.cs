namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;

    public interface IElementResolver
    {
        TUiElement Resolve<TUiElement>(ISearchContext searchContext, IWebElement element) where TUiElement : IUiElement;
    }
}
