namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Logging;

    public interface IInput : IUiElement
    {
        void Clear(ILogger log);
        void SendKeys(string keys, ILogger log);
    }
}
