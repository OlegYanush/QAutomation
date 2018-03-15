namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Logging;

    public interface IFrame : IUiElement
    {
        string Name { get; }
        bool Switched { get; }

        void SwitchToSelf(ILogger log);
        void SwitchToParentFrame(ILogger log);
        void SwitchToDefaultContent(ILogger log);
    }
}
