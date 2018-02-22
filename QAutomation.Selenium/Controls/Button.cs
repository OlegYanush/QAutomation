using OpenQA.Selenium;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Logger;

namespace QAutomation.Selenium.Controls
{
    public class Button : UiElement, IButton
    {
        public Button(IWebDriver driver, IWebElement element, IElementResolver resolver)
            : base(driver, element, resolver) { }

        //public Button(IWebDriver driver, IWebElement element, IUiElement parent, IElementResolver resolver)
        //    : base(driver, element, parent, resolver) { }

        public void Click(ILogger log)
        {
            _wrappedElement.Click();
        }
    }
}
