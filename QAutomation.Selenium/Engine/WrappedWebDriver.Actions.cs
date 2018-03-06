namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium.Interactions;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using QAutomation.Selenium.Extensions;
    using System;

    public partial class WrappedWebDriver
    {
        public void ActionsMoveTo(Locator locator, ILogger log) => ActionsMoveTo(Find(locator, log), log);

        public void ActionsMoveTo(IUiElement element, ILogger log)
        {
            log?.TRACE($"Move cursor to {element}.");
            try
            {
                var wrap = element.GetWrap();
                new Actions(WrappedDriver).MoveToElement(wrap.WrappedElement).Perform();

                log?.TRACE($"Moving cursor to {element} successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during moving cursor to {element}.", ex);
                throw;
            }
        }

        public void ActionsClick(Locator locator, ILogger log) => ActionsClick(Find(locator, log), log);

        public void ActionsClick(IUiElement element, ILogger log)
        {
            log?.TRACE($"Actions click on {element}.");
            try
            {
                var wrap = element.GetWrap();
                new Actions(WrappedDriver).Click(wrap.WrappedElement).Perform();

                log?.TRACE($"Actions click on {element} successfully completed.");
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
            log?.TRACE($"Actions right click on {element}.");
            try
            {
                var wrap = element.GetWrap();
                new Actions(WrappedDriver).ContextClick(wrap.WrappedElement).Perform();

                log?.TRACE($"Actions right click on {element} successfully completed.");
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
            log?.TRACE($"Actions double click on {element}.");
            try
            {
                var wrap = element.GetWrap();
                new Actions(WrappedDriver).DoubleClick(wrap.WrappedElement).Perform();

                log?.TRACE($"Actions double click on {element} successfully completed.");
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
            log?.TRACE($"Actions send '{value}' keys to {element}.");
            try
            {
                var wrap = element.GetWrap();
                new Actions(WrappedDriver).SendKeys(wrap.WrappedElement, value).Perform();

                log?.TRACE($"Actions send '{value}' keys to {element} successfully completed.");
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
                var sourceWrap = source.GetWrap();
                var targetWrap = target.GetWrap();

                new Actions(WrappedDriver).MoveToElement(sourceWrap.WrappedElement)
                    .ClickAndHold(sourceWrap.WrappedElement)
                    .MoveToElement(targetWrap.WrappedElement)
                    .Release(targetWrap.WrappedElement)
                    .Build().Perform();

                log?.TRACE($"Actions drag and drop from {source} to {target} successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during actions drag and drop: from {source}\n to {target}.", ex);
                throw;
            }
        }
    }
}
