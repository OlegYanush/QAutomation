namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderById
    {
        TUiObject FindElementById<TUiObject>(string id, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindElementsById<TUiObject>(string id, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
