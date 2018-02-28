using NUnit.Framework;
using NUnit.Framework.Internal;
using QAutomation.Selenium.Configs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAutomation.Test
{
    public class WebTestFixtureData : TestFixtureData
    {
        public WebTestFixtureData(WebDriverConfig config, params object[] args)
            : base(new object[] { config }.Concat(args).ToArray())
        {
            Properties.Add(PropertyNames.Category, config.Browser);
        }


        public static IEnumerable Browsers
        {
            get
            {
                foreach (var config in Configs)
                    yield return new WebTestFixtureData(config);
            }
        }

        public static IEnumerable<WebDriverConfig> Configs
        {
            get
            {
                return new List<WebDriverConfig>
                {
                    new FirefoxDriverConfig(),
                    new ChromeDriverConfig()
                };
            }
        }
    }
}
