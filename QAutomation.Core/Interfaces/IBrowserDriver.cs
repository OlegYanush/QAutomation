namespace QAutomation.Core.Interfaces
{
    public interface IBrowserDriver : IBrowser, IUiElementFinderService, IManageCookieService,
        IManageNavigationService, IWaitingActionService, IManageWindowService, IJsExecutor
    {
        IBrowserDriverConfig Config { get; }
    }
}
