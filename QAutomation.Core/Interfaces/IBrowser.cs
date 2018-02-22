namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Logger;

    public interface IBrowser
    {
        void Quit(ILogger log);

        string GetPageUrl(ILogger log);
        string GetPageTitle(ILogger log);

        string GetPageSource(ILogger log);
        IFrame GetFrameByName(string name);

        void SwitchToParentFrame(ILogger log);
        void SwitchToDefaultContent(ILogger log);
        void SwitchToFrame(IFrame frame, ILogger log);
    }
}
