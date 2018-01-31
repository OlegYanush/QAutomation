using OpenQA.Selenium.Appium.Android;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Core.Interfaces.Mobile;
using QAutomation.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace QAutomation.Appium.Engine
{
    public partial class AndroidDriverManager<TMobileElement>
        where TMobileElement : class, IMobileElement
    {
        private AndroidDriver<AndroidElement> _nativeDriver;
        private ElementFinderService _elementFinderService;


        public AndroidDriverManager(AndroidDriver<AndroidElement> driver, IUnityContainer container)
        {
            _elementFinderService = new ElementFinderService(container);
            _nativeDriver = driver;
        }
    }
}
