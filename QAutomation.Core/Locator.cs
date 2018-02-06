namespace QAutomation.Core
{
    using Enums;

    public class Locator
    {
        public string Value { get; protected set; }
        public LocatorType Type { get; protected set; }

        protected Locator(string value, LocatorType type)
        {
            Value = value;
            Type = type;
        }

        public static Locator Id(string id) => new Locator(id, LocatorType.Id);
        public static Locator Name(string name) => new Locator(name, LocatorType.Name);
        public static Locator XPath(string xpath) => new Locator(xpath, LocatorType.XPath);
        public static Locator TagName(string tagName) => new Locator(tagName, LocatorType.TagName);
        public static Locator LinkText(string linkText) => new Locator(linkText, LocatorType.LinkText);
        public static Locator ClassName(string className) => new Locator(className, LocatorType.ClassName);
        public static Locator CssSelector(string cssSelector) => new Locator(cssSelector, LocatorType.CssSelector);
        public static Locator PartialLinkText(string partialLinkText) => new Locator(partialLinkText, LocatorType.PartialLinkText);
        public static Locator AccessibilityId(string accessibilityId) => new Locator(accessibilityId, LocatorType.AccessibilityId);

        public override string ToString() => $"[Type: {Type}, Value: {Value}]";
    }
}
