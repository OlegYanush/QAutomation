namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Logging;

    public interface IButton : IUiElement
    {
        void Click(ILogger log);
    }
}
