namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Enums;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using QAutomation.Xium.Shared;

    public class Checkbox : Button, ICheckbox
    {
        public Checkbox(IWebDriver driver, IWebElement element, IElementResolver resolver, Locator locator)
            : base(driver, element, resolver, locator) { }

        public Checkbox(IWebDriver driver, IWebElement element, IElementResolver resolver, Locator locator, string description)
            : base(driver, element, resolver, locator, description) { }

        public CheckboxState GetState(ILogger log)
        {
            return _wrappedElement.Selected
                ? CheckboxState.Selected
                : CheckboxState.UnSelected;
        }

        public void SetState(CheckboxState state, ILogger log)
        {
            var currentState = GetState(log);

            if (state != currentState)
                Click(log);
        }
    }
}
