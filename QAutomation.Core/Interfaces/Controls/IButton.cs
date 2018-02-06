namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Logger;

    public interface IButton : IUiObject
    {
        void Click(ILogger log);
    }
}
