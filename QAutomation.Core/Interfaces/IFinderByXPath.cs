namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderByXPath
    {
        TUiElement FindElementByXPath<TUiElement>(string xpath, ILogger log, string description = null)
            where TUiElement : IUiElement;
        TUiElement FindElementByXPath<TUiElement>(string xpath, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByXPath<TUiElement>(string xpath, ILogger log, string description = null)
            where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByXPath<TUiElement>(string xpath, ILogger log,int timeoutInSec, string description = null)
            where TUiElement : IUiElement;
    }
}
