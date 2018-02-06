namespace QAutomation.Appium.Engine.Android
{
    using QAutomation.Core;
    using QAutomation.Core.Enums.Mobile;
    using QAutomation.Core.Interfaces.Mobile;
    using QAutomation.Logger;
    using System;
    using System.Collections.Generic;

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
            log?.DEBUG("Get current orientation for the Device.");

            try
            {
                var orientation = _nativeDriver.Orientation;
                log?.INFO($"Getting current orientation for Device successfully completed. Orientation = '{orientation}'.");

                return orientation == OpenQA.Selenium.ScreenOrientation.Landscape
                    ? ScreenOrientation.Landscape
                    : ScreenOrientation.Portrait;
            }
            catch (Exception ex)
            {
                var message = "Error occurred during getting current orientation for the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void HideKeyboard(ILogger log)
        {
            log?.DEBUG("Hide keyboard for the Device.");

            try
            {
                _nativeDriver.HideKeyboard();
                log?.INFO($"Hiding keyboard for the Device successfully completed.");
            }
            catch (Exception ex)
            {
                var message = "Error occurred during hiding keyboard for the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public byte[] PullFile(string pathOnDevice, ILogger log)
        {
            log?.DEBUG($"Pull file from the Device by path = '{pathOnDevice}'.");

            try
            {
                var bytes = _nativeDriver.PullFile(pathOnDevice);
                log?.INFO($"Pulling file from the Device by path = '{pathOnDevice}' successfully completed.");

                return bytes;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during pulling file from the Device by path = '{pathOnDevice}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public byte[] PullFolder(string remotePath, ILogger log)
        {
            log?.DEBUG($"Pull folder from the Device by path = '{remotePath}'.");

            try
            {
                var bytes = _nativeDriver.PullFolder(remotePath);
                log?.INFO($"Pulling folder from the Device by path = '{remotePath}' successfully completed.");

                return bytes;
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during pulling folder from the Device by path = '{remotePath}'.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void Rotate(Dictionary<string, int> opts, ILogger log)
        {
            log?.DEBUG($"Rotate the Device.");

            try
            {
                _nativeDriver.Rotate(opts);
                log?.INFO($"Rotating the Device successfully completed.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during rotating the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SetContext(string context, ILogger log)
        {
            log?.DEBUG($"Set context = '{context}' for the Device.");

            try
            {
                 _nativeDriver.Context = context;
                log?.INFO($"Setting context for the Device. Current Context = '{string.Join(",", context)}'.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during setting context = '{context}' for the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SetLocation(Location location, ILogger log)
        {
            log?.DEBUG($"Set location = '{location}' for the Device.");

            try
            {
                _nativeDriver.Location = new OpenQA.Selenium.Appium.Location
                {
                    Altitude = location.Altitude,
                    Latitude = location.Latitude,
                    Longitude = location.Longitude
                };
                log?.INFO($"Setting location for the Device. Current location = '{location}'.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during setting location = '{location}' for the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }

        public void SetOrientation(ScreenOrientation orientation, ILogger log)
        {
            log?.DEBUG($"Set orientation = '{orientation}' for the Device.");

            try
            {
                _nativeDriver.Orientation = orientation == ScreenOrientation.Landscape
                    ? OpenQA.Selenium.ScreenOrientation.Landscape
                    : OpenQA.Selenium.ScreenOrientation.Portrait;

                log?.INFO($"Setting orientation for the Device. Current orientation = '{_nativeDriver.Orientation}'.");
            }
            catch (Exception ex)
            {
                var message = $"Error occurred during setting orientation = '{orientation}' for the Device.";
                log?.ERROR(message, ex);

                throw new Exception(message, ex);
            }
        }
    }
}
