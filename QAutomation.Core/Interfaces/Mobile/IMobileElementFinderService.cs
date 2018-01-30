namespace QAutomation.Core.Interfaces.Mobile
{
    using Controls;

    public interface IMobileElementFinderService<out TMobileElement> :
        IFinderById<TMobileElement>, IFinderByAccessibilityId<TMobileElement>,
        IFinderByClassName<TMobileElement>, IFinderByTagName<TMobileElement>,
        IFinderByXPath<TMobileElement>
        where TMobileElement : IMobileElement
    { }
}
