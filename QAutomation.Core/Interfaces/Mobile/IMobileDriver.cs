namespace QAutomation.Core.Interfaces.Mobile
{
    public interface IMobileDriver : IUiElementFinderService, IFinderByAccessibilyId,
        IManageAppService, IManageDeviceService, IManageInputService, IHasSessionService
    { }

}
