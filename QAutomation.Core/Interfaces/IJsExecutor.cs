namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logging;

    public interface IJsExecutor
    {
        string ExecuteJavaScript(string script, ILogger log);
    }
}
