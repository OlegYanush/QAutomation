namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderById<out TElement> where TElement : class, IElement
    {
        IEnumerable<T> FindElementsById<T>(string id, ILogger log) where T : class, IElement;
        T FindElementById<T>(string id, ILogger log) where T : class, IElement;

        IEnumerable<TElement> FindElementsById(string id, ILogger log);
        TElement FindElementById(string id, ILogger log);
    }
}
