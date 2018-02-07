namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;

    public interface INavigationService
    {
        string Url { get; set; }
        string Title { get; set; }

        void Back(ILogger log);
        void Refresh(ILogger log);
        void Forward(ILogger log);

        void NavigateByAbsoluteUrl(string absoluteUrl, ILogger log);
        void Navigate(string currentLocation, string relativeUrl, ILogger log);
    }
}
