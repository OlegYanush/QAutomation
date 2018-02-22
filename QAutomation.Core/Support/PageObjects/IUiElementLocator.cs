namespace QAutomation.Core.Support.PageObjects
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using System.Collections.Generic;

    public interface IUiElementLocator
    {
        IUiElementFinder UiElementFinder { get; }

        TUiElement LocateElement<TUiElement>(IEnumerable<Locator> locators) where TUiElement : IUiElement;

        TUiElement LocateElementInParent<TUiElement>(IUiElement parent, IEnumerable<Locator> locators) where TUiElement : IUiElement;

        IEnumerable<TUiElement> LocateElements<TUiElement>(IEnumerable<Locator> locator) where TUiElement : IUiElement;

        IEnumerable<TUiElement> LocateElementsInParent<TUiElement>(IUiElement parent, IEnumerable<Locator> locators) where TUiElement : IUiElement;
    }
}
