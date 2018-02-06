namespace QAutomation.Appium.Engine.IOS
{
    using OpenQA.Selenium.Appium.iOS;
    using QAutomation.Appium.Configs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;

    public class IosMobileDriver 
    {
        private IOSDriver<IOSElement> _nativeDriver;
        public IOSDriver<IOSElement> WrappedDriver => _nativeDriver;

        public IosMobileDriver(IOSDriver<IOSElement> nativeDriver, IosDriverConfig config, IUnityContainer container)
        {
            _nativeDriver = nativeDriver;
        }
    }
}
