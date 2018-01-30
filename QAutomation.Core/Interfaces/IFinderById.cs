namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderById<out TElement> where TElement : IElement
    {
        IEnumerable<T> FindElementsById<T>(string id, ILogger log) where T : IElement;
        T FindElementById<T>(string id, ILogger log) where T : IElement;

        IEnumerable<TElement> FindElementsById(string id, ILogger log);
        TElement FindElementById(string id, ILogger log);
    }
}
