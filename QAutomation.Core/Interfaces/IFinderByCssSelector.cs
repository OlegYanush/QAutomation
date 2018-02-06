namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByCssSelector
    {
        TUiObject FindElementByCssSelector<TUiObject>(string cssSelector, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
        IEnumerable<TUiObject> FindElementsByCssSelector<TUiObject>(string cssSelector, ILogger log, double timeoutInSec = -1) where TUiObject : IUiObject;
    }
}
