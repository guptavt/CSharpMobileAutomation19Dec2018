using TechTalk.SpecFlow;
using Fourth.Mobile.Framework.PageObject;
using System.ServiceModel.Channels;

namespace Fourth.Mobile.Framework
{
	[Binding]
	public class MessagesSteps
	{
		private MainPage _mainPage;
		private MentionUserModal _mentionUserModal;
		private MessagesPage _messagesPage;

		public MessagesSteps(MainPage mainPage, MentionUserModal mentionUserModal, MessagesPage messagesPage)
		{
			_mainPage = mainPage;
			_mentionUserModal = mentionUserModal;
			_messagesPage = messagesPage;
		}

		[When(@"I start writing a new Direct Message")]
		public void WhenIStartWritingDirectMessage()
		{
			_mainPage.ClickAddMessageButton();
		}

		[When(@"I write (.*) in the message body")]
		public void WhenIWriteMessageBody(string messageBody)
		{
			_messagesPage.WriteMessageBody(messageBody);
		}

		[Then(@"the search result should be empty")]
		public void ThenSearchResultShouldBeEmpty()
		{
			_mentionUserModal.VerifyEmptySearchResultsList();
		}

		[Then(@"I verify Direct Message body to contain (.*) and the Last Updated Time to be (.*)")]
		public void ThenIVerifyDirectMessageBodyLastUpdatedTime(string messageText, string lastUpdatedTime)
		{
			_messagesPage.GetMessageTextAndLastUpdatedTime(messageText);
			_messagesPage.VerifyMessageTextAndLastUpdatedTime(messageText, lastUpdatedTime);
		}
	}
}
