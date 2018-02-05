namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFinderByTagName<TElement> where TElement : IElement
    {
        IEnumerable<T> FindElementsByTagName<T>(string tagName, ILogger log, double timeoutInSec = -1) where T : TElement;
        T FindElementByTagName<T>(string tagName, ILogger log, double timeoutInSec = -1) where T : TElement;

        IEnumerable<IElement> FindElementsByTagName(string tagName, ILogger log, double timeoutInSec = -1);
        IElement FindElementByTagName(string tagName, ILogger log, double timeoutInSec = -1) ;
    }
}
