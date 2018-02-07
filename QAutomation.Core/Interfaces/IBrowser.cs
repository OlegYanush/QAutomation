namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;

    public interface IBrowser
    {
        void SwitchToFrame(IFrame frame, ILogger log);
        void SwitchToDefaultContent(ILogger log);

        string GetSourceString(ILogger log);
        IFrame GetFrameByName(string name);

        void Maximize(ILogger log);

        void Close(ILogger log);
        void Quit(ILogger log);
    }
}
