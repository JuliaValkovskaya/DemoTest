using DemoTests.Driver;
using OpenQA.Selenium;
using System.Configuration;
using TechTalk.SpecFlow;
using TestWebClient;

namespace DemoTests.Steps
{
    [Binding]
    public sealed class CommonStepsDefinition
    {
        private readonly ScenarioContext _scenarioContext;

        public CommonStepsDefinition(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"user reloads the page")]
        public void ThenUserReloadsThePage()
        {
            MainPage mainPage = new MainPage();
            mainPage.Reload();
        }

        [StepDefinition(@"user logs in with default credentials")]
        public void GivenTheFirstNumberIs()
        {
            var defUserName = ConfigurationManager.AppSettings["DefaultUser"];
            var defUserPassword = ConfigurationManager.AppSettings["DefaultPassword"];

            LoginPage loginPage = new LoginPage();
            loginPage.LoginWithUser(defUserName, defUserPassword);
        }

        [StepDefinition(@"user navigates to (.*)")]
        public void GivenUserNavigatesToSalesMarketing(string screen)
        {
            MainPage mainPage = new MainPage();
            mainPage.NavigateTo(screen);
            mainPage.MoveMouseTo(screen);
        }

        [When(@"user opens submenu (.*)")]
        public void WhenUserOpensSubmenuActivityLog(string menuItem)
        {
            MainPage mainPage = new MainPage();
            mainPage.OpenSubMenu(menuItem);
        }

        [StepDefinition(@"user confirms action")]
        public void WhenUserConfirmsAction()
        {
            IAlert alert = DriverFactory.Instance.getDriver().SwitchTo().Alert();
            alert.Accept();
        }
    }
}
