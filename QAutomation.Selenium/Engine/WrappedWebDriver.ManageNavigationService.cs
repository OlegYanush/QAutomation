namespace QAutomation.Selenium.Engine
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Logging;
    using System;

    public partial class WrappedWebDriver : IManageNavigationService
    {
        public void Back(ILogger log)
        {
            log?.DEBUG("Click 'Back' button.");
            try
            {
                _wrappedDriver.Navigate().Back();
                log?.INFO("Clicking 'Back' button successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during clicking 'Back' button.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void Forward(ILogger log)
        {
            log?.DEBUG("Click 'Forward' button.");
            try
            {
                _wrappedDriver.Navigate().Forward();
                log?.INFO("Clicking 'Forward' button successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during clicking 'Forward' button.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void Navigate(string absoluteUrl, ILogger log)
        {
            log?.DEBUG($"Navigate by absolute url = '{absoluteUrl}'.");
            try
            {
                _wrappedDriver.Navigate().GoToUrl(absoluteUrl);

                log?.INFO($"Navigating by absolute url = '{absoluteUrl}' successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during navigating by absolute url = '{absoluteUrl}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void Navigate(string currentLocation, string relativeUrl, ILogger log)
        {
            throw new NotImplementedException();
        }

        public void Refresh(ILogger log)
        {
            log?.DEBUG("Click 'Refresh' button.");
            try
            {
                _wrappedDriver.Navigate().Back();
                log?.INFO("Clicking 'Refresh' button successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during clicking 'Refresh' button.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
