namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByPartialLinkText<out TElement> where TElement : class, IElement
    {
        IEnumerable<T> FindElementsByPartialLinkText<T>(string partialLinkText, ILogger log) where T : class, IElement;
        T FindElementByPartialLinkText<T>(string partialLinkText, ILogger log) where T : class, IElement;

        IEnumerable<TElement> FindElementsByPartialLinkText(string partialLinkText, ILogger log);
        TElement FindElementByPartialLinkText(string partialLinkText, ILogger log);
    }
}
