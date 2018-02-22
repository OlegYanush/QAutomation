namespace QAutomation.Core.Support.PageObjects
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class LocatedOfAttribute : Attribute
    {
        public LocatedOfAttribute(string memberName)
        {
            Member = memberName;
        }

        public string Member { get; set; }
    }
}
