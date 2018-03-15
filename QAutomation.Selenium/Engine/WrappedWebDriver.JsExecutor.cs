namespace QAutomation.Selenium.Engine
{
    using OpenQA.Selenium;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Core.Locators;
    using QAutomation.Logging;
    using QAutomation.Selenium.Extensions;
    using System;
    using System.Collections.Generic;

    public partial class WrappedWebDriver : IJsExecutor
    {
        public object ExecuteJavaScript(string script, object[] args, ILogger log)
        {
            log?.TRACE($"Execute js code = '{script}'.");
            try
            {
                var result = ((IJavaScriptExecutor)WrappedDriver).ExecuteAsyncScript(script, args);
                log?.TRACE($"Executing js code = '{script}' successfully completed. Result = '{result}'.");

                return result;
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during javascript execution:\n{script}\nWith arguments: {string.Join(",", args)}", ex);
                throw;
            }
        }
        public object ExecuteJavaScript(string script, IUiElement element, ILogger log)
            => ExecuteJavaScript(script, new object[] { element.GetWrap().Wrapped }, log);
        public object ExecuteJavaScript(string script, ILogger log) => ExecuteJavaScript(script, new object[] { }, log);

        public string GetJsText(Locator locator, ILogger log) => GetJsText(Find(locator, log), log);
        public string GetJsText(IUiElement element, ILogger log)
        {
            log?.TRACE($"Get text for element {element}");
            try
            {
                var code = "return getTextFromNode(arguments[0], arguments[1]);function getTextFromNode(e,o)" +
                    "{void 0==o&&(o=!0);for(var r='',d=0;d<e.childNodes.length;d++){var i=e.childNodes[d];if(3===i.nodeType)" +
                    "{var t=i.nodeValue.trim();o&&(t=' '+t),r+=t}}return r.trim()}";

                var text = ((string)ExecuteJavaScript(code, new object[] { element.GetWrap().Wrapped, true }, log)).Trim();

                log?.TRACE($"Getting text for element {element} successfully completed. Text = '{text}'.");
                return text;
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during getting text for element {element}", ex);
                throw;
            }
        }

        public void DeleteStyles(Locator locator, List<string> styles, ILogger log)
            => DeleteStyles(Find(locator, log), styles, log);
        public void DeleteStyles(IUiElement element, List<string> styles, ILogger log)
        {
            var aggregated = string.Join(",", styles);

            try
            {
                log?.TRACE($"Delete [{aggregated}] style(s) for element {element}.");
                string styleJS = null;

                foreach (var style in styles)
                {
                    string ss = $"arguments[0].style.{style}='';";
                    styleJS += ss + "\n";
                }
                ExecuteJavaScript(styleJS, new object[] { element.GetWrap().Wrapped }, log);
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during deleting [{aggregated}] style(s) for element {element}.", ex);
                throw;
            }
        }

        public void SetStyles(Locator locator, List<string> styles, ILogger log)
            => SetStyles(Find(locator, log), styles, log);
        public void SetStyles(IUiElement element, List<string> styles, ILogger log)
        {
            var aggregated = string.Join(",", styles);

            try
            {
                string styleJS = null;

                foreach (var style in styles)
                {
                    var ind = style.IndexOf(':');
                    var name = style.Substring(0, ind);
                    var value = style.Substring(ind + 1);
                    string ss = $"arguments[0].style.{name}='{value}';";
                    styleJS += ss + "\n";
                }
                ExecuteJavaScript(styleJS, new object[] { element.GetWrap().Wrapped }, log);
            }
            catch (Exception ex)
            {
                log?.ERROR($"Error occurred during setting [{aggregated}] style(s) for element {element}.", ex);
                throw;
            }
        }

        public void JsClick(Locator locator, ILogger log) => JsClick(Find(locator, log), log);
        public void JsClick(IUiElement element, ILogger log)
        {
            log?.TRACE($"Js click on {element} started.");
            try
            {
                string script = "var evObj = document.createEvent('MouseEvents');evObj.initMouseEvent('click',true, " +
                    "true, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);arguments[0].dispatchEvent(evObj);";

                ExecuteJavaScript(script, new object[] { element.GetWrap().Wrapped }, log);
                log?.TRACE($"Js clicking on {element} has been successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"JS clicking on {element} has been completed with exception.", ex);
                throw;
            }
        }

        public void JsDoubleClick(Locator locator, ILogger log) => JsDoubleClick(Find(locator, log), log);
        public void JsDoubleClick(IUiElement element, ILogger log)
        {
            log?.TRACE($"Js double click on {element} started.");
            try
            {
                string script = "var evObj = document.createEvent('MouseEvents');evObj.initMouseEvent(\"dblclick\",true, " +
                    "false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);arguments[0].dispatchEvent(evObj);";

                ExecuteJavaScript(script, element, log);
                log?.TRACE($"JS double clicking on {element} has been successfully completed");
            }
            catch (Exception ex)
            {
                log?.ERROR($"JS double clicking on {element} has been completed with exception.", ex);
                throw;
            }
        }

        public void JsHide(Locator locator, ILogger log) => JsHide(Find(locator, log), log);
        public void JsHide(IUiElement element, ILogger log)
        {
            log?.TRACE($"JS hide {element} started.");
            try
            {
                ExecuteJavaScript("arguments[0].style.display = none;", element, log);
                log?.TRACE($"JS hiding {element} has been successfully completed.");
            }
            catch (Exception ex)
            {
                log?.ERROR($"JS hiding {element} has been completed with exception.", ex);
                throw;
            }
        }
    }
}
