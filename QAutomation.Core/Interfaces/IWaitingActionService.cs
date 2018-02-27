namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Locators;
    using QAutomation.Logging;

    public interface IWaitingActionService
    {
        void WaitForPageLoad(ILogger log);

        void WaitForElementVisible(Locator locator, ILogger log);
        void WaitForElementNotVisible(Locator locator, ILogger log);
    }
}
