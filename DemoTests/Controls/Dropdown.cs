using DemoTests.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestWebClient
{
    public class Dropdown
    {

        private string _name;
        protected string parent => $".//*[@id='DetailForm{_name}-input']";

        //protected string parentClick => $".//*[@id='DetailForm{_name}-input']/*";

        protected IWebDriver driver = DriverFactory.Instance.getDriver();

        public Dropdown(string name)
        {
            _name = name;
        }

        private List<IWebElement> items()
        {
            return driver.FindElements(By.XPath(".//*[@class='menu-option single']")).ToList();
        }

        public void Expand()
        {
            DemoTests.Utils.Wait.For(() => {

                driver.FindElement(By.XPath(parent)).Click();

                return items().Count() != 0;
            }
            
            );

            //driver.FindElement(By.XPath(parent)).Click();

            //DemoTests.Utils.Wait.For(() => items().Count() != 0);
        }

        public virtual string GetValue()
        {
            return driver.FindElement(By.XPath(parent)).Text;
        }

        public void Collapse()
        {
            
        }

        public void SelectItem(string item)
        {
            //var v = items().Select(x => x.Text).ToList().First(x => x == item);
            items().First(x => x.Text == item).Click();

            DemoTests.Utils.Wait.For(() => items().Count() ==0);
        }
    }
}
