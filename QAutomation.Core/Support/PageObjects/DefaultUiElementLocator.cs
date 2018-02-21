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

        public TUiElement LocateElement<TUiElement>(IEnumerable<Locator> locators, IUiElement parent = null)
            where TUiElement : IUiElement
        {
            if (locators == null)
                throw new ArgumentNullException(nameof(locators), "List of criteria may not be null");

            string errorString = null;

            foreach (var locator in locators)
            {
                try
                {
                    return (parent ?? _uiElementFinder).Find<TUiElement>(locator, null);
                }
                catch (UiElementNotFoundException)
                {
                    errorString = (errorString == null ? "Could not find element by : " : errorString + ", or: ") + locator;
                }
            }

            throw new UiElementNotFoundException(errorString);
        }

        public IEnumerable<TUiElement> LocateElements<TUiElement>(IEnumerable<Locator> locators, IUiElement parent = null)
            where TUiElement : IUiElement
        {
            if (locators == null)
                throw new ArgumentNullException(nameof(locators), "List of criteria may not be null");

            var elements = new List<TUiElement>();

            foreach (var locator in locators)
                elements.AddRange((parent ?? _uiElementFinder).FindAll<TUiElement>(locator, null));

            return elements;
        }
    }
}
