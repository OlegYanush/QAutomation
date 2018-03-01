namespace QAutomation.Selenium.Extensions
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using System;

    public static class IUiElementExtension
    {
        public static IWraps<IWebElement> GetWrap(this IUiElement element)
        {
            var wraps = element as IWraps<IWebElement>;

            if (wraps == null)
                throw new InvalidCastException($"{element.GetType()} type need to implements {nameof(IWraps<IWebElement>)} interface.");

            return wraps;
        }
    }
}
