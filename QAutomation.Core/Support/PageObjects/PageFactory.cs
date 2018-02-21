namespace QAutomation.Core.Support.PageObjects
{
    using QAutomation.Core.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class PageFactory
    {
        public static void InitUiElements(object page, IUiElementLocator locator, IPageObjectDecorator decorator)
        {
            if (page == null)
                throw new ArgumentNullException(nameof(page), "page cannot be null");

            if (locator == null)
                throw new ArgumentNullException(nameof(locator), "locator cannot be null");

            if (decorator == null)
                throw new ArgumentNullException(nameof(decorator), "decorator cannot be null");

            decorator.Decorate(locator, page);
        }

        public static T InitUiElements<T>(IUiElementLocator locator)
        {
            T page = default(T);

            Type pageClassType = typeof(T);
            ConstructorInfo ctor = pageClassType.GetConstructor(new Type[] { typeof(IBrowserDriver) });

            if (ctor == null)
                throw new ArgumentException($"No constructor for the specified class containing a single argument of type {nameof(IBrowserDriver)} can be found");

            if (locator == null)
                throw new ArgumentNullException(nameof(locator), "locator cannot be null");

            IBrowserDriver driver = locator.UiElementFinder as IBrowserDriver;

            if (driver == null)
                throw new ArgumentException("The ui element finder of the locator must implement IBrowesDriver", nameof(locator));

            page = (T)ctor.Invoke(new object[] { driver });

            InitUiElements(page, locator);
            return page;
        }

        public static T InitUiElements<T>(IUiElementFinder finder)
            => InitUiElements<T>(new DefaultUiElementLocator(finder));

        public static void InitUiElements(IUiElementFinder finder, object page, IPageObjectDecorator decorator)
            => InitUiElements(page, new DefaultUiElementLocator(finder), decorator);

        private static void InitUiElements<T>(T page, IUiElementLocator locator)
            => InitUiElements(page, locator, new DefaultPageObjectDecorator());
    }
}
