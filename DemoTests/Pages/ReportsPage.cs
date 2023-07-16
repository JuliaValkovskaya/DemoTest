using FluentAssertions;
using OpenQA.Selenium;
using System.Linq;

namespace TestWebClient
{
    public class ReportsPage : BasePage
    {
        private string searchReportField => ".//*[contains(@id,'FilterFormfilter_text-input')]/input";
        private string runReportButton => ".//*[contains(@id,'FilterForm_applyButton')]";

        public DataGrid ReportsList
        {
            get 
            {
                return new DataGrid();
            }
        }

        public IWebElement SearchField
        {
            get
            {
                return driver.FindElement(By.XPath(searchReportField));
            }
        }

        public IWebElement RunReportButton
        {
            get
            {
                return driver.FindElement(By.XPath(runReportButton));
            }
        }

        public ReportsPage() : base()
        {
        }

        public void RunReport(string report)
        {
            SearchField.SendKeys($"{report}{Keys.Enter}");

            WaitForPageIdle();

            ReportsList.Rows.Count.Should().NotBe(0, $"Report {report} is not found");

            ReportsList.Rows.First(x => x.Text.Contains(report)).FindElement(By.XPath(".//a")).Click();

            WaitForPageIdle();

            RunReportButton.Click();

            WaitForPageIdle();
        }
    }
}
