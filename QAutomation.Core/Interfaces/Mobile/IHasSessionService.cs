namespace QAutomation.Core.Interfaces.Mobile
{
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IHasSessionService
    {
        Dictionary<string, object> GetSessionDetails(ILogger log);
        object GetSessionDetail(string detail, ILogger log);

        string GetPlatformName(ILogger log);
        string GetAutomationName(ILogger log);
    }
}
