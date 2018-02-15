using OpenQA.Selenium;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Logger;

namespace QAutomation.Selenium.Controls
{
    public class Button : UiElement, IButton
    {
        public Button(IWebDriver driver, IWebElement element, IElementResolver resolver) 
            : base(driver, element, resolver) { }

        public void Click(ILogger log)
        {
            _wrappedElement.Click();
        }
    }
}
