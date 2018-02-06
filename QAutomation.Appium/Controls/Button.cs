namespace QAutomation.Appium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Logger;
    using System;
    using Unity;

    public class Button : UiObject, IButton
    {
        public Button(IWebElement element, IUnityContainer container)
            : base(element, container)
        { }

        public void Click(ILogger log)
        {
            log?.DEBUG($"Click on button with name = {Name}.");
            try
            {
                _wrappedElement.Click();
                log?.DEBUG($"Clicking on element with name = {Name} successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred durring clicking on button with name = '{Name}'";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
