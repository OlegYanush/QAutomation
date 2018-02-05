namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByXPath<TElement> where TElement : IElement
    {
        IEnumerable<T> FindElementsByXPath<T>(string xpath, ILogger log, double timeoutInSec = -1) where T : TElement;
        T FindElementByXPath<T>(string xpath, ILogger log, double timeoutInSec = -1) where T : TElement;

        IEnumerable<IElement> FindElementsByXPath(string xpath, ILogger log, double timeoutInSec = -1);
        IElement FindElementByXPath(string xpath, ILogger log, double timeoutInSec = -1);
    }
}
