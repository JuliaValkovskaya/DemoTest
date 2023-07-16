Feature: RunReport

Background: 
	Given user logs in with default credentials

Scenario: Run a report
	When user navigates to Reports & Settings
	And user runs a report Project Profitability
	And user checks that report is not empty
