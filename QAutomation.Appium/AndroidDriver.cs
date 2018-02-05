using OpenQA.Selenium.Appium.Android;
using QAutomation.Appium.Engine;
using QAutomation.Core;
using QAutomation.Core.New;
using QAutomation.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace QAutomation.Appium
{
    public class AndroidDriver : IMobileDriver
    {
        private AndroidDriver<AndroidElement> _nativeDriver;
        private ElementFinderService _elementFinderService;

        public AndroidDriver(AndroidDriver<AndroidElement> driver, IUnityContainer container)
        {
            _nativeDriver = driver;
            _elementFinderService = new ElementFinderService(container);

        }

        public TUiObject Find<TUiObject>(Locator locator, ILogger log) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TUiObject> FindAll<TUiObject>(Locator locator, ILogger log) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TUiObject> FindAllByAccessibilityId<TUiObject>(string accessibilityId, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TUiObject> FindAllByClassName<TUiObject>(string className, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TUiObject> FindAllByCssSelector<TUiObject>(string cssSelector, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TUiObject> FindAllById<TUiObject>(string id, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TUiObject> FindAllByXPath<TUiObject>(string xpath, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public TUiObject FindByAccessibilityId<TUiObject>(string accessibilityId, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public TUiObject FindByClassName<TUiObject>(string className, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public TUiObject FindByCssSelector<TUiObject>(string cssSelector, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }


        public TUiObject FindById<TUiObject>(string id, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }

        public TUiObject FindByXPath<TUiObject>(string xpath, double timeoutInSec = -1) where TUiObject : IUiObject
        {
            throw new NotImplementedException();
        }
    }
}
