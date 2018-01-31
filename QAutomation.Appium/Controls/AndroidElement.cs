namespace QAutomation.Appium.Controls
{
    using OpenQA.Selenium.Appium.Android;
    using QAutomation.Appium.Engine;
    using QAutomation.Core.Interfaces.Controls;
    using System.Collections.Generic;
    using System.Drawing;
    using Unity;
    using DroidElement = OpenQA.Selenium.Appium.Android.AndroidElement;

    public class AndroidElement : IMobileElement
    {
        private AndroidDriver<DroidElement> _appiumDriver;
        private DroidElement _androidElement;

        private ElementFinderService _finderElementService;

        public AndroidElement(AndroidDriver<DroidElement> driver, DroidElement element, IUnityContainer container)
        {
            _appiumDriver = driver;
            _androidElement = element;

            _finderElementService = new ElementFinderService(container);
        }

        public bool Displayed => _androidElement.Displayed;
        public bool Enabled => _androidElement.Enabled;

        public Point Location => _androidElement.Location;
        public string Content => _androidElement.Text;

        public string Tag => _androidElement.TagName;
        public Size Size => _androidElement.Size;

        public IMobileElement FindElementByPlatformSelector(string selector)
        {
            return null;

            //var element = _androidElement.FindElementByAndroidUIAutomator(selector);
            //var resolved = _finderElementService.Resolve<IMobileElement>(_androidElement, element);

            //return resolved;
        }

        public IEnumerable<IMobileElement> FindElementsByPlatformSelector(string selector)
        {
            return null;
            //var elements = _androidElement.FindElementsByAndroidUIAutomator(selector);
            //var resolved = new List<IMobileElement>();

            //foreach (var element in elements)
            //    resolved.Add(_finderElementService.Resolve<IMobileElement>(_appiumDriver, element));

            //return resolved;
        }

        public string GetAttribute(string attribute)
            => _androidElement.GetAttribute(attribute);

        public string GetCssValue(string property)
            => _androidElement.GetAttribute(property);
    }
}
