namespace QAutomation.Core.Interfaces
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFinderByCssSelector
    {
        TUiElement FindElementByCssSelector<TUiElement>(string cssSelector, ILogger log) where TUiElement : IUiElement;
        TUiElement FindElementByCssSelector<TUiElement>(string cssSelector, ILogger log, int timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByCssSelector<TUiElement>(string cssSelector, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByCssSelector<TUiElement>(string cssSelector, ILogger log, int timeoutInSec) where TUiElement : IUiElement;
    }
}
