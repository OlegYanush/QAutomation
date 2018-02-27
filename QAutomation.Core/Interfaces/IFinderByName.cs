namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderByName
    {
        TUiElement FindElementByName<TUiElement>(string name, ILogger log) where TUiElement : IUiElement;
        TUiElement FindElementByName<TUiElement>(string name, ILogger log, int timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByName<TUiElement>(string name, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByName<TUiElement>(string name, ILogger log, int timeoutInSec) where TUiElement : IUiElement;
    }
}
