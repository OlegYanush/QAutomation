namespace QAutomation.Appium.Engine
{
    using OpenQA.Selenium.Appium.Android;
    using QAutomation.Core;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Interfaces.Mobile;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class AndroidDriverManager<TMobileElement> : IMobileDriver<TMobileElement>
        where TMobileElement : IMobileElement
    {
        public AndroidDriver<AndroidElement> WrappedDriver => _nativeDriver;

        public string DeviceTime => _nativeDriver.DeviceTime;

        public void ActivateIMEEngine(string imeEngine, ILogger log)
        {
            _nativeDriver.ActivateIMEEngine(imeEngine);
        }

        public void BackgroundApp(int seconds, ILogger log)
        {
            _nativeDriver.BackgroundApp(seconds);
        }

        public void CloseApp(ILogger log)
        {
            _nativeDriver.CloseApp();
        }

        public void DeactiveIMEEngine(ILogger log)
        {
            _nativeDriver.DeactiveIMEEngine();
        }

        public T FindByCssSelector<T>(string cssSelector, ILogger log, double timeoutInSec = -1) where T : IElement
        {
            throw new NotImplementedException();
        }

        public T FindElementByLinkText<T>(string linkText, ILogger log, double timeoutInSec = -1) where T : IElement
        {
            throw new NotImplementedException();
        }

        public IElement FindElementByLinkText(string linkText, ILogger log, double timeoutInSec = -1)
        {
            throw new NotImplementedException();
        }

        public T FindElementByName<T>(string name, ILogger log, double timeoutInSec = -1) where T : IElement
        {
            throw new NotImplementedException();
        }

        public IElement FindElementByName(string name, ILogger log, double timeoutInSec = -1)
        {
            throw new NotImplementedException();
        }

        public T FindElementByPartialLinkText<T>(string partialLinkText, ILogger log, double timeoutInSec = -1) where T : IElement
        {
            throw new NotImplementedException();
        }

        public IElement FindElementByPartialLinkText(string partialLinkText, ILogger log, double timeoutInSec = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindElementsByCssSelector<T>(string cssSelector, ILogger log, double timeoutInSec = -1) where T : IElement
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindElementsByLinkText<T>(string linkText, ILogger log, double timeoutInSec = -1) where T : IElement
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IElement> FindElementsByLinkText(string linkText, ILogger log, double timeoutInSec = -1)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindElementsByPartialLinkText<T>(string partialLinkText, ILogger log, double timeoutInSec = -1) where T : IElement
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IElement> FindElementsByPartialLinkText(string partialLinkText, ILogger log, double timeoutInSec = -1)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllContexts(ILogger log)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetAppStringDectionary(ILogger log, string language = null, string stringFile = null)
        {
            return _nativeDriver.GetAppStringDictionary(language, stringFile);
        }

        public string GetAutomationName(ILogger log)
        {
            return null;
        }

        public string GetContext(ILogger log)
        {
            return _nativeDriver.Context;
        }

        public string GetIMEActiveEngine(ILogger log)
        {
            return _nativeDriver.GetIMEActiveEngine();
        }

        public List<string> GetIMEAvailableEngines(ILogger log)
        {
            return _nativeDriver.GetIMEAvailableEngines();
        }

        public Location GetLocation(ILogger log)
        {
            var location = _nativeDriver.Location;

            return new Location { Altitude = location.Altitude, Latitude = location.Latitude, Longitude = location.Longitude };
        }

        public ScreenOrientation GetOrientation(ILogger log)
        {
            throw new Exception();
        }

        public string GetPlatformName(ILogger log)
        {
            throw new NotImplementedException();
        }

        public object GetSessionDetail(string detail, ILogger log)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> GetSessionDetails(ILogger log)
        {
            throw new NotImplementedException();
        }

        public void HideKeyboard(ILogger log)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> IFinderByName<T>(string name, ILogger log, double timeoutInSec = -1) where T : IElement
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IElement> IFinderByName(string name, ILogger log, double timeoutInSec = -1)
        {
            throw new NotImplementedException();
        }

        public void InstallApp(string appPath, ILogger log)
        {
            throw new NotImplementedException();
        }

        public bool IsAppInstalled(string boundleId, ILogger log)
        {
            throw new NotImplementedException();
        }

        public void IsIMEActive(ILogger log)
        {
            throw new NotImplementedException();
        }

        public void LaunchApp(ILogger log)
        {
            throw new NotImplementedException();
        }

        public byte[] PullFile(string pathOnDevice, ILogger log)
        {
            throw new NotImplementedException();
        }

        public byte[] PullFolder(string remotePath, ILogger log)
        {
            throw new NotImplementedException();
        }

        public void RemoveApp(string appId, ILogger log)
        {
            throw new NotImplementedException();
        }

        public void ResetApp(ILogger log)
        {
            throw new NotImplementedException();
        }

        public void Rotate(Dictionary<string, int> opts, ILogger log)
        {
            throw new NotImplementedException();
        }

        public void SetContext(string context, ILogger log)
        {
            throw new NotImplementedException();
        }

        public void SetLocation(Location location, ILogger log)
        {
            throw new NotImplementedException();
        }

        public void SetOrientation(ILogger log)
        {
            throw new NotImplementedException();
        }
    }
}
