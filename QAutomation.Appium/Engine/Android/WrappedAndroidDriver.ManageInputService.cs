namespace QAutomation.Appium.Engine.Android
{
    using QAutomation.Core.Interfaces.Mobile;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;

    public partial class WrappedAndroidDriver : IManageInputService
    {
        public void ActivateIMEEngine(string imeEngine, ILogger log)
        {
            log?.DEBUG($"Activate '{imeEngine}' IME on Device.");

            try
            {
                _nativeDriver.ActivateIMEEngine(imeEngine);
                log?.INFO($"Activating '{imeEngine}' IME on Device successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during activating '{imeEngine}' IME engine.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
        public List<string> GetIMEAvailableEngines(ILogger log)
        {
            log?.DEBUG($"Get available IME engines on Device.");

            try
            {
                var imeEngines = _nativeDriver.GetIMEAvailableEngines();
                log?.INFO($"Getting available IME engines on Device successfully completed. Available IME engines = '{string.Join(",", imeEngines)}'.");

                return imeEngines;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during getting available IME engines on Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public string GetIMEActiveEngine(ILogger log)
        {
            log?.DEBUG($"Get currently active IME on Device.");

            try
            {
                var imeEngine = _nativeDriver.GetIMEActiveEngine();
                log?.INFO($"Getting currently active IME on Device successfully completed. Active IME engine = '{imeEngine}'.");

                return imeEngine;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during getting currently active IME on Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
        public void DeactiveIMEEngine(ILogger log)
        {
            log?.DEBUG($"Deactivate currently active IME on Device.");

            try
            {
                _nativeDriver.DeactiveIMEEngine();
                log?.INFO($"Deactivating currently active IME on Device successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during deactivating currently active IME on Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public bool IsIMEActive(ILogger log)
        {
            log?.DEBUG("Check if IME is active on the Device.");
            try
            {
                bool isImeActive = _nativeDriver.IsIMEActive();
                log?.INFO($"IME is {(isImeActive ? string.Empty : "not")} active on the Device.");

                return isImeActive;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during checking if IME is active on the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
