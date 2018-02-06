namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByXPath
    {
        TUiObject FindElementByXPath<TUiObject>(string xpath, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindElementsByXPath<TUiObject>(string xpath, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
