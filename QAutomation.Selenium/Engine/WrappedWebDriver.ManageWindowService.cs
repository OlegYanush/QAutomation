namespace QAutomation.Selenium.Engine
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Logging;
    using System;
    using System.Collections.Generic;

    public partial class WrappedWebDriver : IManageWindowService
    {
        public IWindow Window => _currentWindow;

        public IReadOnlyCollection<string> GetAllWindowHandles(ILogger log)
        {
            log?.TRACE("Get all browser window handles.");
            try
            {
                var handles = _wrappedDriver.WindowHandles;
                log?.INFO("Getting all browser window handles successfully compleeted.");

                log?.TRACE($"All window handles : {string.Join(",", handles)}");
                return handles;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting all browser window handles.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public string GetCurrentWindowHandle(ILogger log) => Window.GetHandle(log);

        public IWindow SwitchToWindow(string handle, ILogger log)
        {
            log?.Equals($"Switch to browser window with handle = '{handle}'.");
            try
            {
                _wrappedDriver.SwitchTo().Window(handle);
                _currentWindow = new BrowserWindow(_wrappedDriver);

                log?.INFO($"Switching to window with handle successfully completed. Current browser window handle = '{_wrappedDriver.CurrentWindowHandle}'.");
                return _currentWindow;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during switching to browser window with handle = '{handle}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
