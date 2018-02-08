namespace QAutomation.Core.Interfaces.Mobile
{
    using Controls;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IFInderByUiSelector
    {
        TUiElement FindElementByUiSelector<TUiElement>(string uiSelector, ILogger log) where TUiElement : IUiElement;
        TUiElement FindElementByUiSelector<TUiElement>(string uiSelector, ILogger log, int timeoutInSec) where TUiElement : IUiElement;

        IEnumerable<TUiElement> FindElementsByUiSelector<TUiElement>(string uiSelector, ILogger log) where TUiElement : IUiElement;
        IEnumerable<TUiElement> FindElementsByUiSelector<TUiElement>(string uiSelector, ILogger log, int timeoutInSec) where TUiElement : IUiElement;
    }
}
