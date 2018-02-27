using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using QAutomation.Core.Interfaces;
using QAutomation.Selenium.Configs;

namespace QAutomation.Test
{
    [TestFixture]
    [TestFixtureSource(typeof(WebTestFixtureData), nameof(WebTestFixtureData.Browsers))]
    public class TestWebClass : WebTestFixture
    {
        public TestWebClass(WebDriverConfig config) : base(config)
        {
        }

        public override void SetUp()
        {
            SetupLog?.INFO("Start setup method");
        }

        [Test]
        public void Method()
        {
            TestLog?.INFO("Method log");

            WebDriver.Navigate("http://www.google.com", TestLog);
        }

        public override void TearDown()
        {
            WebDriver.Quit(TeardownLog);
        }
    }
}
