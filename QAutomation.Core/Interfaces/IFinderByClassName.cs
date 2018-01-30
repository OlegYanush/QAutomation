namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByClassName<out TElement> where TElement : IElement
    {
        IEnumerable<T> FindElementsByClassName<T>(string className, ILogger log) where T : IElement;
        T FindElementByClassName<T>(string className, ILogger log) where T : IElement;

        IEnumerable<TElement> FindElementsByClassName(string className, ILogger log);
        TElement FindElementByClassName(string className, ILogger log);
    }
}
