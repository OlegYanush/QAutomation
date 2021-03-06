﻿namespace QAutomation.Core.Locators.Mobile
{
    using Enums;

    public class UiSelector : MobileLocator
    {
        public UiSelector()
            : base("new UiSelector()", SearchCriteria.UiSelector) { }

        public UiSelector(string value)
            : base(value, SearchCriteria.UiSelector) { }

        public UiSelector ClassNameMatches(string regex)
            => AppendProperty("classNameMatches", regex);
        public UiSelector ResourceId(string resourceId)
          => AppendProperty("resourceId", resourceId);
        public new UiSelector ClassName(string className)
            => AppendProperty("className", className);
        public UiSelector Clickable(bool value)
            => AppendProperty("clickable", value.ToString().ToLowerInvariant());
        public UiSelector Text(string text)
            => AppendProperty("text", text);
        public UiSelector Index(int index)
            => AppendProperty("index", index.ToString());
        public UiSelector Checked(bool value)
            => AppendProperty("checked", value.ToString().ToLowerInvariant());
        public UiSelector Enabled(bool value)
            => AppendProperty("enabled", value.ToString().ToLowerInvariant());
        public UiSelector Description(string description)
            => AppendProperty("description", description);
        public UiSelector DescriptionContains(string description)
            => AppendProperty("descriptionContains", description);
        public UiSelector DescriptionMatches(string regex)
            => AppendProperty("descriptionMatches", regex);

        private UiSelector AppendProperty(string propertyName, string PropertyValue)
        {
            Value += $".{propertyName}(\"{PropertyValue}\")";
            return this;
        }
    }
}
