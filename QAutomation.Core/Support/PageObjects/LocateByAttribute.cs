namespace QAutomation.Core.Support.PageObjects
{
    using QAutomation.Core.Enums;
    using QAutomation.Core.Locators;
    using System;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class LocateByAttribute : Attribute
    {
        private Locator _locator;

        public LocateByAttribute() { }
        public LocateByAttribute(string locator)
        {
            Using = locator;
        }
        public LocateByAttribute(string locator, SearchCriteria how)
        {
            How = how;
            Using = locator;
        }

        public SearchCriteria How { get; set; } = SearchCriteria.XPath;

        public string Using { get; set; }

        internal Locator Locator
        {
            get
            {
                if (_locator == null)
                    _locator = new Locator(Using, How);

                return _locator;
            }
        }
    }
}
