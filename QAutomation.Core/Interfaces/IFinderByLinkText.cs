namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByLinkText
    {
        TUiElement FindElementByLinkText<TUiElement>(string linkText, ILogger log) where TUiElement : IUiElement;
        TUiElement FindElementByLinkText<TUiElement>(string linkText, ILogger log, int timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByLinkText<TUiElement>(string linkText, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByLinkText<TUiElement>(string linkText, ILogger log, int timeoutInSec) where TUiElement : IUiElement;
    }
}
