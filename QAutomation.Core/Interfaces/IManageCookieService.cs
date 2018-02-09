namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;

    public interface IManageCookieService
    {
        void AddCookie(string name, string value, ILogger log);
        string GetCookie(string name, ILogger log);

        void DeleteCookie(string name, ILogger log);
        void DeleteAllCookies(ILogger log);
    }
}
