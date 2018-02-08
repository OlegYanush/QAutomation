namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Logger;

    public interface IButton : IUiElement
    {
        void Click(ILogger log);
    }
}
