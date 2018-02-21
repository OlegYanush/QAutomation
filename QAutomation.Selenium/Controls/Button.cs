using OpenQA.Selenium;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Logger;

namespace QAutomation.Selenium.Controls
{
    public class Button : UiElement, IButton
    {
        public Button(IWebDriver driver, IWebElement element, IElementResolver resolver, IUiElement parent = null)
            : base(driver, element, resolver, parent) { }

        public void Click(ILogger log)
        {
            _wrappedElement.Click();
        }
    }
}
