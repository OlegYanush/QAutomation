namespace QAutomation.Core.Support.PageObjects
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocatedOfAttribute : Attribute
    {
        public LocatedOfAttribute(string propertyName)
        {
            Property = propertyName;
        }

        public string Property { get; set; }
    }
}
