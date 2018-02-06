namespace QAutomation.Appium.Engine.Android
{
    using OpenQA.Selenium.Appium.Android;
    using QAutomation.Appium.Configs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;

    public partial class WrappedAndroidDriver
    {
        private AndroidDriverConfig _config;
        private AndroidDriver<AndroidElement> _nativeDriver;

        private ElementFinderService _elementFinderService;

        public AndroidDriverConfig Config => _config;
        public AndroidDriver<AndroidElement> WrappedDriver => _nativeDriver;

        public WrappedAndroidDriver(AndroidDriver<AndroidElement> nativeDriver, AndroidDriverConfig config, IUnityContainer container)
        {
            _config = config;
            _nativeDriver = nativeDriver;
            _elementFinderService = new ElementFinderService(container);
        }
    }
}
