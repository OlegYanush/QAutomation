namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByPartialLinkText
    {
        TUiObject FindElementByPartialLinkText<TUiObject>(string partialLinkText, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindElementsByPartialLinkText<TUiObject>(string partialLinkText, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
