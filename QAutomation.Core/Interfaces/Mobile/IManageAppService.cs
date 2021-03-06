﻿namespace QAutomation.Core.Interfaces.Mobile
{
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IManageAppService
    {
        Dictionary<string, object> GetAppStringDictionary(ILogger log, string language = null, string stringFile = null);
        bool IsAppInstalled(string bundledId, ILogger log);

        void InstallApp(string appPath, ILogger log);
        void BackgroundApp(int seconds, ILogger log);

        void RemoveApp(string appId, ILogger log);
        void LaunchApp(ILogger log);

        void CloseApp(ILogger log);
        void ResetApp(ILogger log);
    }
}
