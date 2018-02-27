namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Logging;

    public interface IBrowser
    {
        void Quit(ILogger log);

        string GetPageUrl(ILogger log);
        string GetPageTitle(ILogger log);

        string GetPageSource(ILogger log);
        IFrame GetFrameByName(string name);

        IBrowserDriver SwitchToParentFrame(ILogger log);
        IBrowserDriver SwitchToDefaultContent(ILogger log);
        IBrowserDriver SwitchToFrame(IFrame frame, ILogger log);
    }
}
