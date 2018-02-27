namespace QAutomation.Selenium.Engine
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Logging;
    using System;

    public partial class WrappedWebDriver : IManageCookieService
    {
        public void AddCookie(string name, string value, ILogger log)
        {
            log?.DEBUG($"Add cookie with name = '{name}' and value = '{value}'.");
            try
            {
                _wrappedDriver.Manage().Cookies.AddCookie(new OpenQA.Selenium.Cookie(name, value));
                log?.INFO($"Adding cookie with name = '{name}' and value = '{value}' successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during adding cookie with name = '{name}' and value = '{value}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void DeleteAllCookies(ILogger log)
        {
            log?.DEBUG($"Clear all cookies'.");
            try
            {
                _wrappedDriver.Manage().Cookies.DeleteAllCookies();
                log?.INFO($"Clearing all cookies successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during clearing all cookies.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void DeleteCookie(string name, ILogger log)
        {
            log?.DEBUG($"Delete cookie by name = '{name}'.");
            try
            {
                _wrappedDriver.Manage().Cookies.DeleteCookieNamed(name);
                log?.INFO($"Deleting cookie by name ='{name}' successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during deleting cookie by name = '{name}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public string GetCookie(string name, ILogger log)
        {
            log?.DEBUG($"Get cookie by name = '{name}'.");
            try
            {
                var cookie = _wrappedDriver.Manage().Cookies.GetCookieNamed(name);
                log?.INFO($"Getting cookie by name ='{name}' successfully completed. Cookie value = '{cookie}'.");

                return cookie.Value;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during getting cookie by name = '{name}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
