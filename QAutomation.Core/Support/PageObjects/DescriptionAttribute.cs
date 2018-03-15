namespace QAutomation.Core.Support.PageObjects
{
    using System;

    public class DescriptionAttribute : Attribute
    {
        public string Description { get; private set; }

        protected DescriptionAttribute(string description)
        {
            Description = description;
        }
    }
}
