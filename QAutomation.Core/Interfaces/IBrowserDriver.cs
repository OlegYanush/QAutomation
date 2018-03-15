namespace QAutomation.Core.Interfaces
{
    public interface IBrowserDriver : IBrowser, IUiElementFinderService, IManageCookieService, IJsExecutor,
        IManageNavigationService, IWaitingActionService, IManageWindowService, IActionsService
    {
        IBrowserDriverConfig Config { get; }
    }
}
