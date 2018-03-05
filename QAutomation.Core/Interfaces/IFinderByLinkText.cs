namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderByLinkText
    {
        TUiElement FindElementByLinkText<TUiElement>(string linkText, ILogger log, string description = null)
            where TUiElement : IUiElement;
        TUiElement FindElementByLinkText<TUiElement>(string linkText, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByLinkText<TUiElement>(string linkText, ILogger log, string description = null)
            where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByLinkText<TUiElement>(string linkText, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;
    }
}
