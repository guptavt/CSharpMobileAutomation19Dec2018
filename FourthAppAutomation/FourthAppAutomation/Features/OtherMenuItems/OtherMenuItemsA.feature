@regression
Feature: Engage -- Other Menu Items -- A
  	As an Engage user
  	I want to be able to access various other menu items
  	So that I can see information my company deems necessary

Background: 
	Given I log in with valid credentials

Scenario: Accessing Suppliers option
		When the option Suppliers is selected
		Then Suppliers page should display

Scenario: Accessing Services Option
		When the option Services is selected
		Then Services page should display

Scenario: Accessing Notices Option
		When the option Notices is selected
		Then Notices page should display

Scenario: Accessing Help Option
		When the option Help is selected
		Then Help page should display