namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByName<out TElement> where TElement : class, IElement
    {
        IEnumerable<T> IFinderByName<T>(string name, ILogger log) where T : class, IElement;
        T FindElementByName<T>(string name, ILogger log) where T : class, IElement;

        IEnumerable<TElement> FindElementsByName(string name, ILogger log);
        TElement FindElementByName(string name, ILogger log);
    }
}
