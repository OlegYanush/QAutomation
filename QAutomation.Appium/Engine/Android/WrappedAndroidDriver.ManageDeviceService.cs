namespace QAutomation.Appium.Engine.Android
{
    using QAutomation.Core;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces.Mobile;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public partial class WrappedAndroidDriver : IManageDeviceService
    {
        public string DeviceTime => _nativeDriver.DeviceTime;

        public List<string> GetAllContexts(ILogger log)
        {
            log?.DEBUG("Get all contexts for the Device.");

            try
            {
                var contexts = _nativeDriver.Contexts;
                log?.INFO($"Getting all contexts for Device successfully completed. Contexts = [{string.Join(",", contexts)}].");

                return new List<string>(contexts);
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting all contexts for the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public string GetContext(ILogger log)
        {
            log?.DEBUG("Get current context for the Device.");

            try
            {
                var context = _nativeDriver.Context;
                log?.INFO($"Getting current context for Device successfully completed. Context = '{string.Join(",", context)}'.");

                return context;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting current context for the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public Location GetLocation(ILogger log)
        {
            log?.DEBUG("Get current location for the Device.");

            try
            {
                var location = _nativeDriver.Location;
                log?.INFO($"Getting current location for Device successfully completed. Location = '{location}'.");

                return new Location
                {
                    Altitude = location.Altitude,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude
                };
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting current location for the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public ScreenOrientation GetOrientation(ILogger log)
        {
            throw new NotImplementedException();
        }

        public void HideKeyboard(ILogger log)
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

        public void SetOrientation(ScreenOrientation orientation, ILogger log)
        {
            throw new NotImplementedException();
        }
    }
}
