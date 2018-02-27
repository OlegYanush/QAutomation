namespace QAutomation.Core.Interfaces.Mobile
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderByAccessibilyId
    {
        TUiElement FindElementByAccessibilityId<TUiElement>(string accessibilityId, ILogger log) where TUiElement : IUiElement;
        TUiElement FindElementByAccessibilityId<TUiElement>(string accessibilityId, ILogger log, int timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByAccessibilityId<TUiElement>(string accessibilityId, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByAccessibilityId<TUiElement>(string accessibilityId, ILogger log, int timeoutInSec) where TUiElement : IUiElement;
    }
}
