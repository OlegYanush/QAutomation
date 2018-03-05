using OpenQA.Selenium;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Core.Locators;
using QAutomation.Logging;

namespace QAutomation.Selenium.Controls
{
    public class Button : UiElement, IButton
    {
        public Button(IWebDriver driver, IWebElement element, IElementResolver resolver, Locator locator)
            : base(driver, element, resolver, locator) { }

        public Button(IWebDriver driver, IWebElement element, IElementResolver resolver, Locator locator, string description)
            : base(driver, element, resolver, locator, description) { }

        public void Click(ILogger log)
        {
            _wrappedElement.Click();
        }
    }
}
