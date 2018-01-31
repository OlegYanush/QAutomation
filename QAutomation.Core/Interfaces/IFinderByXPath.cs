namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByXPath<out TElement> where TElement : class, IElement
    {
        IEnumerable<T> FindElementsByXPath<T>(string xpath, ILogger log) where T : class, IElement;
        T FindElementByXPath<T>(string xpath, ILogger log) where T : class, IElement;

        IEnumerable<TElement> FindElementsByXPath(string xpath, ILogger log);
        TElement FindElementByXPath(string xpath, ILogger log);
    }
}
