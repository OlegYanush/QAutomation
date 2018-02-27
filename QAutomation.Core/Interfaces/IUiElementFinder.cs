namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IUiElementFinder
    {
        TUiElement Find<TUiElement>(Locator locator, ILogger log) where TUiElement : IUiElement;
        TUiElement Find<TUiElement>(Locator locator, ILogger log, double timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log, double timeoutInSec) where TUiElement : IUiElement;
    }
}
