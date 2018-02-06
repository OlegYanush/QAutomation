namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByLinkText
    {
        TUiObject FindElementByLinkText<TUiObject>(string linkText, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindElementsByLinkText<TUiObject>(string linkText, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
