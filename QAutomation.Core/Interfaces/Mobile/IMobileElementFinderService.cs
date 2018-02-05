namespace QAutomation.Core.Interfaces.Mobile
{
    using Controls;

    public interface IMobileElementFinderService<TMobileElement> :
        IFinderById<TMobileElement>, IFinderByAccessibilityId<TMobileElement>,
        IFinderByClassName<TMobileElement>, IFinderByTagName<TMobileElement>,
        IFinderByXPath<TMobileElement>
        where TMobileElement :  IMobileElement
    { }
}
