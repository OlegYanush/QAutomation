namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Enums;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using System;

    public interface IWaitingActionService
    {
        void WaitForPageLoad(ILogger log);
        void WaitForJQueryLoad(ILogger log);

        void WaitForElementVisible(Locator locator, ILogger log);
        void WaitForElementNotVisible(Locator locator, ILogger log);

        TUiElement WaitForElementCondition<TUiElement>(
            IUiElement parent,
            Locator locator,
            Func<TUiElement, bool> condition,
            ILogger log,
            double timeoutInSec = 0,
            double poolingIntervalInSec = 0) where TUiElement : class, IUiElement;

        TUiElement WaitForElementCondition<TUiElement>(
            Locator locator,
            Func<TUiElement, bool> condition,
            ILogger log,
            double timeoutInSec = 0,
            double poolingIntervalInSec = 0) where TUiElement : class, IUiElement;

        TUiElement WaitForElementState<TUiElement>(
            Locator locator,
            UiElementState state,
            ILogger log, double
            timeoutInSec = 0, double
            poolingIntervalInSec = 0) where TUiElement : class, IUiElement;
    }
}
