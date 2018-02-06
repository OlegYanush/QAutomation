namespace QAutomation.Appium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Logger;
    using System;
    using Unity;

    public class Input : UiObject, IInput
    {
        public Input(IWebElement element, IUnityContainer container)
            : base(element, container)
        { }

        public void Clear(ILogger log)
        {
            log?.DEBUG($"Clear input element with name = '{Name}'.");
            try
            {
                _wrappedElement.Clear();
                log?.DEBUG($"Clearing input element with name = '{Name}' successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred durring clearing element with name = '{Name}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SendKeys(string keys, ILogger log)
        {
            log?.DEBUG($"Send keys '{keys}' to input element with name = '{Name}'.");
            try
            {
                _wrappedElement.SendKeys(keys);
                log?.DEBUG($"Sending keys '{keys}' to input element with name = '{Name}' successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred durring sending keys '{keys}' to element with name = '{Name}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
