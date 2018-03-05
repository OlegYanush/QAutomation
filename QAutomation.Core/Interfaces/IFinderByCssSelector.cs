namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IFinderByCssSelector
    {
        TUiElement FindElementByCssSelector<TUiElement>(string cssSelector, ILogger log, string description = null)
            where TUiElement : IUiElement;
        TUiElement FindElementByCssSelector<TUiElement>(string cssSelector, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByCssSelector<TUiElement>(string cssSelector, ILogger log, string description = null)
            where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByCssSelector<TUiElement>(string cssSelector, ILogger log, int timeoutInSec, string description = null)
            where TUiElement : IUiElement;
    }
}
