namespace QAutomation.Core.Interfaces
{
    public interface IUiElementFinderService : IUiElementFinder, IFinderByXPath, IFinderById, IFinderByClassName,
               IFinderByName, IFinderByPartialLinkText, IFinderByCssSelector, IFinderByTagName, IFinderByLinkText
    {

    }
}
