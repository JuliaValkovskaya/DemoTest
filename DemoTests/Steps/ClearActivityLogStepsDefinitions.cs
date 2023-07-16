using FluentAssertions;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TestWebClient;

namespace DemoTests.Steps
{
    [Binding]
    public sealed class ClearActivityLogStepsDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public ClearActivityLogStepsDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"user deletes (.*) records and checks that records were deleted")]
        public void WhenUserDeletesRecordsAndChecksThatRecordsWereDeleted(string ids)
        {
            ActivityLogPage activityLog = new ActivityLogPage();
            
            var records = ids.Split(',');
            List<List<string>> recordsToDelete = new List<List<string>>();
            for (int i = 0; i < records.Length; i++)
            {
                recordsToDelete.Add(activityLog.LogRecords.RowItems(i));
            }

            activityLog.LogRecords.SelectRows(ids);

            activityLog.DropDownMenu.SelectMenuItem("Delete");

            CommonStepsDefinition commonSteps = new CommonStepsDefinition(_scenarioContext);
            commonSteps.WhenUserConfirmsAction();

            activityLog.WaitForPageIdle();
            
            List<List<string>> recordsToCheck = new List<List<string>>();
            for (int i = 0; i < records.Length; i++)
            {
                recordsToCheck.Add(activityLog.LogRecords.RowItems(i));
            }

            for (int i = 0; i < records.Length; i++)
            {
                recordsToDelete[i].Should().NotBeEquivalentTo(recordsToCheck[i]);
            }

        }

    }
}
