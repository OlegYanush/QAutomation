namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderById
    {
        TUiElement FindElementById<TUiElement>(string id, ILogger log) where TUiElement : IUiElement;
        TUiElement FindElementById<TUiElement>(string id, ILogger log, int timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsById<TUiElement>(string id, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsById<TUiElement>(string id, ILogger log, int timeoutInSec) where TUiElement : IUiElement;
    }
}
