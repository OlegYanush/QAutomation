namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByTagName
    {
        TUiObject FindElementByTagName<TUiObject>(string tagName, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindElementsByTagName<TUiObject>(string tagName, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
