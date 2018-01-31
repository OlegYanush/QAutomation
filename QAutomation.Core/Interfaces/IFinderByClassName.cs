namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByClassName<out TElement> where TElement : class, IElement
    {
        IEnumerable<T> FindElementsByClassName<T>(string className, ILogger log) where T : class, IElement;
        T FindElementByClassName<T>(string className, ILogger log) where T : class, IElement;

        IEnumerable<TElement> FindElementsByClassName(string className, ILogger log);
        TElement FindElementByClassName(string className, ILogger log);
    }
}
