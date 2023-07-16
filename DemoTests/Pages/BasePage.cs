using DemoTests.Driver;
using OpenQA.Selenium;

namespace TestWebClient
{
    public abstract class BasePage
    {

        protected string loading => ".//*[@id='ajaxStatusDiv']";
        
        public IWebDriver driver = DriverFactory.Instance.getDriver();

        public BasePage()
        {
            WaitForLoadingFinished();
        }

        public void WaitForPageIdle()
        {
            WaitForLoadingStarted();
            WaitForLoadingFinished();
        }

        public void WaitForLoadingStarted()
        {
            DemoTests.Utils.Wait.For(() => driver.FindElement(By.XPath(loading)).Displayed);
        }

        public void WaitForLoadingFinished()
        {
            DemoTests.Utils.Wait.For(() => !driver.FindElement(By.XPath(loading)).Displayed, breakOnException: false);
        }

        public void NavigateTo(string area)
        {
            driver.FindElement(By.XPath($".//*[contains(text(), '{area}')]")).Click();
        }

        internal void Reload()
        {
            driver.Navigate().Refresh();
        }
    }
}
