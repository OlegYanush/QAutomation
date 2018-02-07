namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;

    public interface ICookieService
    {
        void AddCookie(string name, string value, string host, ILogger log);
        string GetCookie(string host, string name, ILogger log);
      
        void DeleteCookie(string name, ILogger log);
        void CleanAllCookies(ILogger log);
    }
}
