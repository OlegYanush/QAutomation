using QAutomation.Core.Interfaces.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation.Core.Interfaces
{
    public interface IFinderByTagName<out TElement> where TElement : IElement
    {
        TElement FindElementByTagName(string tagName);

        T FindElementByTagName<T>(string id) where T : IElement;

        IEnumerable<TElement> FindElementsByTagName(string tagName);

        IEnumerable<T> FindElementsByTagName<T>(string id) where T : IElement;
    }
}
