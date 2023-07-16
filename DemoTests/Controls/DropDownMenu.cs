using DemoTests.Driver;
using OpenQA.Selenium;

namespace TestWebClient
{
    public class DropDownMenu
    {
        public string button => ".//*[contains(@id,'ActionButtonHead')]";
        
        private IWebDriver driver = DriverFactory.Instance.getDriver();

        public void Expand()
        {
            driver.FindElement(By.XPath(button)).Click();
        }

        public void SelectMenuItem(string item)
        {
            Expand();
            driver.FindElement(By.XPath($".//*[contains(@class,'menu-option single')]//*[text()='{item}']")).Click();
        }
    }
}
