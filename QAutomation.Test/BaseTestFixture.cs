namespace QAutomation.Test
{
    using NUnit.Framework;
    using QAutomation.Asserting;
    using QAutomation.Core.Interfaces;
    using QAutomation.Core.Interfaces.Controls;
    using QAutomation.Selenium;
    using QAutomation.Selenium.Controls;
    using QAutomation.Selenium.Engine;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Unity;

    public abstract class BaseTestFixture
    {
        private Logging.ILogger _setupLog = new NLogWrapper.Logger("|SET_UP|");
        private Logging.ILogger _testLog = new NLogWrapper.Logger("|TEST|");
        private Logging.ILogger _teardownLog = new NLogWrapper.Logger("|TEAR_DOWN|");

        public Logging.ILogger SetupLog => _setupLog;
        public Logging.ILogger TestLog => _testLog;
        public Logging.ILogger TeardownLog => _teardownLog;

        public BaseTestFixture() { }

        [SetUp]
        public abstract void SetUp();

        [TearDown]
        public abstract void TearDown();
    }
}
