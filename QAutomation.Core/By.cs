namespace QAutomation.Core
{
    using Enums;

    public class By
    {
        public SearchType Type { get; private set; }
        public string Value { get; private set; }


        public By(SearchType type, string value)
        {
            Type = type;
            Value = value;
        }


        public static By Id(string id) => new By(SearchType.Id, id);

        public static By LinkText(string linkText) => new By(SearchType.LinkText, linkText);

        public static By Tag(string tagName) => new By(SearchType.Tag, tagName);

        public static By CssClass(string className) => new By(SearchType.CssClass, className);

        public static By CssSelector(string cssSelector) => new By(SearchType.CssSelector, cssSelector);

        public static By Name(string name) => new By(SearchType.Name, name);

        public static By XPath(string xpath) => new By(SearchType.XPath, xpath);

        public static By AccessibilityId(string accessibilityId) => new By(SearchType.AccessibilyId, accessibilityId);

        public static By AndroidUIAutotomator(string uiAutomatorSelector) => new By(SearchType.AndroidUIAutomator, uiAutomatorSelector);

        public static By IosUIAutomation(string uiAutomationSelector) => new By(SearchType.IosAutomation, uiAutomationSelector);

        public static By IosNSPredicate(string iosNsPredicate) => new By(SearchType.IosNSPredicate, iosNsPredicate);
    }
}
