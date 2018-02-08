namespace QAutomation.Core.Interfaces
{
    public interface IDriver : IBrowser, IUiElementFinderService, IManageCookieService,
        IManageNavigationService, IWaitingActionService, IJavaScriptInvoker
    { }
}
