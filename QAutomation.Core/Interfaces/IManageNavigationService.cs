namespace QAutomation.Core.Interfaces
{
    using QAutomation.Logger;

    public interface IManageNavigationService
    {
        void Back(ILogger log);
        void Refresh(ILogger log);
        void Forward(ILogger log);

        void Navigate(string absoluteUrl, ILogger log);
        void Navigate(string currentLocation, string relativeUrl, ILogger log);
    }
}
