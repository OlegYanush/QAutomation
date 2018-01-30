namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByXPath<out TElement> where TElement : IElement
    {
        IEnumerable<T> FindsElementByXPath<T>(string xpath, ILogger log) where T : IElement;
        T FindElementByXPath<T>(string xpath, ILogger log) where T : IElement;

        IEnumerable<TElement> FindsElementByXPath(string xpath, ILogger log);
        TElement FindElementByXPath(string xpath, ILogger log);
    }
}
