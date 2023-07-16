Feature: CreateContact

Background: 
	Given user logs in with default credentials

Scenario: Create a contact - Happy flow
	When user navigates to Sales & Marketing
	And user creates a contact
		| First Name | Last Name | Role  | Category           |
		| Julia      | V         | Admin | Customers,Partners |
	Then user opens a current contact in edit mode
	Then user reloads the page
	And user checks a contact's fields
		| Field Name | Field Value        |
		| First Name | Julia              |
		| Last Name  | V                  |
		| Role       | Admin              |
		| Category   | Customers,Partners |
