using OpenQA.Selenium;
using System;

namespace TestWebClient
{
    public class EditView : BasePage
    {
        #region Locators

        private string fnField => ".//*[@id='DetailFormfirst_name-input']";
        private string lnField => ".//*[@id='DetailFormlast_name-input']";
        private string saveButton => ".//*[@id='DetailForm_save']";

        #endregion

        public EditView() : base()
        {
            DemoTests.Utils.Wait.For(() => driver.FindElement(By.XPath(saveButton)).Displayed, breakOnException: false);
        }

        private Dropdown BusinessRole
        {
            get { return new Dropdown("business_role"); }
        }

        private DropdownWithOption Categories
        {
            get { return new DropdownWithOption("categories"); }
        }

        public void SetFirstName(string firstName)
        {
            driver.FindElement(By.XPath(fnField)).SendKeys(firstName + Guid.NewGuid().ToString("n").Substring(0, 8));
        }

        public string GetFirstName()
        {
            return driver.FindElement(By.XPath(fnField)).GetAttribute("value");
        }

        public string GetLastName()
        {
            return driver.FindElement(By.XPath(lnField)).GetAttribute("value");
        }

        public void SetLastName(string lastName)
        {
            driver.FindElement(By.XPath(lnField)).SendKeys(lastName);
        }

        public void SetRole(string role)
        {
            BusinessRole.Expand();
            BusinessRole.SelectItem(role);
        }

        public string GetRole()
        {
            return BusinessRole.GetValue();
        }

        public void SetCategory(string category)
        {
            Categories.Expand();
            Categories.SelectItem(category);
        }

        public string GetCategory()
        {
            return Categories.GetValue();
        }

        public void Save()
        {
            driver.FindElement(By.XPath(saveButton)).Click();
            DemoTests.Utils.Wait.For(() => driver.FindElement(By.XPath(".//*[@id='DetailForm_edit']")).Displayed);
        }
    }
}
