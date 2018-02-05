namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByName<TElement> where TElement : IElement
    {
        IEnumerable<T> IFinderByName<T>(string name, ILogger log, double timeoutInSec = -1) where T : TElement;
        T FindElementByName<T>(string name, ILogger log, double timeoutInSec = -1) where T : TElement;

        IEnumerable<IElement> IFinderByName(string name, ILogger log, double timeoutInSec = -1);
        IElement FindElementByName(string name, ILogger log, double timeoutInSec = -1);
    }
}
