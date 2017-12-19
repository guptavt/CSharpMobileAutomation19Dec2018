Feature: Engage -- Profile -- A 
	As an Engage user
	I want to be able to access my Profile page
	So that I can see and edit my information

	Scenario: Edit and Save Profile information
    	Given I log in with valid credentials
    	And I click the user profile button
	   	When I click to Edit my Profile
		And I modify the "user " Last Name 
		And I click to Save my Profile
		And I refresh the Profile page
		Then I verify that my Profile changes are kept

	Scenario: Edit and Cancel Profile information
    	Given I log in with valid credentials
    	And I click the user profile button
		And I remember the Last Name
	   	When I click to Edit my Profile
		And I modify the "user " Last Name 
		And I cancel the Edit Profile process
		And I refresh the Profile page
		Then I verify that my Profile changes are not kept

#Consider to change to:
#Background: 
#	Given I log in with valid credentials
#
#Scenario: Edit Profile
#	Given the profile page is opened
#	When the following changes are saved
#	| LastName |
#	| Testing  |
#	Then user profile is updated
#
#Scenario: Cancel profile edition
#	Given the profile page is opened
#	When the following changes to profile are made
#	| FirstName | LastName | UserName | 
#	| Testing   | Testing  | testing  | 
#	And the page is changed without being saved
#	Then user profile is not updated