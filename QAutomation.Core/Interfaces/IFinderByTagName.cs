namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFinderByTagName<out TElement> where TElement : class, IElement
    {
        IEnumerable<T> FindElementsByTagName<T>(string tagName, ILogger log) where T : class, IElement;
        T FindElementByTagName<T>(string tagName, ILogger log) where T : class, IElement;

        IEnumerable<TElement> FindElementsByTagName(string tagName, ILogger log);
        TElement FindElementByTagName(string tagName, ILogger log);
    }
}
