using DemoTests.Driver;
using OpenQA.Selenium;

namespace TestWebClient
{
    public class Shortcuts
    {
        public string createContact => ".//*[text()='Create Contact']/..";

        private IWebDriver driver = DriverFactory.Instance.getDriver();

        public void ClickCreateContact()
        {
            driver.FindElement(By.XPath(createContact)).Click();

        }
    }
}
