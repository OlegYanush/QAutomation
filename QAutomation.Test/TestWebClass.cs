using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QAutomation.Core.Enums;
using QAutomation.Core.Interfaces;
using QAutomation.Core.Interfaces.Controls;
using QAutomation.Core.Locators;
using QAutomation.Selenium.Configs;
using QAutomation.Selenium.Engine;
using ReportPortal.Client.Models;

namespace QAutomation.Test
{
    [TestFixture]
    [TestFixtureSource(typeof(WebTestFixtureData), nameof(WebTestFixtureData.Browsers))]
    public class TestWebClass : WebTestFixture
    {
        public TestWebClass(WebDriverConfig config) : base(config) { }


        [SetUp]
        public override void SetUp()
        {
            WebDriver.Navigate("https://www.onliner.by", SetupLog);
        }

        [Test]
        public void TestMethod()
        {
            var xpath = ".//a[@class='b-main-navigation__link' and contains(.,'Автобарахолка')]";

            var casted = WebDriver as WrappedWebDriver;

            var button = casted.WaitForElementCondition<IButton>(Locator.XPath(xpath), btn => btn.State.HasFlag(UiElementState.Enabled), TestLog);

            button.Click(TestLog);
            casted.Refresh(TestLog);
        }

        [TearDown]
        public override void TearDown()
        {
            WebDriver.Quit(TeardownLog);
        }
    }
}
