namespace QAutomation.Core
{
    using Enums;
    using Interfaces.Controls;

    public class By
    {

        public SearchType Type { get; private set; }
        public string Value { get; private set; }

        public IElement Parent { get; private set; }


        public By(SearchType type, string value) : this(type, value, null)
        {
        }

        public By(SearchType type, string value, IElement parent)
        {
            Type = type;
            Value = value;
            Parent = parent;
        }


        public static By Id(string id) => new By(SearchType.Id, id);

        public static By Id(string id, IElement parentElement) => new By(SearchType.Id, id, parentElement);

        public static By LinkText(string linkText) => new By(SearchType.LinkText, linkText);

        public static By CssClass(string cssClass, IElement parentElement) => new By(SearchType.CssClass, cssClass, parentElement);

        public static By Tag(string tagName) => new By(SearchType.Tag, tagName);

        public static By Tag(string tagName, IElement parentElement) => new By(SearchType.Tag, tagName, parentElement);

        public static By CssSelector(string cssSelector) => new By(SearchType.CssSelector, cssSelector);

        public static By CssSelector(string cssSelector, IElement parentElement) => new By(SearchType.CssSelector, cssSelector, parentElement);

        public static By Name(string name) => new By(SearchType.Name, name);

        public static By Name(string name, IElement parentElement) => new By(SearchType.Name, name, parentElement);

        public static By XPath(string xpath) => new By(SearchType.XPath, xpath);

        public static By XPath(string xpath, IElement parentElement) => new By(SearchType.XPath, xpath, parentElement);
    }
}
