namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByCssSelector<out TElement> where TElement : class, IElement
    {
        IEnumerable<T> FindElementsByCssSelector<T>(string cssSelector, ILogger log) where T : class, IElement;
        T FindByCssSelector<T>(string cssSelector, ILogger log) where T : class, IElement;

        IEnumerable<TElement> FindElementsByCssSelector(string cssSelector, ILogger log);
        TElement FindByCssSelector(string cssSelector, ILogger log);
    }
}
