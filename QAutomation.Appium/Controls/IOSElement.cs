namespace QAutomation.Appium.Controls
{
    using OpenQA.Selenium.Appium;
    using QAutomation.Appium.Engine;
    using QAutomation.Core.Interfaces.Controls;
    using System.Collections.Generic;
    using System.Drawing;
    using Unity;
    using IosElement = OpenQA.Selenium.Appium.iOS.IOSElement;

    public class IOSElement : IMobileElement
    {
        private AppiumDriver<IosElement> _appiumDriver;
        private IosElement _iosElement;

        private ElementFinderService _elementFinderService;

        public IOSElement(AppiumDriver<IosElement> driver, IosElement element, IUnityContainer container)
        {
            _appiumDriver = driver;
            _iosElement = element;
            _elementFinderService = new ElementFinderService(container);
        }

        public bool Displayed => _iosElement.Displayed;
        public bool Enabled => _iosElement.Enabled;

        public Point Location => _iosElement.Location;
        public string Content => _iosElement.Text;

        public string Tag => _iosElement.TagName;
        public Size Size => _iosElement.Size;

        public IMobileElement FindElementByPlatformSelector(string selector)
        {
            //var element = _iosElement.FindElementByIosUIAutomation(selector);

            //var resolved = _elementFinderService.Resolve<IMobileElement>(_appiumDriver, element);

            //return resolved;
            return null;
        }

        public IEnumerable<IMobileElement> FindElementsByPlatformSelector(string selector)
        {
            return null;

            //var elements = _iosElement.FindElementsByIosUIAutomation(selector);

            //var resolved = new List<IMobileElement>();

            //foreach (var element in elements)
            //    resolved.Add(_elementFinderService.Resolve<IMobileElement>(_appiumDriver, element));

            //return resolved;
        }

        public string GetAttribute(string attribute)
            => _iosElement.GetAttribute(attribute);

        public string GetCssValue(string property)
            => _iosElement.GetAttribute(property);
    }
}
