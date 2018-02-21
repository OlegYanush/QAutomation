namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Logger;

    public class Input : UiElement, IInput
    {
        public Input(IWebDriver driver, IWebElement element, IElementResolver resolver, IUiElement parent = null)
            : base(driver, element, resolver, parent) { }

        public void Clear(ILogger log)
        {
            _wrappedElement.Clear();
        }

        public void SendKeys(string keys, ILogger log)
        {
            _wrappedElement.SendKeys(keys);
        }
    }
}
