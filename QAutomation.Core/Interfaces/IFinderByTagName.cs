namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderByTagName
    {
        TUiElement FindElementByTagName<TUiElement>(string tagName, ILogger log, string description = null)
            where TUiElement : IUiElement;
        TUiElement FindElementByTagName<TUiElement>(string tagName, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByTagName<TUiElement>(string tagName, ILogger log, string description = null)
            where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByTagName<TUiElement>(string tagName, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;
    }
}
