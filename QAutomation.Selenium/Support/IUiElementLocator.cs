namespace QAutomation.Selenium.Support
{
    using OpenQA.Selenium.Support.PageObjects;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public interface IUiElementLocator : IElementLocator
    {
        TUiElement LocateElement<TUiElement>(IEnumerable<Locator> locators) where TUiElement : IUiElement;

        ReadOnlyCollection<TUiElement> LocateElements<TUiElement>(IEnumerable<Locator> locators) where TUiElement : IUiElement;
    }
}
