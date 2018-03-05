namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderByPartialLinkText
    {
        TUiElement FindElementByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, string description = null)
            where TUiElement : IUiElement;
        TUiElement FindElementByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, string description = null)
            where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByPartialLinkText<TUiElement>(string partialLinkText, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;
    }
}
