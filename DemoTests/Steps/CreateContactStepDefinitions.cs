using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TestWebClient;

namespace DemoTests.Steps
{
    [Binding]
    public sealed class CreateContactStepDefinitions
    {

        private readonly ScenarioContext _scenarioContext;

        public CreateContactStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"user creates a contact")]
        public void GivenUserCreatesAContact(Table table)
        {
            var salesMarketing = new SalesMarketingPage();

            foreach (dynamic expected in table.CreateDynamicSet())
            {
                salesMarketing.shortcuts.ClickCreateContact();
                var createContact = new EditView();
                createContact.SetFirstName(expected.FirstName);
                createContact.SetLastName(expected.LastName);
                createContact.SetRole(expected.Role);

                var categories = expected.Category.Split(',');

                foreach (string category in categories)
                {
                    createContact.SetCategory(category);
                }

                createContact.Save();
            }
        }

        [Then(@"user opens a current contact in edit mode")]
        public void ThenUserOpensACurrentContactInEditMode()
        {
            ViewContactPage viewContact = new ViewContactPage();
            viewContact.EditContact();
        }

        [Then(@"user checks a contact's fields")]
        public void ThenUserChecksAContactSFields(Table table)
        {
            var createContact = new EditView();
            foreach (dynamic expected in table.CreateDynamicSet())
            {
                var field = expected.FieldName;
                switch (field)
                {
                    case "First Name":
                        createContact.GetFirstName().Equals(expected.FieldValue);
                        break;
                    case "Last Name":
                        createContact.GetLastName().Equals(expected.FieldValue);
                        break;
                    case "Role":
                        createContact.GetRole().Equals(expected.FieldValue);
                        break;
                    case "Category":
                        createContact.GetCategory().Equals(expected.FieldValue);
                        break;
                }
            }
        }

    }
}
