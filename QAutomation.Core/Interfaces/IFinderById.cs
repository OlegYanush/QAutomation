namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderById<TElement> where TElement : IElement
    {
        IEnumerable<T> FindElementsById<T>(string id, ILogger log, double timeoutInSec = -1) where T : TElement;
        T FindElementById<T>(string id, ILogger log, double timeoutInSec = -1) where T : TElement;

        IEnumerable<IElement> FindElementsById(string id, ILogger log, double timeoutInSec = -1);
        IElement FindElementById(string id, ILogger log, double timeoutInSec = -1);
    }
}
