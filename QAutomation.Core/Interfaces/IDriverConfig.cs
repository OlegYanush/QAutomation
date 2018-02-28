namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Configuration;

    public interface IDriverConfig
    {
        TimeoutSettings Timeouts { get; }
    }
}
