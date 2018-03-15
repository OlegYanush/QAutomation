namespace QAutomation.Core.Interfaces.Mobile
{
    public interface IMobileDriver : IBrowserDriver, IFinderByAccessibilyId,
        IManageAppService, IManageDeviceService, IManageInputService, IHasSessionService
    { }
}
