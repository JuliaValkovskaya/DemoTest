using DemoTests.Driver;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TestWebClient;

namespace DemoTests.Steps
{
    [Binding]
    public sealed class DataGridStepsDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public DataGridStepsDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

    }
}
