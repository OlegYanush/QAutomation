namespace QAutomation.Core.Support.PageObjects
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using System.Collections.Generic;

    public interface IUiElementLocator
    {
        IUiElementFinder UiElementFinder { get; }

        TUiElement LocateElement<TUiElement>(IEnumerable<Locator> locators, IUiElement parent = null) where TUiElement : IUiElement;
        IEnumerable<TUiElement> LocateElements<TUiElement>(IEnumerable<Locator> locator, IUiElement parent = null) where TUiElement : IUiElement;
    }
}
