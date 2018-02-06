namespace QAutomation.Appium.Engine.Android
{
    using QAutomation.Core.Interfaces.Mobile;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;

    public partial class WrappedAndroidDriver : IManageAppService
    {
        public Dictionary<string, object> GetAppStringDictionary(ILogger log, string language = null, string stringFile = null)
        {
            log?.DEBUG("Get active application string dictionary.");

            try
            {
                var dictionary = _nativeDriver.GetAppStringDictionary(language, stringFile);
                log?.INFO("Getting active application string dictionary successfully completed.");

                return dictionary;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting active application string dictionary.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void BackgroundApp(int seconds, ILogger log)
        {
            log?.DEBUG($"Set active application to backaground mode on {seconds} second(s).");
            try
            {
                _nativeDriver.BackgroundApp(seconds);
                log?.INFO($"Setting active application to background mode on {seconds} second(s).");
            }
            catch (Exception ex)
            {
                var message = $"Erorr occurred during setting active application to background mode on {seconds} second(s).";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
        public void CloseApp(ILogger log)
        {
            log?.DEBUG($"Close active application.");
            try
            {
                _nativeDriver.CloseApp();
                log?.INFO($"Closing acrive application successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Erorr occurred during closing acrive application.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void InstallApp(string appPath, ILogger log)
        {
            log?.DEBUG($"Install application with target path = '{appPath}'.");
            try
            {
                _nativeDriver.InstallApp(appPath);
                log?.INFO($"Installing application with target path = '{appPath}' successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Erorr occurred during installing application with target path = '{appPath}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
        public bool IsAppInstalled(string bundleId, ILogger log)
        {
            log?.INFO($"Check if an application installed by bundle Id = '{bundleId}'.");

            try
            {
                bool isInstalled = _nativeDriver.IsAppInstalled(bundleId);
                log?.INFO($"The application with bundle Id = '{bundleId}' is {(isInstalled ? string.Empty : "not")} installed.");

                return isInstalled;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during getting checking if an application installed by bundle Id = '{bundleId}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void LaunchApp(ILogger log)
        {
            log?.DEBUG($"Launch the current application.");
            try
            {
                _nativeDriver.LaunchApp();
                log?.INFO($"Launching current application successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Erorr occurred during launching current application.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
        public void RemoveApp(string appId, ILogger log)
        {
            log?.INFO($"Remove an application by id = '{appId}'.");

            try
            {
                _nativeDriver.RemoveApp(appId);
                log?.INFO($"The application with id = '{appId}' successfully deleted.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during deleting an application by id = '{appId}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void ResetApp(ILogger log)
        {
            log?.DEBUG($"Reset the current application.");
            try
            {
                _nativeDriver.ResetApp();
                log?.INFO($"Resetting current application successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Erorr occurred during resetting current application.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
