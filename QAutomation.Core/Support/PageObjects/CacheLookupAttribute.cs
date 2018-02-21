namespace QAutomation.Core.Support.PageObjects
{
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
    public sealed class CacheLookupAttribute : Attribute { }

}
