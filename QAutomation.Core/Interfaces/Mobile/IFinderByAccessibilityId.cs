namespace QAutomation.Core.Interfaces.Mobile
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByAccessibilityId<out TMobileElement>
        where TMobileElement : class, IMobileElement
    {
        IEnumerable<TMobileElement> FindElementsByAccessibilityId(string accessibilityId, ILogger log);
        TMobileElement FindElementByAccessibilityId(string accessibilityId, ILogger log);
    }
}
