namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderByClassName
    {
        TUiElement FindElementByClassName<TUiElement>(string className, ILogger log) where TUiElement : IUiElement;
        TUiElement FindElementByClassName<TUiElement>(string className, ILogger log, int timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByClassName<TUiElement>(string className, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByClassName<TUiElement>(string className, ILogger log, int timeoutInSec) where TUiElement : IUiElement;
    }
}
