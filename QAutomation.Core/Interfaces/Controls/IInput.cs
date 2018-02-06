namespace QAutomation.Core.Interfaces.Controls
{
    using QAutomation.Logger;

    public interface IInput : IUiObject
    {
        void Clear(ILogger log);
        void SendKeys(string keys, ILogger log);
    }
}
