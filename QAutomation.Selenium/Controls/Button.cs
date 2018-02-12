using OpenQA.Selenium;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Logger;
using Unity;

namespace QAutomation.Selenium.Controls
{
    public class Button : UiElement, IButton
    {
        public Button(IWebDriver driver, IWebElement element, IUnityContainer container) 
            : base(driver, element, container) { }

        public void Click(ILogger log)
        {
            _wrappedElement.Click();
        }
    }
}
