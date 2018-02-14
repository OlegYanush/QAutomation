namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Logger;
    using System;

    public partial class WrappedWebDriver : IJsExecutor
    {
        public string ExecuteJavaScript(string script, ILogger log)
        {
            log?.DEBUG($"Execute js code = '{script}'.");
            try
            {
                var result = ((IJavaScriptExecutor)_wrappedDriver).ExecuteAsyncScript(script) as string;
                log?.INFO($"Executing js code = '{script}' successfully completed. Returned value = '{result}'.");

                return result;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during executing js code = '{script}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
