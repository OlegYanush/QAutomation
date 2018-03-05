namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IUiElementFinder
    {
        TUiElement Find<TUiElement>(Locator locator, ILogger log, string description = null) where TUiElement : IUiElement;
        TUiElement Find<TUiElement>(Locator locator, ILogger log, double timeoutInSec, string description = null) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log, string description = null) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log, double timeoutInSec, string description = null) where TUiElement : IUiElement;
    }
}
