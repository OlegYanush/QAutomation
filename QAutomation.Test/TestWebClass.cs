using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QAutomation.Core.Interfaces;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Core.Locators;
using QAutomation.Selenium.Configs;
using QAutomation.Selenium.Engine;

namespace QAutomation.Test
{
    [TestFixture]
    [TestFixtureSource(typeof(WebTestFixtureData), nameof(WebTestFixtureData.Browsers))]
    public class TestWebClass : WebTestFixture
    {
        public TestWebClass(WebDriverConfig config) : base(config) { }


        public override void SetUp()
        {
            var xpath = ".//a[@class='b-main-navigation__link' and contains(.,'Автобарахолка')]";

            WebDriver.Navigate("https://www.onliner.by", SetupLog);
            var link = WebDriver.FindElementByXPath<IButton>(xpath, SetupLog, "Ссылка на автобарахолку");

            (WebDriver as WrappedWebDriver)?.WaitForElementCondition<IUiElement>(Locator.XPath(xpath), e => e.Displayed, TestLog);

            link.Click(SetupLog);
        }

        [Test]
        public void TestMethod()
        {
        }

        public override void TearDown()
        {
            WebDriver.Quit(TeardownLog);
        }
    }
}
