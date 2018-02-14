namespace QAutomation.Selenium.Attributes
{
    using QAutomation.Core.Enums;
    using QAutomation.Core.Locators;
    using System;
    using System.ComponentModel;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class QAutomationFindByAttribute : Attribute
    {
        private Locator _locator = null;

        [DefaultValue(SearchCriteria.XPath)]
        public SearchCriteria How { get; set; }

        public string Using { get; set; }

        internal Locator Locator
        {
            get
            {
                if (_locator == null)
                    _locator = new Locator(Using, How);

                return _locator;
            }
            set { _locator = value; }
        }
    }
}
