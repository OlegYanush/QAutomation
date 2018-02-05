namespace QAutomation.Core.Interfaces
{
    using Controls;

    public interface IElementFinderService<TElement> :
       IFinderByClassName<TElement>, IFinderByCssSelector<TElement>,
       IFinderById<TElement>, IFinderByPartialLinkText<TElement>,
       IFinderByLinkText<TElement>, IFinderByXPath<TElement>,
       IFinderByName<TElement>, IFinderByTagName<TElement>
        where TElement : class, IElement
    { }
}
