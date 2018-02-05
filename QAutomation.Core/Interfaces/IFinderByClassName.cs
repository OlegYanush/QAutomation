namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByClassName<TElement> where TElement : IElement
    {
        IEnumerable<T> FindElementsByClassName<T>(string className, ILogger log, double timeoutInSec = -1) where T : TElement;
        T FindElementByClassName<T>(string className, ILogger log, double timeoutInSec = -1) where T : TElement;

        IEnumerable<IElement> FindsElementByClassName(string className, ILogger log, double timeoutInSec = -1);
        IElement FindElementByClassName(string className, ILogger log, double timeoutInSec = -1);
    }
}
