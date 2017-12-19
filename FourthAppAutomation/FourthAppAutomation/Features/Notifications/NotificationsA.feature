Feature: Engage -- Notifications -- A
	As an Engage user
	I expect to have notifications inside the Dashboard
	So that I can be kept up to date on in-app events that interest me
	
	Scenario Outline: Notification counter incrementing
		Given I log in with valid credentials
		And I remember the count of unread notifications
		When I start writing a new post
		And I add <message> text
		And I mention myself
		And I submit the Feed item
		Then I see the count of unread notifications increment

	Examples:
		| message                         |
		| The following user is notified: |

	Scenario Outline: Notification counter decrementing
		Given I log in with valid credentials
		And I start writing a new post
		And I add <message> text
		And I mention myself
		And I submit the Feed item
		When I remember the count of unread notifications
		And I click the "Notifications" side panel button
		And I click the latest notification 
		Then I see the count of unread notifications decrement

	Examples:
		| message                         |
		| The following user is notified: |

		# TODO: For the mention myself step, get the user from the Profile?



#Mention a different user, not yourself...
#Consider:
#Background:
#	Given user "@OtherUser" has no notifications
#	And I log in with valid credentials

#Scenario: Notification count increase
#	When a post mentioning "@OtherUser" is created
#	Then the mentioned user notifications should increase

#Scenario: Notification count decrease
#	When a post mentioning "@OtherUser" is created
#	And the mentioned user has visualized the post
#	Then the mentioned user notifications should decrease
