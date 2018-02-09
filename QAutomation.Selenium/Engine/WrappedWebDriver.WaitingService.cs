namespace QAutomation.Selenium.Engine
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Locators;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


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
