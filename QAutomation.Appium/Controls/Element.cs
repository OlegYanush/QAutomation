using OpenQA.Selenium.Appium.Android;
using QAutomation.Appium.Engine;
using QAutomation.Core.Interfaces.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using DroidElement = OpenQA.Selenium.Appium.Android.AndroidElement;

namespace QAutomation.Appium.Controls
{
    public class Element : IElement
    {
        private AndroidDriver<DroidElement> _wrappedDriver;
        private DroidElement _wrappedElement;

        private ElementFinderService _elementFinderService;

        public Element(AndroidDriver<DroidElement> driver, DroidElement element, IUnityContainer container)
        {
            _wrappedDriver = driver;
            _wrappedElement = element;

            _elementFinderService = new ElementFinderService(container);
        }

        public IElement Parent => throw new NotImplementedException();

        public Core.By By { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Displayed => _wrappedElement.Displayed;

        public bool Enabled => _wrappedElement.Enabled;

        public Point Location => _wrappedElement.Location;

        public string Content => _wrappedElement.Text;

        public string Tag => _wrappedElement.TagName;

        public Size Size => _wrappedElement.Size;

        public string GetAttribute(string attribute)
        {
            return _wrappedElement.GetAttribute(attribute);
        }

        public string GetCssValue(string property)
        {
            return _wrappedElement.GetCssValue(property);
        }
    }
}
