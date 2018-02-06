namespace QAutomation.Core.Interfaces.Mobile
{
    public interface IMobileDriver : IUiObjectFinderService, IFinderByAccessibilyId,
        IManageAppService, IManageDeviceService, IManageInputService, IHasSessionService
    { }

}
