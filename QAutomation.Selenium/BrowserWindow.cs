namespace QAutomation.Selenium
{
    using OpenQA.Selenium;
    using QAutomation.Logging;
    using System;
    using System.Drawing;

    public class BrowserWindow : Core.Interfaces.IWindow
    {
        private IWebDriver _wrappedDriver;

        public BrowserWindow(IWebDriver driver)
        {
            _wrappedDriver = driver;
        }

        public void Close(ILogger log)
        {
            log?.TRACE("Close active browser window.");
            try
            {
                _wrappedDriver.Close();
                log?.INFO("Closing active window successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during closing active browser window.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void FullScreen(ILogger log)
        {
            log?.TRACE("Turn active browser window to full screen mode.");
            try
            {
                _wrappedDriver.Manage().Window.FullScreen();
                log?.INFO("Turning active browser window to full screen mode successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during turning active browser window to full screen mode.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public string GetHandle(ILogger log)
        {
            log?.TRACE("Get active browser window handle.");
            try
            {
                var handle = _wrappedDriver.CurrentWindowHandle;
                log?.INFO($"Getting active browser window handle successfully completed. Handle = '{handle}'.");

                return handle;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting active browser window handle.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public Point GetPosition(ILogger log)
        {
            log?.TRACE("Get active browser window position.");
            try
            {
                var position = _wrappedDriver.Manage().Window.Position;
                log?.INFO($"Getting active browser window position successfully completed. Position = '{position}'.");

                return position;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting active browser window position.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public Size GetSize(ILogger log)
        {
            log?.TRACE("Get active browser window size.");
            try
            {
                var size = _wrappedDriver.Manage().Window.Size;
                log?.INFO($"Getting active browser window size successfully completed. Position = '{size}'.");

                return size;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting active browser window size.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void Maximize(ILogger log)
        {
            log?.TRACE("Maximize active browser window.");
            try
            {
                _wrappedDriver.Manage().Window.Maximize();
                log?.INFO("Maximizing active window successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during maximizing active browser window.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void Minimize(ILogger log)
        {
            log?.TRACE("Minimize active browser window.");
            try
            {
                _wrappedDriver.Manage().Window.Minimize();
                log?.INFO("Minimizing active window successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during minimizing active browser window.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SetPosition(Point position, ILogger log)
        {
            log?.TRACE($"Set active browser window position = '{position}'.");
            try
            {
                _wrappedDriver.Manage().Window.Position = position;
                log?.INFO($"Setting active browser window position = '{position}' successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during setting active browser window position = '{position}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SetSize(Size size, ILogger log)
        {
            log?.TRACE($"Set active browser window size = '{size}'.");
            try
            {
                _wrappedDriver.Manage().Window.Size = size;
                log?.INFO($"Setting active browser window size successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during setting active browser window size = '{size}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
