namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using QAutomation.Selenium.Configs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;

    public partial class WebDriverWrapper
    {
        private WebDriverWait _wait;
        private IWebDriver _wrappedDriver;

        private MobileDriverConfig _config;
        private ElementFinderService _elementFinderService;

        public WebDriverWrapper(MobileDriverConfig config, IUnityContainer container)
        {
            _config = config;
            _wrappedDriver = _config.CreateDriver();

            _elementFinderService = new ElementFinderService(container);
        }
    }
}
