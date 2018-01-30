namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByName<out TElement> where TElement : IElement
    {
        IEnumerable<T> IFinderByName<T>(string name, ILogger log) where T : IElement;
        T FindElementByName<T>(string name, ILogger log) where T : IElement;

        IEnumerable<TElement> FindElementsByName(string name, ILogger log);
        TElement FindElementByName(string name, ILogger log);
    }
}
