namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;

    public interface IJsExecutor
    {
        string ExecuteJavaScript(string script, ILogger log);
    }
}
