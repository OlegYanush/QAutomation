namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;
    using System.Drawing;

    public interface IWindow
    {
        string GetHandle(ILogger log);

        Size GetSize(ILogger log);
        void SetSize(Size size, ILogger log);

        Point GetPosition(ILogger log);
        void SetPosition(Point position, ILogger log);

        void FullScreen(ILogger log);

        void Maximize(ILogger log);
        void Minimize(ILogger log);

        void Close(ILogger log);
    }
}
