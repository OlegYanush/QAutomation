namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Enums;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logger;

    public class Checkbox : Button, ICheckbox
    {
        public Checkbox(IWebDriver driver, IWebElement element, IElementResolver resolver, IUiElement parent = null)
            : base(driver, element, resolver, parent) { }

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
