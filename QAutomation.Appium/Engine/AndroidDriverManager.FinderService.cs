using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using QAutomation.Core;
using QAutomation.Core.Interfaces;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Core.Interfaces.Mobile;
using QAutomation.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace QAutomation.Appium.Engine
{
    public partial class AndroidDriverManager<TMobileElement> : IMobileElementFinderService<TMobileElement>
        where TMobileElement : IMobileElement
    {
        private static TimeSpan DefaultImplicitTimeout = TimeSpan.FromSeconds(60);

        private AndroidDriver<AndroidElement> _nativeDriver;

        private ElementFinderService _elementFinderService;

        public AndroidDriverManager(AndroidDriver<AndroidElement> driver, IUnityContainer container)
        {
            _elementFinderService = new ElementFinderService(container);
            _nativeDriver = driver;
        }

        public T FindElementByAccessibilityId<T>(string accessibilityId, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => Find(_elementFinderService.Find<T>, Core.By.AccessibilityId(accessibilityId), log, timeoutInSec);

        private IEnumerable<T> FindAll<T>(Func<ISearchContext, Core.By, IEnumerable<T>> finder, Core.By by, ILogger log, double timeoutInSec = -1) where T : IElement
        {
            log?.DEBUG($"Find elements by {by}.");

            try
            {
                if (timeoutInSec > 0)
                    SetImplicitTimeout(timeoutInSec);

                var result = finder.Invoke(_nativeDriver, by);
                log?.INFO($"Finding elements by {by} successfully completed.");

                return result;
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during finding elements by {by}.", ex);
                throw;
            }
            finally
            {
                if (timeoutInSec > 0)
                    RestoreDefaultImpicitTimeout();
            }
        }
        private T Find<T>(Func<ISearchContext, Core.By, T> finderFunc, Core.By by, ILogger log, double timeoutInSec = -1)
        {
            log?.DEBUG($"Find element by {by}.");

            try
            {
                if (timeoutInSec > 0)
                    SetImplicitTimeout(timeoutInSec);

                var result = finderFunc.Invoke(_nativeDriver, by);
                log?.INFO($"Finding element by {by} successfully completed.");

                return result;
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during finding element by {by}.", ex);
                throw;
            }
            finally
            {
                if (timeoutInSec > 0)
                    RestoreDefaultImpicitTimeout();
            }
        }

        public T FindElementByXPath<T>(string xpath, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => Find(_elementFinderService.Find<T>, Core.By.XPath(xpath), log, timeoutInSec);

        public IElement FindElementByXPath(string xpath, ILogger log, double timeoutInSec = -1)
            => FindElementByXPath<TMobileElement>(xpath, log, timeoutInSec);

        public IEnumerable<T> FindElementsByAccessibilityId<T>(string accessibilityId, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => FindAll(_elementFinderService.FindAll<T>, Core.By.AccessibilityId(accessibilityId), log, timeoutInSec);

        public IEnumerable<T> FindElementsByXPath<T>(string xpath, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => FindAll(_elementFinderService.FindAll<T>, Core.By.XPath(xpath), log, timeoutInSec);

        public IEnumerable<IElement> FindElementsByXPath(string xpath, ILogger log, double timeoutInSec = -1)
        {
            var elements = new List<IElement>();

            foreach (var element in FindElementsByXPath<TMobileElement>(xpath, log, timeoutInSec))
                elements.Add(element);

            return elements;
        }

        public IEnumerable<T> FindElementsByClassName<T>(string className, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => FindAll(_elementFinderService.FindAll<T>, Core.By.CssClass(className), log, timeoutInSec);

        public T FindElementByClassName<T>(string className, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => Find(_elementFinderService.Find<T>, Core.By.CssClass(className), log, timeoutInSec);

        public IEnumerable<IElement> FindsElementByClassName(string className, ILogger log, double timeoutInSec = -1)
        {
            var elements = new List<IElement>();

            foreach (var element in FindElementsByClassName<TMobileElement>(className, log, timeoutInSec))
                elements.Add(element);

            return elements;
        }

        public IElement FindElementByClassName(string className, ILogger log, double timeoutInSec = -1)
            => FindElementByClassName<TMobileElement>(className, log, timeoutInSec);

        public IEnumerable<IElement> FindElementsByCssSelector(string cssSelector, ILogger log, double timeoutInSec = -1)
        {
            var elements = new List<IElement>();

            foreach (var element in FindElementsByCssSelector<TMobileElement>(cssSelector, log, timeoutInSec))
                elements.Add(element);

            return elements;
        }
        public IElement FindByCssSelector(string cssSelector, ILogger log, double timeoutInSec = -1)
            => FindByCssSelector<TMobileElement>(cssSelector, log, timeoutInSec);

        public IEnumerable<T> FindElementsById<T>(string id, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => FindAll(_elementFinderService.FindAll<T>, Core.By.Id(id), log, timeoutInSec);
        public IEnumerable<IElement> FindElementsById(string id, ILogger log, double timeoutInSec = -1)
        {
            var elements = new List<IElement>();

            foreach (var element in FindElementsById<TMobileElement>(id, log, timeoutInSec))
                elements.Add(element);

            return elements;
        }

        public T FindElementById<T>(string id, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => Find(_elementFinderService.Find<T>, Core.By.Id(id), log, timeoutInSec);
        public IElement FindElementById(string id, ILogger log, double timeoutInSec = -1)
          => FindElementById<TMobileElement>(id, log, timeoutInSec);


        public IEnumerable<T> FindElementsByTagName<T>(string tagName, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => FindAll(_elementFinderService.FindAll<T>, Core.By.Tag(tagName), log, timeoutInSec);


        public T FindElementByTagName<T>(string tagName, ILogger log, double timeoutInSec = -1) where T : TMobileElement
            => Find(_elementFinderService.Find<T>, Core.By.Tag(tagName), log, timeoutInSec);


        public IEnumerable<IElement> FindElementsByTagName(string tagName, ILogger log, double timeoutInSec = -1)
        {
            var elements = new List<IElement>();

            foreach (var element in FindElementsByTagName<TMobileElement>(tagName, log, timeoutInSec))
                elements.Add(element);

            return elements;
        }

        public IElement FindElementByTagName(string tagName, ILogger log, double timeoutInSec = -1)
            => FindElementByTagName<TMobileElement>(tagName, log, timeoutInSec);



        private void RestoreDefaultImpicitTimeout() { _nativeDriver.Manage().Timeouts().ImplicitWait = DefaultImplicitTimeout; }
        private void SetImplicitTimeout(double timeoutInSec)
            => _nativeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeoutInSec);
    }
}
