namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Logger;
    using System;

    public partial class WebDriverWrapper : IJavaScriptInvoker
    {
        public string InvokeJavaScript(string script, ILogger log)
        {
            log?.DEBUG($"Invoke js code = '{script}'.");
            try
            {
                var result = ((IJavaScriptExecutor)_wrappedDriver).ExecuteAsyncScript(script) as string;
                log?.INFO($"Invoking js code = '{script}' successfully completed. Returned value = '{result}'.");

                return result;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during invoking js code = '{script}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
