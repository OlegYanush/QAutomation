namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderById
    {
        TUiElement FindElementById<TUiElement>(string id, ILogger log, string description = null)
            where TUiElement : IUiElement;
        TUiElement FindElementById<TUiElement>(string id, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsById<TUiElement>(string id, ILogger log, string description = null)
            where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsById<TUiElement>(string id, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;
    }
}
