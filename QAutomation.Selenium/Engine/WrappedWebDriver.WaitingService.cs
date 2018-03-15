namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Enums;
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
            => WaitForElementCondition<IUiElement>(locator, el => el.State.HasFlag(UiElementState.NotVisible), log);

        public void WaitForElementVisible(Locator locator, ILogger log)
            => WaitForElementCondition<IUiElement>(locator, el => el.State.HasFlag(UiElementState.Visible), log);

        public void WaitForCompletelyPageLoad(ILogger log)
        {
            log?.TRACE("Wait until page is completely loaded.");

            try
            {
                WaitForPageLoad(log);
                WaitForJQueryLoad(log);

                log?.TRACE("Waiting until page is completely loaded successfully comoleted.");
            }
            catch (Exception ex)
            {
                log?.ERROR("Error occurred during waiting until page is completely loaded.", ex);
                throw;
            }
        }
        public void WaitForPageLoad(ILogger log)
        {
            log?.TRACE("Wait until page is loaded.");
            var sw = Stopwatch.StartNew();

            try
            {
                var result = string.Empty;
                string js = "return (this.document != undefined && this.document.readyState) ? this.document.readyState : 'undefined'";

                while (sw.Elapsed.TotalSeconds <= Config.Timeouts.PageLoadTimeout)
                {
                    try
                    {
                        result = ExecuteJavaScript(js, log).ToString().ToLowerInvariant();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("TypeError: can't access dead object."))
                        {
                            Refresh(log);
                        }
                        log?.WARN("Error occurred during waiting for page load.", ex);
                    }

                    if (result == "complete")
                    {
                        log?.TRACE($"Page loaded in: {sw.Elapsed.TotalSeconds} seconds.");
                        return;
                    }
                    else
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(Config.Timeouts.PollingInterval));
                        continue;
                    }
                }
                throw new Exception($"Timeout: {Config.Timeouts.PageLoadTimeout} seconds is reached.");
            }
            catch (Exception ex)
            {
                log?.ERROR("Error occurred during waiting until page is loaded.", ex);
                throw;
            }
            finally { sw.Stop(); }
        }
        public void WaitForJQueryLoad(ILogger log)
        {
            log?.TRACE("Wait until jQuery is loaded.");
            var sw = Stopwatch.StartNew();

            try
            {
                var result = string.Empty;
                string js = "return jQuery.active";

                while (sw.Elapsed.TotalSeconds <= Config.Timeouts.PageLoadTimeout)
                {
                    try
                    {
                        result = ExecuteJavaScript(js, log).ToString();
                    }
                    catch (Exception ex)
                    {
                        log?.WARN($"Error occurred during waiting for jQuery load.", ex);
                    }

                    if (result == "0")
                    {
                        log?.TRACE($"Page loaded in: {sw.Elapsed.TotalSeconds} seconds.");
                        return;
                    }
                    else
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(Config.Timeouts.PollingInterval));
                        continue;
                    }
                }
                throw new Exception($"Timeout: {Config.Timeouts.PageLoadTimeout} seconds is reached.");
            }
            catch (Exception ex)
            {
                log?.ERROR("Error occurred during waiting until jQuery is loaded.", ex);
                throw;
            }
            finally { sw.Stop(); }
        }

        public TUiElement WaitForElementCondition<TUiElement>(IUiElement parent, Locator locator, Func<TUiElement, bool> condition, ILogger log, double timeoutInSec = 0, double poolingIntervalInSec = 0)
            where TUiElement : class, IUiElement
        {
            log?.TRACE($"Wait condition for element by locator {locator} in parent {parent}.");
            var sw = Stopwatch.StartNew();

            try
            {
                timeoutInSec = timeoutInSec == 0 ? Config.Timeouts.ImplicitWait : timeoutInSec;
                poolingIntervalInSec = poolingIntervalInSec == 0 ? Config.Timeouts.PollingInterval : poolingIntervalInSec;

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
                poolingIntervalInSec = poolingIntervalInSec == 0 ? Config.Timeouts.PollingInterval : poolingIntervalInSec;

                while (sw.Elapsed.TotalSeconds <= timeoutInSec)
                {
                    var element = TryFindInParent<TUiElement>(locator, poolingIntervalInSec, log);

                    if (element != null && condition(element))
                    {
                        log?.TRACE($"Waiting condition for element by locator {locator} successfully completed. Elapsed time : {sw.Elapsed.Seconds} second(s).");
                        return element;
                    }

                    var sleepTime = poolingIntervalInSec * 1000 - sw.Elapsed.TotalSeconds;
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

        public TUiElement WaitForElementState<TUiElement>(Locator locator, UiElementState state, ILogger log, double timeoutInSec = 0, double poolingIntervalInSec = 0)
         where TUiElement : class, IUiElement
        {
            log?.TRACE($"Waiting state {state} for element by locator {locator}.");
            try
            {
                if (state == UiElementState.None)
                    throw new Exception($"Couldn't wait for state: {nameof(UiElementState.None)}.");

                timeoutInSec = timeoutInSec == 0 ? Config.Timeouts.SearchTimeout : timeoutInSec;
                poolingIntervalInSec = poolingIntervalInSec == 0 ? Config.Timeouts.PollingInterval : poolingIntervalInSec;

                var stopwatch = Stopwatch.StartNew();
                var accumulator = UiElementState.None;

                while (stopwatch.Elapsed.TotalMilliseconds <= timeoutInSec)
                {
                    var element = TryFindInParent<TUiElement>(locator, poolingIntervalInSec, log);

                    if (element == null)
                        accumulator |= UiElementState.Absent;
                    else
                        accumulator = element.State;

                    if ((state & accumulator) == state)
                        return element;

                    Thread.Sleep(TimeSpan.FromSeconds(poolingIntervalInSec));
                }
                throw new WebDriverTimeoutException($"Timeout {timeoutInSec} reached.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during waiting {state} state for element by locator {locator}.", ex);
                throw;
            }
        }
    }
}
