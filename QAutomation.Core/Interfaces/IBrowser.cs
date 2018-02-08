namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;

    public interface IBrowser
    {
        string GetCurrentUrl(ILogger log);
        string GetCurrentTitle(ILogger log);

        void SwitchToFrame(IFrame frame, ILogger log);
        void SwitchToDefaultContent(ILogger log);

        string GetSourceString(ILogger log);
        IFrame GetFrameByName(string name);

        void Maximize(ILogger log);

        void Close(ILogger log);
        void Quit(ILogger log);
    }
}
