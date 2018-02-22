namespace QAutomation.Core.Support.PageObjects
{
    using System;
    using System.Collections.Generic;
    using QAutomation.Core.Exceptions;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;

    public class DefaultUiElementLocator : IUiElementLocator
    {
        private IUiElementFinder _uiElementFinder;

        public IUiElementFinder UiElementFinder => _uiElementFinder;

        public DefaultUiElementLocator(IUiElementFinder elementFinder)
        {
            _uiElementFinder = elementFinder;
        }

        private TUiElement FindElement<TUiElement>(IUiElementFinder searchContext, IEnumerable<Locator> locators)
        where TUiElement : IUiElement
        {
            if (locators == null)
                throw new ArgumentNullException(nameof(locators), "List of criteria may not be null");

            string errorString = null;

            foreach (var locator in locators)
            {
                try
                {
                    return searchContext.Find<TUiElement>(locator, null);
                }
                catch (UiElementNotFoundException)
                {
                    errorString = (errorString == null ? "Could not find element by : " : errorString + ", or: ") + locator;
                }
            }

            throw new UiElementNotFoundException(errorString);
        }

        public TUiElement LocateElementInParent<TUiElement>(IUiElement parent, IEnumerable<Locator> locators)
            where TUiElement : IUiElement => FindElement<TUiElement>(parent, locators);

        public TUiElement LocateElement<TUiElement>(IEnumerable<Locator> locators)
            where TUiElement : IUiElement => FindElement<TUiElement>(_uiElementFinder, locators);


        private IEnumerable<TUiElement> FindAll<TUiElement>(IUiElementFinder searchContext, IEnumerable<Locator> locators)
          where TUiElement : IUiElement
        {
            if (locators == null)
                throw new ArgumentNullException(nameof(locators), "List of criteria may not be null");

            var elements = new List<TUiElement>();

            foreach (var locator in locators)
                elements.AddRange(searchContext.FindAll<TUiElement>(locator, null));

            return elements;
        }

        public IEnumerable<TUiElement> LocateElementsInParent<TUiElement>(IUiElement parent, IEnumerable<Locator> locators)
            where TUiElement : IUiElement => FindAll<TUiElement>(_uiElementFinder, locators);

        public IEnumerable<TUiElement> LocateElements<TUiElement>(IEnumerable<Locator> locators)
            where TUiElement : IUiElement => FindAll<TUiElement>(_uiElementFinder, locators);
    }
}
