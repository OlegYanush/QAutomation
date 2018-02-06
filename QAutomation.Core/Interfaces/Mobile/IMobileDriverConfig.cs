namespace QAutomation.Core.Interfaces.Mobile
{
    using QAutomation.Core.Enums.Mobile;

    public interface IMobileDriverConfig
    {
        MobilePlatform Platform { get; set; }
        bool UseEmulator { get; set; }
        string Version { get; set; }

        IMobileDriver CreateDriver();
        IMobileDriver CreateEmulatorDriver();
        IMobileDriver CreateRealDeviceDriver();
    }
}
