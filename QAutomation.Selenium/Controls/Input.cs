namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logger;

    public class Input : UiElement, IInput
    {
        public Input(IWebDriver driver, IWebElement element, IElementResolver resolver, Locator locator)
            : base(driver, element, resolver, locator) { }


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
