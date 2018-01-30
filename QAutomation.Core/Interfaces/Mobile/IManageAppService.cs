namespace QAutomation.Core.Interfaces.Mobile
{
    using QAutomation.Logger;
    using System.Collections.Generic;

    public interface IManageAppService
    {
        Dictionary<string, string> GetAppStringDectionary(ILogger log, string language = null, string stringFile = null);
        bool IsAppInstalled(string boundleId, ILogger log);

        void InstallApp(string appPath, ILogger log);
        void BackgroundApp(int seconds, ILogger log);

        void RemoveApp(string appId, ILogger log);
        void LaunchApp(ILogger log);

        void CloseApp(ILogger log);
        void ResetApp(ILogger log);
    }
}
