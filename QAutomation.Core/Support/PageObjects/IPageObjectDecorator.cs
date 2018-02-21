namespace QAutomation.Core.Support.PageObjects
{
    public interface IPageObjectDecorator
    {
        void Decorate(IUiElementLocator locator, object page);
    }
}
