namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByPartialLinkText
    {
        TUiElement FindElementByPartialLinkText<TUiElement>(string partialLinkText, ILogger log) where TUiElement : IUiElement;
        TUiElement FindElementByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, int timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByPartialLinkText<TUiElement>(string partialLinkText, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, int timeoutInSec) where TUiElement : IUiElement;
    }
}
