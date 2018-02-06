namespace QAutomation.Appium
{
    using OpenQA.Selenium;
    using QAutomation.Appium.Engine;
    using QAutomation.Core;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;

    public class UiObject : IUiObject
    {
        private ElementFinderService _elementFinderService;

        protected IWebElement _wrappedElement;

        public string Name { get; set; }

        public string Tag => _wrappedElement.TagName;
        public string Content => _wrappedElement.Text;

        public IWebElement WrappedElement => _wrappedElement;

        public UiObject(IWebElement element, IUnityContainer container)
        {
            _wrappedElement = element;
            _elementFinderService = new ElementFinderService(container);
        }

        public TUiObject Find<TUiObject>(Locator locator, ILogger log) where TUiObject : IUiObject
        {
            return _elementFinderService.Find<TUiObject>(_wrappedElement, locator);
        }
        public IEnumerable<TUiObject> FindAll<TUiObject>(Locator locator, ILogger log) where TUiObject : IUiObject
        {
            return _elementFinderService.FindAll<TUiObject>(_wrappedElement, locator);
        }

        public string GetAttribute(string attribute)
            => _wrappedElement.GetAttribute(attribute);
    }
}
