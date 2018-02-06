namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IUiObjectFinder
    {
        TUiObject Find<TUiObject>(Locator locator, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindAll<TUiObject>(Locator locator, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
