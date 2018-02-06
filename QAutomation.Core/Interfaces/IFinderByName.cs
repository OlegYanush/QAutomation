namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByName
    {
        TUiObject FindElementByName<TUiObject>(string name, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;

        IEnumerable<TUiObject> FindElementsByName<TUiObject>(string name, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
