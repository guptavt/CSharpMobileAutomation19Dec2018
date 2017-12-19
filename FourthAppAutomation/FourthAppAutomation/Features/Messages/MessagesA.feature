Feature: Engage -- Messages -- A
    As an Engage user
    I expect to have Direct Message functionality
    So that I can efficiently communicate with my work colleagues, in private

    Background:
    	Given I log in with valid credentials
    	And I click the "Messages" side panel button
	
    Scenario: The logged-in user cannot Direct Message himself
    	When I start writing a new Direct Message
        And I try to search the userlist for myself
        Then the search result should be empty

    Scenario Outline: The logged-in user can send a Direct Message
    	When I start writing a new Direct Message
		And I try to search the userlist for another user
        And I write <messageText> in the message body 
        And I submit the Message
        Then I verify Direct Message body to contain <messageText> and the Last Updated Time to be <messageAfterTime>

    Examples:
        | messageText  					  | messageAfterTime        |
        | this is a private message		  | a minute ago            |	
   
  	Scenario Outline: The logged-in user can reply to a Direct Message
  		When I start writing a new Direct Message
		And I try to search the userlist for another user
        And I write <messageText> in the message body
        And I submit the Message
		When I click the latest message
        And I add reply <replyText>
        And I click the "Post" button
        Then I verify that <replyText> appears on the message trail
        And the number of replies updates to "1"

    Examples:
        | messageText					| replyText                |
		| New Message expecting reply	| Replying to your message | 


#NOTE: Backgroud states the user is logged in, therefore, there's no reason to stay that in the scenario name...
#Background:
#    Given I log in with valid credentials
#    And the option Messages is selected
#
#Scenario: User cannot Direct Message himself
#	When an attempt to message the logged user is made
#	Then the user cannot be found in the user list
#
#Scenario Outline: Send a direct message
#	When a message is sent to user "@SomeUser"
#	Then message should be sucessfully sent
#	#Validates message text, time etc
#
#Scenario Outline: User can reply to a Direct Message
#	Given user received a message
#	When the message is replied
#	Then reply should be sucessfully sent
#	#Validates message text, time etc