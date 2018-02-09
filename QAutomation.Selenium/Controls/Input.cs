namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;

    public class Input : UiElement, IInput
    {
        public Input(IWebDriver driver, IWebElement element, IUnityContainer container)
            : base(driver, element, container) { }


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
