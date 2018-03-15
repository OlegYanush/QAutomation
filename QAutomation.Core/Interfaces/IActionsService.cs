namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IActionsService
    {
        void ActionsMoveTo(Locator locator, ILogger log);
        void ActionsMoveTo(IUiElement element, ILogger log);

        void ActionsClick(Locator locator, ILogger log);
        void ActionsClick(IUiElement element, ILogger log);

        void ActionsRightClick(Locator locator, ILogger log);
        void ActionsRightClick(IUiElement element, ILogger log);

        void ActionsDoubleClick(Locator locator, ILogger log);
        void ActionsDoubleClick(IUiElement element, ILogger log);

        void ActionsSendKeys(Locator locator, string value, ILogger log);
        void ActionsSendKeys(IUiElement element, string value, ILogger log);

        void ActionsDragAndDrop(Locator source, Locator target, ILogger log);
        void ActionsDragAndDrop(IUiElement source, IUiElement target, ILogger log);
    }
}
