namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByLinkText<TElement> where TElement : IElement
    {
        IEnumerable<T> FindElementsByLinkText<T>(string linkText, ILogger log, double timeoutInSec = -1) where T : TElement;
        T FindElementByLinkText<T>(string linkText, ILogger log, double timeoutInSec = -1) where T : TElement;

        IEnumerable<IElement> FindElementsByLinkText(string linkText, ILogger log, double timeoutInSec = -1);
        IElement FindElementByLinkText(string linkText, ILogger log, double timeoutInSec = -1);
    }
}
