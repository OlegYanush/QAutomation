namespace QAutomation.Core.Interfaces.Mobile
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFInderByUiSelector
    {
        TUiObject FindElementByUiSelector<TUiObject>(string uiSelector, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindElementsByUiSelector<TUiObject>(string uiSelector, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
