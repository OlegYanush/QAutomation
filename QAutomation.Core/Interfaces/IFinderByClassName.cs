namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByClassName
    {
        TUiObject FindElementByClassName<TUiObject>(string className, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;

        IEnumerable<TUiObject> FindElementsByClassName<TUiObject>(string className, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
