namespace QAutomation.Core.Locators
{
    using Enums;

    public class Locator
    {
        public Locator Parent { get; set; }
        public string Value { get; protected set; }
        public SearchCriteria Type { get; protected set; }

        public Locator(string value, SearchCriteria type, Locator parent = null)
        {
            Parent = parent;

            Value = value;
            Type = type;
        }

        public static Locator Id(string id, Locator parent = null) 
            => new Locator(id, SearchCriteria.Id, parent);

        public static Locator Name(string name, Locator parent = null) 
            => new Locator(name, SearchCriteria.Name, parent);

        public static Locator XPath(string xpath, Locator parent = null) 
            => new Locator(xpath, SearchCriteria.XPath, parent);

        public static Locator TagName(string tagName, Locator parent = null) 
            => new Locator(tagName, SearchCriteria.TagName, parent);

        public static Locator LinkText(string linkText, Locator parent = null) => 
            new Locator(linkText, SearchCriteria.LinkText, parent);

        public static Locator ClassName(string className, Locator parent = null) 
            => new Locator(className, SearchCriteria.ClassName, parent);

        public static Locator CssSelector(string cssSelector, Locator parent = null) 
            => new Locator(cssSelector, SearchCriteria.CssSelector, parent);

        public static Locator PartialLinkText(string partialLinkText, Locator parent = null) 
            => new Locator(partialLinkText, SearchCriteria.PartialLinkText, parent);

        public override string ToString() => $"[Type: {Type}, Value: {Value}]";
    }
}
