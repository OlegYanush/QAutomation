using OpenQA.Selenium.Remote;
using QAutomation.Core;
using QAutomation.Core.Enums;
using QAutomation.Core.New;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace QAutomation.Appium
{
    public class IosDriverConfig : MobileDriverConfig
    {
        public override Platform Platform => Platform.IOS;

        public IUnityContainer Container { get; set; }

        public override IMobileDriver CreateEmulatorDriver()
        {
            throw new NotImplementedException();
        }

        public override IMobileDriver CreateRealDeviceDriver()
        {
            throw new NotImplementedException();
        }

        private DesiredCapabilities GetRealDeviceCapabilities()
        {
            return null;
        }

        private DesiredCapabilities GetEmulatorCapabilities()
        {
            return null;
        }
    }
}
