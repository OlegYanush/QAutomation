namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logging;

    public interface IJsExecutor
    {
        object ExecuteJavaScript(string script, object[] args, ILogger log);
    }
}
