namespace QAutomation.Core.Interfaces
{
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Logging;

    public interface IJsExecutor
    {
        object ExecuteJavaScript(string script, ILogger log);
        object ExecuteJavaScript(string script, object[] args, ILogger log);
        object ExecuteJavaScript(string script, IUiElement element, ILogger log);
    }
}
