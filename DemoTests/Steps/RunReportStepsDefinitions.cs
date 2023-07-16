using FluentAssertions;
using TechTalk.SpecFlow;
using TestWebClient;

namespace DemoTests.Steps
{
    [Binding]
    public sealed class RunReportStepsDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public RunReportStepsDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"user runs a report (.*)")]
        public void GivenUserRunsAReport(string report)
        {
            ReportsPage reportsPage = new ReportsPage();
            reportsPage.RunReport(report);
        }

        [When(@"user checks that report is not empty")]
        public void WhenUserChecksThatReportIsNotEmpty()
        {
            ReportPage reportPage = new ReportPage();
            reportPage.ReportRows.Rows.Count.Should().NotBe(0);
        }

    }
}
