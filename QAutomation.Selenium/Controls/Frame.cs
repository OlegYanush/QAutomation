namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public class Frame : UiElement, IFrame
    {
        private bool _isSwitched;
        private string _name;

        public Frame(IWebDriver driver, IWebElement element, IElementResolver resolver)
            : base(driver, element, resolver) { }

        public string Name
        {
            get
            {
                if (_name == null)
                    _name = GetAttribute("name", null);

                return _name;
            }
        }

        public override TUiObject Find<TUiObject>(Locator locator, ILogger log)
        {
            SwitchToCurrentFrame(ref _isSwitched);
            return Find<TUiObject>(_wrappedDriver, locator, log);
        }

        public override IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log)
        {
            SwitchToCurrentFrame(ref _isSwitched);
            return base.FindAll<TUiElement>(locator, log);
        }

        private void SwitchToCurrentFrame(ref bool isSwitched)
        {
            if (!isSwitched)
            {
                _wrappedDriver = !string.IsNullOrEmpty(Name)
                    ? _wrappedDriver.SwitchTo().Frame(Name)
                    : _wrappedDriver.SwitchTo().Frame(_wrappedElement);

                isSwitched = true;
            }
        }
    }
}
