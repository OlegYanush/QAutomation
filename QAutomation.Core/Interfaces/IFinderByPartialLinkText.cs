namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByPartialLinkText<TElement> where TElement : IElement
    {
        IEnumerable<T> FindElementsByPartialLinkText<T>(string partialLinkText, ILogger log, double timeoutInSec = -1) where T : TElement;
        T FindElementByPartialLinkText<T>(string partialLinkText, ILogger log, double timeoutInSec = -1) where T : TElement;

        IEnumerable<IElement> FindElementsByPartialLinkText(string partialLinkText, ILogger log, double timeoutInSec = -1);
        IElement FindElementByPartialLinkText(string partialLinkText, ILogger log, double timeoutInSec = -1);
    }
}
