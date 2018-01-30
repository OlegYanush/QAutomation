namespace QAutomation.Core.Interfaces.Mobile
{
    using Controls;

    public interface IMobileDriver<out TMobileElement> : IMobileElementFinderService<TMobileElement>,
        IManageAppService, IManageDeviceService, IManageInputService, IHasSessionService,
        IFinderByCssSelector<IElement>, IFinderByLinkText<IElement>, IFinderByName<IElement>,
        IFinderByPartialLinkText<IElement>
        where TMobileElement : IMobileElement
    { }
}
