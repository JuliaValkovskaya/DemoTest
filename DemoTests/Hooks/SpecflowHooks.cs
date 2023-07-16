using DemoTests.Driver;
using System.Configuration;
using TechTalk.SpecFlow;

namespace DemoTests.Hooks
{
    [Binding]
    class SpecflowHooks
    {
        

        [BeforeScenario]
        public static void InitDriver()
        {
            DriverFactory.Instance.getDriver().Navigate().GoToUrl(ConfigurationManager.AppSettings["TestUrl"]);

        }

        [AfterScenario]
        public static void CloseDriver()
        {
            DriverFactory.StopDriver();
        }
    }
}
