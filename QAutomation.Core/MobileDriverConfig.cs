namespace QAutomation.Core
{
    using Enums;
    using QAutomation.Core.Enums.Mobile;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public abstract class MobileDriverConfig
    {
        public bool UseEmulator { get; set; }

        public double ImplicitWaitTimeoutInSec { get; set; }
        public double ExplicitWaitTimeoutInSec { get; set; }

        public double HttpCommandTimeoutInSec { get; set; }
        public double JavaScriptTimeoutInSec { get; set; }

        public double PoolingIntervalInSec { get; set; }

        public Uri RemoteAddressServerUri { get; set; }

        public abstract Platform Platform { get; }
        public string Version { get; set; }

        public string DeviceName { get; set; }
        public string AutomationName { get; set; }

        public string DeviceId { get; set; }
        public string PathToApp { get; set; }

        public string BrowserName { get; set; }
        public string Locale { get; set; }

        public bool NoReset { get; set; }
        public bool FullReset { get; set; }

        public ScreenOrientation Orientation { get; set; } = ScreenOrientation.Landscape;

        public New.IMobileDriver CreateDriver => UseEmulator ? CreateEmulatorDriver() : CreateRealDeviceDriver();

        public abstract New.IMobileDriver CreateEmulatorDriver();
        public abstract New.IMobileDriver CreateRealDeviceDriver();
    }
}
