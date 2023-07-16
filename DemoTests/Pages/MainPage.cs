using OpenQA.Selenium;

namespace TestWebClient
{
    public class MainPage : BasePage
    {
        public MainPage() : base()
        {
        }

        public void MoveMouseTo(string screen)
        {
            string jsCode = "var event = new MouseEvent('mouseover', {'view': window,'bubbles': true,'cancelable': true});arguments[0].dispatchEvent(event);";
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript(jsCode, driver.FindElement(By.XPath($".//*[contains(text(), '{screen}')]")));
        }

        public void OpenSubMenu(string menuItem)
        {
            DemoTests.Utils.Wait.For(() => driver.FindElement(By.XPath($".//*[contains(text(), '{menuItem}')]")).Displayed == true);
            driver.FindElement(By.XPath($".//*[contains(text(), '{menuItem}')]")).Click();
            DemoTests.Utils.Wait.For(() => driver.FindElement(By.XPath($".//*[@class='sidebar-item']//*[contains(text(),'{menuItem}')]")).Displayed == true);
        }

    }
}
