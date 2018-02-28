namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Enums;

    public interface IBrowserDriverConfig : IDriverConfig
    {
        Browsers Browser { get; }
        string Version { get; }
    }
}
