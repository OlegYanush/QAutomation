namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class Frame : UiElement, IFrame
    {
        public Frame(IWebDriver driver, IWebElement element, IElementResolver resolver, Locator locator)
            : base(driver, element, resolver, locator)
        { }

        public string Name => Locator.Value;

        public override TUiObject Find<TUiObject>(Locator locator, ILogger log)
        {
            _wrappedDriver = _wrappedDriver.SwitchTo().Frame(Locator.Value);

            return Find<TUiObject>(_wrappedDriver, locator, log);
        }
    }
}
