namespace QAutomation.Appium.Engine
{
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Interfaces.Mobile;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class AndroidDriverManager<TMobileElement> : IMobileElementFinderService<TMobileElement>
        where TMobileElement : class, IMobileElement
    {
        public TMobileElement FindElementByAccessibilityId(string accessibilityId, ILogger log)
        {
            return _elementFinderService.Find<TMobileElement>(_nativeDriver, Core.By.AccessibilityId(accessibilityId));
        }

        public TMobileElement FindElementByClassName(string className, ILogger log)
        {
            throw new NotImplementedException();
        }

        public TMobileElement FindElementById(string id, ILogger log)
        {
            return _elementFinderService.Find<TMobileElement>(_nativeDriver, Core.By.Id(id));
        }

        public TMobileElement FindElementByTagName(string tagName, ILogger log)
        {
            return _elementFinderService.Find<TMobileElement>(_nativeDriver, Core.By.Tag(tagName));
        }

        public TMobileElement FindElementByXPath(string xpath, ILogger log)
        {
            return _elementFinderService.Find<TMobileElement>(_nativeDriver, Core.By.XPath(xpath));
        }

        public IEnumerable<TMobileElement> FindElementsByAccessibilityId(string accessibilityId, ILogger log)
        {
            return _elementFinderService.FindAll<TMobileElement>(_nativeDriver, Core.By.AccessibilityId(accessibilityId));
        }

        public IEnumerable<TMobileElement> FindElementsByClassName(string className, ILogger log)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TMobileElement> FindElementsById(string id, ILogger log)
        {
            return _elementFinderService.FindAll<TMobileElement>(_nativeDriver, Core.By.Id(id));
        }

        public IEnumerable<TMobileElement> FindElementsByTagName(string tagName)
        {
            return _elementFinderService.FindAll<TMobileElement>(_nativeDriver, Core.By.Tag(tagName));
        }

        public IEnumerable<TMobileElement> FindElementsByXPath(string xpath, ILogger log)
        {
            return _elementFinderService.FindAll<TMobileElement>(_nativeDriver, Core.By.XPath(xpath));
        }

        public T FindElementByClassName<T>(string className, ILogger log) where T : class, IElement
        {
            //return _elementFinderService.Find<T>(_nativeDriver, Core.By.CssClass(className));

            throw new Exception();
        }

        public T FindElementById<T>(string id, ILogger log) where T : class, IElement
        {
            return _elementFinderService.Find<T>(_nativeDriver, Core.By.Id(id));
        }

        public T FindElementByTagName<T>(string tagName, ILogger log) where T : class, IElement
        {
            return _elementFinderService.Find<T>(_nativeDriver, Core.By.Tag(tagName));
        }

        public T FindElementByXPath<T>(string xpath, ILogger log) where T : class, IElement
        {
            return _elementFinderService.Find<T>(_nativeDriver, Core.By.XPath(xpath));
        }

        public IEnumerable<T> FindElementsByClassName<T>(string className, ILogger log) where T : class, IElement
        {
            //return _elementFinderService.FindAll<T>(_nativeDriver, Core.By.CssClass(className));
            throw new Exception();
        }

        public IEnumerable<T> FindElementsById<T>(string id, ILogger log) where T : class, IElement
        {
            return _elementFinderService.FindAll<T>(_nativeDriver, Core.By.Id(id));
        }

        public IEnumerable<T> FindElementsByTagName<T>(string tagName, ILogger log) where T : class, IElement
        {
            return _elementFinderService.FindAll<T>(_nativeDriver, Core.By.Tag(tagName));
        }

        public IEnumerable<T> FindElementsByXPath<T>(string xpath, ILogger log) where T : class, IElement
        {
            return _elementFinderService.FindAll<T>(_nativeDriver, Core.By.XPath(xpath));
        }

        public IEnumerable<TMobileElement> FindElementsByTagName(string tagName, ILogger log)
        {
            return _elementFinderService.FindAll<TMobileElement>(_nativeDriver, Core.By.Tag(tagName));
        }
    }
}
