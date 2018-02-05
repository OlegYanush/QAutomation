using QAutomation.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation.Core
{
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
        public static Locator XPath(string xpath) => new Locator(xpath, LocatorType.XPath);
        public static Locator ClassName(string className) => new Locator(className, LocatorType.ClassName);
        public static Locator CssSelector(string cssSelector) => new Locator(cssSelector, LocatorType.CssSelector);


        public override string ToString() => $"[Type: {Type}, Value: {Value}]";
    }
}
