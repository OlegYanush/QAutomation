namespace QAutomation.Core.Interfaces.Mobile
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByAccessibilityId<TMobileElement>
        where TMobileElement : IMobileElement
    {
        IEnumerable<T> FindElementsByAccessibilityId<T>(string accessibilityId, ILogger log, double timeoutInSec = -1) where T : TMobileElement;
        T FindElementByAccessibilityId<T>(string accessibilityId, ILogger log, double timeoutInSec = -1) where T : TMobileElement;
    }
}
