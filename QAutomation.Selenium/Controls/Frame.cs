﻿namespace QAutomation.Selenium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using System;
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

        public bool Switched => _isSwitched;

        public override TUiObject Find<TUiObject>(Locator locator, ILogger log)
            => Find<TUiObject>(_wrappedDriver, locator, log);

        public override IEnumerable<TUiElement> FindAll<TUiElement>(Locator locator, ILogger log)
           => FindAll<TUiElement>(_wrappedDriver, locator, log);

        public void SwitchToDefaultContent(ILogger log)
        {
            string frameName = null;

            try
            {
                frameName = string.IsNullOrEmpty(Name) ? "unknown" : Name;
                log?.DEBUG($"Switch to default content from frame with name = '{frameName}'.");

                _wrappedDriver = _wrappedDriver.SwitchTo().DefaultContent();
                log?.INFO($"Switching to default content from frame with name = '{frameName}' successfully completed.");

                _isSwitched = false;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred durring switching to default content from frame with name = '{frameName}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SwitchToParentFrame(ILogger log)
        {
            string frameName = null;

            try
            {
                frameName = string.IsNullOrEmpty(Name) ? "unknown" : Name;
                log?.DEBUG($"Switch to parent frame from the frame with name = '{frameName}'.");

                if (!Switched)
                    log?.WARN($"Driver doesn't located in the frame with name = '{frameName}'. Switching to parent frame is impossible.");
                else
                {
                    _wrappedDriver = _wrappedDriver.SwitchTo().DefaultContent();
                    log?.INFO($"Switching to default content from frame with name = '{frameName}' successfully completed.");

                    _isSwitched = false;
                }
            }
            catch (Exception ex)
            {
                var message = $"Error occurred durring switching to parent frame from the frame with name = '{frameName}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SwitchToSelf(ILogger log)
        {
            string frameName = null;

            try
            {
                frameName = string.IsNullOrEmpty(Name) ? "unknown" : Name;
                log?.DEBUG($"Switch to the frame with name = '{frameName}'.");

                if (Switched)
                    log?.INFO($"Driver already switched to the frame with name = '{frameName}'.");
                else
                {
                    _wrappedDriver = _wrappedDriver.SwitchTo().Frame(_wrappedElement);
                    log?.INFO($"Switching to the frame with name = '{frameName}' successfully completed.");

                    _isSwitched = true;
                }
            }
            catch (Exception ex)
            {
                var message = $"Error occurred durring switching to the frame with name = '{frameName}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
