namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByCssSelector<TElement> where TElement : IElement
    {
        IEnumerable<T> FindElementsByCssSelector<T>(string cssSelector, ILogger log, double timeoutInSec = -1) where T : TElement;
        T FindByCssSelector<T>(string cssSelector, ILogger log, double timeoutInSec = -1) where T : TElement;

        IEnumerable<IElement> FindElementsByCssSelector(string cssSelector, ILogger log, double timeoutInSec = -1);
        IElement FindByCssSelector(string cssSelector, ILogger log, double timeoutInSec = -1);
    }
}
