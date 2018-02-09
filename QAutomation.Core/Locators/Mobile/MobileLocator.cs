namespace QAutomation.Core.Locators.Mobile
{
    using QAutomation.Core.Enums;

    public class MobileLocator : Locator
    {
        public MobileLocator(string value, SearchCriteria type)
            : base(value, type) { }

        public static MobileLocator UiSelector(string uiSelector) => new UiSelector(uiSelector);
        public static MobileLocator AccessibilityId(string accessibilityId) => new MobileLocator(accessibilityId, SearchCriteria.AccessibilityId);
    }
}
