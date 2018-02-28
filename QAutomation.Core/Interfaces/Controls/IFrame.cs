using QAutomation.Logging;

namespace QAutomation.Core.Interfaces.Controls
{
    public interface IFrame : IUiElement
    {
        string Name { get; }
        bool Switched { get; }

        void SwitchToSelf(ILogger log);
        void SwitchToParentFrame(ILogger log);
        void SwitchToDefaultContent(ILogger log);
    }
}
