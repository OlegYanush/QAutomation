namespace QAutomation.Appium.Engine.Android
{
    using QAutomation.Core;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Interfaces.Mobile;
    using QAutomation.Logger;
    using System.Collections.Generic;

    public partial class WrappedAndroidDriver : IUiElementFinderService, IFinderByAccessibilyId
    {
        public TUiObject Find<TUiObject>(Locator locator, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find(_elementFinderService.Find<TUiObject>, locator, log, timeoutInSec);

        public IEnumerable<TUiObject> FindAll<TUiObject>(Locator locator, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll(_elementFinderService.FindAll<TUiObject>, locator, log, timeoutInSec);

        public TUiObject FindElementByAccessibilityId<TUiObject>(string accessibilityId, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find<TUiObject>(Locator.AccessibilityId(accessibilityId), log, timeoutInSec);

        public TUiObject FindElementByClassName<TUiObject>(string className, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find<TUiObject>(Locator.ClassName(className), log, timeoutInSec);

        public TUiObject FindElementByCssSelector<TUiObject>(string cssSelector, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find<TUiObject>(Locator.CssSelector(cssSelector), log, timeoutInSec);

        public TUiObject FindElementById<TUiObject>(string id, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find<TUiObject>(Locator.Id(id), log, timeoutInSec);

        public TUiObject FindElementByLinkText<TUiObject>(string linkText, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find<TUiObject>(Locator.LinkText(linkText), log, timeoutInSec);

        public TUiObject FindElementByName<TUiObject>(string name, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find<TUiObject>(Locator.Name(name), log, timeoutInSec);

        public TUiObject FindElementByPartialLinkText<TUiObject>(string partialLinkText, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find<TUiObject>(Locator.PartialLinkText(partialLinkText), log, timeoutInSec);

        public TUiObject FindElementByTagName<TUiObject>(string tagName, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find<TUiObject>(Locator.TagName(tagName), log, timeoutInSec);

        public TUiObject FindElementByXPath<TUiObject>(string xpath, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => Find<TUiObject>(Locator.XPath(xpath), log, timeoutInSec);

        public IEnumerable<TUiObject> FindElementsByAccessibilityId<TUiObject>(string accessibilityId, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll<TUiObject>(Locator.AccessibilityId(accessibilityId), log, timeoutInSec);

        public IEnumerable<TUiObject> FindElementsByClassName<TUiObject>(string className, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll<TUiObject>(Locator.ClassName(className), log, timeoutInSec);

        public IEnumerable<TUiObject> FindElementsByCssSelector<TUiObject>(string cssSelector, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll<TUiObject>(Locator.CssSelector(cssSelector), log, timeoutInSec);

        public IEnumerable<TUiObject> FindElementsById<TUiObject>(string id, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll<TUiObject>(Locator.Id(id), log, timeoutInSec);

        public IEnumerable<TUiObject> FindElementsByLinkText<TUiObject>(string linkText, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll<TUiObject>(Locator.LinkText(linkText), log, timeoutInSec);

        public IEnumerable<TUiObject> FindElementsByName<TUiObject>(string name, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll<TUiObject>(Locator.Name(name), log, timeoutInSec);

        public IEnumerable<TUiObject> FindElementsByPartialLinkText<TUiObject>(string partialLinkText, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll<TUiObject>(Locator.PartialLinkText(partialLinkText), log, timeoutInSec);

        public IEnumerable<TUiObject> FindElementsByTagName<TUiObject>(string tagName, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll<TUiObject>(Locator.TagName(tagName), log, timeoutInSec);

        public IEnumerable<TUiObject> FindElementsByXPath<TUiObject>(string xpath, ILogger log, double timeoutInSec = -1) where TUiObject : IUiElement
            => FindAll<TUiObject>(Locator.XPath(xpath), log, timeoutInSec);
    }
}
