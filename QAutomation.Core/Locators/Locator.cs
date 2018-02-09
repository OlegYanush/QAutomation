namespace QAutomation.Core.Locators
{
    using Enums;

    public class Locator
    {
        public string Value { get; protected set; }
        public SearchCriteria Type { get; protected set; }

        public Locator(string value, SearchCriteria type)
        {
            Value = value;
            Type = type;
        }

        public static Locator Id(string id) => new Locator(id, SearchCriteria.Id);
        public static Locator Name(string name) => new Locator(name, SearchCriteria.Name);

        public static Locator XPath(string xpath) => new Locator(xpath, SearchCriteria.XPath);
        public static Locator TagName(string tagName) => new Locator(tagName, SearchCriteria.TagName);

        public static Locator LinkText(string linkText) => new Locator(linkText, SearchCriteria.LinkText);
        public static Locator ClassName(string className) => new Locator(className, SearchCriteria.ClassName);

        public static Locator CssSelector(string cssSelector) => new Locator(cssSelector, SearchCriteria.CssSelector);
        public static Locator PartialLinkText(string partialLinkText) => new Locator(partialLinkText, SearchCriteria.PartialLinkText);

        public override string ToString() => $"[Type: {Type}, Value: {Value}]";
    }
}
