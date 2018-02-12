namespace QAutomation.Selenium.Engine
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Locators;
    using QAutomation.Logger;
    using System;


    public partial class WrappedWebDriver : IWaitingActionService
    {
        public void WaitForElementNotVisible(Locator locator, ILogger log)
        {
            throw new NotImplementedException();
        }

        public void WaitForElementVisible(Locator locator, ILogger log)
        {
            throw new NotImplementedException();
        }

        public void WaitForPageLoad(ILogger log)
        {
            throw new NotImplementedException();
        }
    }
}
