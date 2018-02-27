namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderByXPath
    {
        TUiElement FindElementByXPath<TUiElement>(string xpath, ILogger log) where TUiElement : IUiElement;
        TUiElement FindElementByXPath<TUiElement>(string xpath, ILogger log, int timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByXPath<TUiElement>(string xpath, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByXPath<TUiElement>(string xpath, ILogger log,int timeoutInSec) where TUiElement : IUiElement;
    }
}
