namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IManageWindowService
    {
        IReadOnlyCollection<string> GetAllWindowHandles(ILogger log);
        string GetCurrentWindowHandle(ILogger log);

        IWindow SwitchToWindow(string handle, ILogger log);
        IWindow Window { get; }

        void Close(ILogger log);
    }
}
