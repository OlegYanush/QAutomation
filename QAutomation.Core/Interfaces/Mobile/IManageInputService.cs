namespace QAutomation.Core.Interfaces.Mobile
{
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IManageInputService
    {
        List<string> GetIMEAvailableEngines(ILogger log);

        string GetIMEActiveEngine(ILogger log);
        bool IsIMEActive(ILogger log);

        void ActivateIMEEngine(string imeEngine, ILogger log);
        void DeactiveIMEEngine(ILogger log);
    }
}
