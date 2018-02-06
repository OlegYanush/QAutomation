namespace QAutomation.Core.Interfaces
{
    public interface IUiObjectFinderService : IUiObjectFinder, IFinderByXPath,
            IFinderByPartialLinkText, IFinderByTagName, IFinderByName, IFinderById,
            IFinderByClassName, IFinderByCssSelector, IFinderByLinkText
    { }
}
