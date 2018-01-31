namespace QAutomation.Appium.Controls
{
    using OpenQA.Selenium;
    using QAutomation.Appium.Engine;
    using QAutomation.Core.Interfaces.Controls;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;

    public class Element : IElement
    {
        private IWebDriver _webDriver;
        private IWebElement _webElement;

        //private ElementFinderService<IElement> _elementFinderService;

        public Element(IWebDriver driver, IWebElement element, IUnityContainer container)
        {
            _webDriver = driver;
            _webElement = element;
            //_elementFinderService = new ElementFinderService<IElement>(container);
        }

        public bool Displayed => _webElement.Displayed;

        public bool Enabled => _webElement.Enabled;

        public Point Location => _webElement.Location;

        public string Content => _webElement.Text;

        public string Tag => _webElement.TagName;

        public Size Size => _webElement.Size;

        public string GetAttribute(string attribute)
            => _webElement.GetAttribute(attribute);

        public string GetCssValue(string property)
            => _webElement.GetCssValue(property);
    }
}
