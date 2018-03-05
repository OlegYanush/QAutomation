namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using System;
    using System.Diagnostics;
    using System.Threading;

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

        public TUiElement WaitForElementCondition<TUiElement>(IUiElement parent, Locator locator, Func<TUiElement, bool> condition, ILogger log, double timeoutInSec = 0, double poolingIntervalInSec = 0)
            where TUiElement : class, IUiElement
        {
            log?.TRACE($"Wait condition for element by locator {locator} in parent {parent}.");
            var sw = Stopwatch.StartNew();

            try
            {
                timeoutInSec = timeoutInSec == 0 ? Config.Timeouts.ImplicitWait : timeoutInSec;
                poolingIntervalInSec = poolingIntervalInSec == 0 ? Config.Timeouts.PoolingInterval : poolingIntervalInSec;

                while (sw.Elapsed.TotalSeconds <= timeoutInSec)
                {
                    var element = TryFindInParent<TUiElement>(locator, poolingIntervalInSec, log);

                    if (element != null && condition(element))
                    {
                        log?.TRACE($"Waiting condition for element by locator {locator} in parent successfully completed. Elapsed time {sw.Elapsed.Seconds} second(s).");
                        return element;
                    }

                    var sleepTime = poolingIntervalInSec * 1000 - sw.Elapsed.TotalMilliseconds;
                    if (sleepTime > 0)
                        Thread.Sleep((int)sleepTime);
                }

                throw new WebDriverTimeoutException($"Timeout {timeoutInSec} reached.");
            }
            catch (Exception commandException)
            {
                log?.ERROR($"Error occurred during condition for element by locator {locator}.", commandException);
                throw;
            }
            finally { sw.Stop(); }
        }

        public TUiElement WaitForElementCondition<TUiElement>(Locator locator, Func<TUiElement, bool> condition, ILogger log, double timeoutInSec = 0, double poolingIntervalInSec = 0)
            where TUiElement : class, IUiElement
        {
            log?.TRACE($"Wait condition for element by locator {locator}.");
            var sw = Stopwatch.StartNew();

            try
            {
                timeoutInSec = timeoutInSec == 0 ? Config.Timeouts.ImplicitWait : timeoutInSec;
                poolingIntervalInSec = poolingIntervalInSec == 0 ? Config.Timeouts.PoolingInterval : poolingIntervalInSec;

                while (sw.Elapsed.TotalSeconds <= timeoutInSec)
                {
                    var element = TryFindInParent<TUiElement>(locator, poolingIntervalInSec, log);

                    if (element != null && condition(element))
                    {
                        log?.TRACE($"Waiting condition for element by locator {locator} successfully completed. Elapsed time : {sw.Elapsed.Seconds} second(s).");
                        return element;
                    }

                    var sleepTime = poolingIntervalInSec * 1000 - sw.Elapsed.TotalMilliseconds;
                    if (sleepTime > 0)
                        Thread.Sleep((int)sleepTime);
                }

                throw new WebDriverTimeoutException($"Timeout {timeoutInSec} reached.");
            }
            catch (Exception commandException)
            {
                log?.ERROR($"Error occurred during condition for element by locator {locator}.", commandException);
                throw;
            }
            finally { sw.Stop(); }
        }
    }
}
