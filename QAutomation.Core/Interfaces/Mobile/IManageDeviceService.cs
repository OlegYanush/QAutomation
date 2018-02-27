namespace QAutomation.Core.Interfaces.Mobile
{
    using Enums.Mobile;
    using QAutomation.Logging;
    using System.Collections.Generic;

    public interface IManageDeviceService
    {
        string DeviceTime { get; }

        Location GetLocation(ILogger log);
        void SetLocation(Location location, ILogger log);

        string GetContext(ILogger log);
        void SetContext(string context, ILogger log);

        ScreenOrientation GetOrientation(ILogger log);
        void SetOrientation(ScreenOrientation orientation, ILogger log);

        List<string> GetAllContexts(ILogger log);

        void Rotate(Dictionary<string, int> opts, ILogger log);
        void HideKeyboard(ILogger log);

        byte[] PullFile(string pathOnDevice, ILogger log);
        byte[] PullFolder(string remotePath, ILogger log);
    }
}
