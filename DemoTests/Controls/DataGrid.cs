using DemoTests.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestWebClient
{
    public class DataGrid
    {
        protected string parent => $".//*[contains(@id,'ListView-')]";

        protected IWebDriver driver = DriverFactory.Instance.getDriver();

        public List<string> Headers
        {
            get 
            {
                return driver.FindElements(By.XPath("(.//table)[1]/thead/tr/th")).Select(x => x.Text).ToList();
            }
        }

        public List<IWebElement> Rows
        {
            get
            {
                return driver.FindElements(By.XPath("(.//table)[1]/tbody/tr")).ToList();
            }
        }

        public List<string> RowItems(int row)
        {
                return driver.FindElements(By.XPath("(.//table)[1]/tbody/tr")).ToList()[row].FindElements(By.XPath(".//td")).Select(x => x.Text).ToList();
        }

        public void SelectRows(string rowNumbers)
        {
            var v = rowNumbers.Split(',').Select(x => int.Parse(x)).ToList();
            foreach (int x in v)
            {
                Rows[x-1].FindElement(By.XPath(".//*[@class='input-check']")).Click();
            }
        }
    }
}
