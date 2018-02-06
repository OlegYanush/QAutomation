namespace QAutomation.Core.Interfaces.Mobile
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByAccessibilyId
    {
        TUiObject FindElementByAccessibilityId<TUiObject>(string accessibilityId, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindElementsByAccessibilityId<TUiObject>(string accessibilityId, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
