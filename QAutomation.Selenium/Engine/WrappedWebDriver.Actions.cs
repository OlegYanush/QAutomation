namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using QAutomation.Selenium.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class WrappedWebDriver
    {
        public void ActionsMoveTo(Locator locator, ILogger log) => ActionsMoveTo(Find(locator, log), log);

        public void ActionsMoveTo(IUiElement element, ILogger log)
        {
            log?.DEBUG($"Move cursor to {element}.");
            try
            {
                var wraps = element.GetWraps();
                new Actions(_wrappedDriver).MoveToElement(wraps.WrappedElement).Perform();

                log?.INFO($"Moving to {element} successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during moving to {element}.", ex);
                throw;
            }
        }

        public void ActionsClick(Locator locator, ILogger log) => ActionsClick(Find(locator, log), log);

        public void ActionsClick(IUiElement element, ILogger log)
        {
            log?.DEBUG($"Actions click on {element}.");
            try
            {
                var wraps = element.GetWraps();
                new Actions(_wrappedDriver).Click(wraps.WrappedElement).Perform();

                log?.INFO($"Actions click on {element} successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during actions clicking on {element}.", ex);
                throw;
            }
        }

        public void ActionsRightClick(Locator locator, ILogger log) => ActionsRightClick(Find(locator, log), log);

        public void ActionsRightClick(IUiElement element, ILogger log)
        {
            log?.DEBUG($"Actions right click on {element}.");
            try
            {
                var wraps = element.GetWraps();
                new Actions(_wrappedDriver).ContextClick(wraps.WrappedElement).Perform();

                log?.INFO($"Actions right click on {element} successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during actions right clicking on {element}.", ex);
                throw;
            }
        }

        public void ActionsDoubleClick(Locator locator, ILogger log) => ActionsDoubleClick(Find(locator, log), log);

        public void ActionsDoubleClick(IUiElement element, ILogger log)
        {
            log?.DEBUG($"Actions double click on {element}.");
            try
            {
                var wraps = element.GetWraps();
                new Actions(_wrappedDriver).DoubleClick(wraps.WrappedElement).Perform();

                log?.INFO($"Actions double click on {element} successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during actions double clicking on {element}.", ex);
                throw;
            }
        }

        public void ActionsSendKeys(Locator locator, string value, ILogger log) 
            => ActionsSendKeys(Find(locator, log), value, log);

        public void ActionsSendKeys(IUiElement element, string value, ILogger log)
        {
            log?.DEBUG($"Actions send '{value}' keys to {element}.");
            try
            {
                var wraps = element.GetWraps();
                new Actions(_wrappedDriver).SendKeys(wraps.WrappedElement, value).Perform();

                log?.INFO($"Actions send '{value}' keys to {element} successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during send '{value}' keys to {element}.", ex);
                throw;
            }
        }

        public void ActionsDragAndDrop(Locator source, Locator target, ILogger log)
            => ActionsDragAndDrop(Find(source, log), Find(target, log), log);

        public void ActionsDragAndDrop(IUiElement source, IUiElement target, ILogger log)
        {
            log?.TRACE($"Actions drag from {source} to {target}.");

            try
            {
                var sourceWraps = source.GetWraps();
                var targetWraps = target.GetWraps();

                new Actions(WrappedDriver).MoveToElement(sourceWraps.WrappedElement)
                    .ClickAndHold(sourceWraps.WrappedElement)
                    .MoveToElement(targetWraps.WrappedElement)
                    .Release(targetWraps.WrappedElement)
                    .Build().Perform();

                log?.DEBUG($"Actions drag and drop from {source} to {target} successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during actions drag and drop: from {source}\n to {target}.", ex);
                throw;
            }
        }
    }
}
