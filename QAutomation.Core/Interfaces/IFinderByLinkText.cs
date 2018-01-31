namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByLinkText<out TElement> where TElement : class, IElement
    {
        IEnumerable<T> FindElementsByLinkText<T>(string linkText, ILogger log) where T : class, IElement;
        T FindElementByLinkText<T>(string linkText, ILogger log) where T : class, IElement;

        IEnumerable<TElement> FindElementsByLinkText(string linkText, ILogger log);
        TElement FindElementByLinkText(string linkText, ILogger log);
    }
}
