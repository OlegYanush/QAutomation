namespace QAutomation.Selenium.Engine
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Logger;
    using System;

    public partial class WebDriverWrapper : IBrowser
    {
        public void Close(ILogger log)
        {
            log?.DEBUG("Close last window.");
            try
            {
                _wrappedDriver.Close();
                log?.INFO("Last window successfully closed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during closing last window.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public string GetCurrentTitle(ILogger log)
        {
            log?.DEBUG("Get current page title.");
            try
            {
                var title = _wrappedDriver.Title;
                log?.INFO($"Getting current page title successfully completed. Title = '{title}'.");

                return title;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting current page title.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public string GetCurrentUrl(ILogger log)
        {
            log?.DEBUG("Get current URL.");
            try
            {
                var url = _wrappedDriver.Url;
                log?.INFO($"Getting current URL successfully completed. URL = '{url}'.");

                return url;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting current URL.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public IFrame GetFrameByName(string name)
        {
            throw new NotImplementedException();
        }

        public string GetSourceString(ILogger log)
        {
            log?.DEBUG("Get current page source.");
            try
            {
                var source = _wrappedDriver.PageSource;
                log?.DEBUG($"Getting current page source successfully completed. Page source = '{source}'.");

                return source;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting current page source.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void Maximize(ILogger log)
        {
            log?.DEBUG("Maximize window.");
            try
            {
                _wrappedDriver.Manage().Window.Maximize();
                log?.INFO("Maximizing window successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during maximizing window.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void Quit(ILogger log)
        {
            log?.DEBUG("Dispose driver.");
            try
            {
                _wrappedDriver.Quit();
                log?.INFO("Disposing driver successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during disposing driver.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SwitchToDefaultContent(ILogger log)
        {
            log?.DEBUG("Switch to default content.");
            try
            {
                _wrappedDriver.SwitchTo().DefaultContent();
                log?.INFO("Switching to default content successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during switching to default content.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SwitchToFrame(IFrame frame, ILogger log)
        {
            log?.DEBUG($"Switch to frame by name = '{frame.Name}'.");
            try
            {
                _wrappedDriver.SwitchTo().Frame(frame.Name);
                log?.INFO($"Switching to frame by name = '{frame.Name}' successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during switching to frame by name = '{frame.Name}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
