using OpenQA.Selenium;

namespace TestWebClient
{
    public class ViewContactPage : BasePage
    {

        public string editButton => ".//*[@id='DetailForm_edit']";

        public ViewContactPage() : base()
        {
        }
        
        public void EditContact()
        {
            driver.FindElement(By.XPath(editButton)).Click();
        }
    }
}
