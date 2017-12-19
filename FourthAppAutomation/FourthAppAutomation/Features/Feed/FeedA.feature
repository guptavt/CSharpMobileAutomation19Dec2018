Feature: Engage -- Feed -- A
    As an Engage user
    I expect to be able to have Feed functionality
    So that I can keep up-to-date with relevant information and communicate
	
    Scenario Outline: Generating a new Feed item with own mention
    	Given I log in with valid credentials
       	When I start writing a new post
		And I add <message> text
		And I mention myself
		And I submit the Feed item
        Then I verify that the body contains <feedText> and the Last Updated Time is <feedTime>

    Examples:
        | message  						  |	feedText                         					 | feedTime                   |
        | The following user is notified: | The following user is notified:@approver testington  | Last Updated a minute ago  |

    Scenario Outline: Replying on a newly-created Feed item
        Given I log in with valid credentials
       	And I start writing a new post
		And I add <message> text
		And I submit the Feed item
        When I click the latest Feed item 
        And I reply with <replyText>
        And I click the "Post" button
        Then I verify that <replyText> appears on the message trail
        And the number of replies updates to "1"

    Examples:
        | message	                | replyText             |
		| New Feed expecting reply	| Replying to your feed |

        # TODO: I would love it for us to get rid of such Scenario Outlines that only give one example.
        # Here, <message> could be in the step definition, as it doesn't really matter, does it?
        # Also, the @mention should be somehow dynamic or at least aware of the used config.Username.
        # Also, as assert step is static, in that it should always have that text, so no need to specify it in the .feature.


#NOTE: Mention yourself is REALLY a valid scenario? Real life scenario you would mention someone else...
#Only add in examples information that is REALLY useful for understanding the scenario.
#Eg: Is the message you going to write important to check if the mention works?
#Only specify the validations you going to do if POs want to read that kind info. If they are only concerned with "all validations are made"
#Simply add a step and add the validations there
#Background: 
#	Given I log in with valid credentials
#
#Scenario: Create feed with mention 
#	When a feed is submitted mentioning "@UserSomething"
#	Then feed is sucessfully created
#	#This step should validate mention, feed text, creating date
#
#Scenario: Reply feed
#	Given a feed exists
#	When a reply is added
#	Then reply is successfully displayed
#	#This step should validate mention, reply text, creating date