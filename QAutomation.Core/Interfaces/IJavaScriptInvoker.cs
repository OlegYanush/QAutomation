namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;

    public interface IJavaScriptInvoker
    {
        string InvokeJavaScript(string script, ILogger log);
    }
}
