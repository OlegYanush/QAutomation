namespace QAutomation.Core.Interfaces
{
    using Controls;

    public interface IElementFinderService<out TElement> :
       IFinderByClassName<TElement>, IFinderByCssSelector<TElement>,
       IFinderById<TElement>, IFinderByPartialLinkText<TElement>,
       IFinderByLinkText<TElement>, IFinderByXPath<TElement>,
       IFinderByName<TElement>, IFinderByTagName<TElement>
        where TElement : IElement
    { }
}
