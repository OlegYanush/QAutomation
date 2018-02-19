namespace QAutomation.Selenium.Support
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.PageObjects;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Selenium.Extensions;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class QAutomationElementLocator : IUiElementLocator
    {
        private IElementLocator _locator;
        private IElementResolver _resolver;

        public QAutomationElementLocator(ISearchContext searchContext, IElementResolver resolver)
           : this(resolver, new DefaultElementLocator(searchContext)) { }

        public QAutomationElementLocator(IElementResolver resolver, IElementLocator locator)
        {
            _resolver = resolver;
            _locator = locator;
        }

        public ISearchContext SearchContext => _locator.SearchContext;

        public IWebElement LocateElement(IEnumerable<By> bys)
            => _locator.LocateElement(bys);

        public ReadOnlyCollection<IWebElement> LocateElements(IEnumerable<By> bys)
            => _locator.LocateElements(bys);

        public TUiElement LocateElement<TUiElement>(IEnumerable<Locator> locators)
            where TUiElement : IUiElement
        {
            var bys = new List<By>();

            foreach (var locator in locators)
                bys.Add(locator.ToNativeBy());

            return _resolver.Resolve<TUiElement>(_locator.SearchContext, _locator.LocateElement(bys), null);
        }

        public ReadOnlyCollection<TUiElement> LocateElements<TUiElement>(IEnumerable<Locator> locators)
            where TUiElement : IUiElement
        {
            var bys = new List<By>();
            var resolved = new List<TUiElement>();

            foreach (var locator in locators)
                bys.Add(locator.ToNativeBy());

            var elements = _locator.LocateElements(bys);

            foreach (var element in elements)
                resolved.Add(_resolver.Resolve<TUiElement>(_locator.SearchContext, element, null));

            return resolved.AsReadOnly();
        }
    }
}
