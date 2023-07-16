Feature: ClearActivityLog

Background: 
	Given user logs in with default credentials

Scenario: Clear Activity Log
	When user navigates to Reports & Settings
	And user opens submenu Activity Log
	And user deletes 1, 2, 3 records and checks that records were deleted

