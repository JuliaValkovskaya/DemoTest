using DemoTests.Driver;
using OpenQA.Selenium;

namespace TestWebClient
{
    public class LoginPage
    {
        #region Locators

        private string userName => ".//*[@id='login_user']";
        private string userPassword => ".//*[@id='login_pass']";
        private string login => ".//*[@id='login_button']";

        #endregion

        private IWebDriver driver = DriverFactory.Instance.getDriver();

        public LoginPage()
        { 
        }

        public void LoginWithUser(string user, string password)
        {
            driver.FindElement(By.XPath(userName)).SendKeys(user);
            driver.FindElement(By.XPath(userPassword)).SendKeys(password);
            driver.FindElement(By.XPath(login)).Click();
        }
    }
}
