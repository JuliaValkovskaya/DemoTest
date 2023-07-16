using DemoTests.Driver;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestWebClient
{
    public class DropdownWithOption : Dropdown
    {

        public DropdownWithOption(string name) : base(name)
        { 
        }

        public override string GetValue()
        {
            var list = driver.FindElements(By.XPath(".//*[@class='menu-option static single']")).Select(x => x.Text).ToList();
            
            return String.Join(",", list);
        }
    }
}
