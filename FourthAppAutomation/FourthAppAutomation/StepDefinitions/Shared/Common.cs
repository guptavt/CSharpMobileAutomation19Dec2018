using TechTalk.SpecFlow;
using Fourth.Mobile.Framework.PageObject;
using NUnit.Framework;
using System;
using Fourth.Automation.Framework.Core;
using System.Threading;

namespace Fourth.Mobile.Framework
{
	[Binding]
	public class CommonSteps
	{
		private MainPage _mainPage;
		private AddPostModal _addPostModal;
		private MentionUserModal _mentionUserModal;
		private NotificationsPage _notificationsPage;
		private FeedPage _feedPage;
		private MessagesPage _messagesPage;
		private ProfilePage _profilePage;

		public CommonSteps(FeedPage feedPage, MainPage mainPage, AddPostModal addPostModal, MentionUserModal mentionUserModal, NotificationsPage notificationsPage, MessagesPage messagesPage, ProfilePage profilePage)
		{
			_mainPage = mainPage;
			_addPostModal = addPostModal;
			_mentionUserModal = mentionUserModal;
			_notificationsPage = notificationsPage;
			_feedPage = feedPage;
			_messagesPage = messagesPage;
			_profilePage = profilePage;
		}

		[StepDefinition(@"I remember the count of unread notifications")]
		public void RememberTheCountOfUnreadNotifications()
		{
			_mainPage.WaitToBeReady();
			_mainPage.WaitForClickBlock(); // FIXME: Shouldn't always be a WaitForClickBlock, as if it's run before any "actionable" step, there is no click-block element on-screen.
			_mainPage.RememberCurrentNotifications();
		}

		[StepDefinition(@"I start writing a new post")]
		public void StartWritingANewPost()
		{
			_mainPage.WaitToBeReady();
			_mainPage.WriteNewFeedButton.Click();
		}

		[StepDefinition(@"I refresh the (.*) page")]
		public void IRefresh(string page)
		{
			switch (page.ToLower())
			{
				case "profile":
					_profilePage.RefreshProfilePage();
					break;
			}
		}

		[StepDefinition(@"I add (.*) text")]
		public void AddTextToTheAddPostModal(string text)
		{
			_addPostModal.AddText(text);
		}

		[StepDefinition(@"I click the Submit button")]
		public void SubmitTheAddPostModal()
		{
			_mainPage.WaitForClickBlock();
			_addPostModal.ClickToSubmit();
		}

		[StepDefinition(@"I mention (.*)")]
		public void MentionInAddPost(string username)
		{
			_addPostModal.ClickToMention();
			_mentionUserModal.CompleteSearchFlowForUser(username);
		}

        [StepDefinition(@"the option (.*) is selected")]
        public void WhenTheOptionIsSelected(string buttonLabel)
        {
            _mainPage.ScrollToSidePanelButton(buttonLabel);
            _mainPage.ClickSidePanelButton(buttonLabel);
        }


        [StepDefinition("I click the latest (.*)")]
		public void ThenISeeLoaded(string feedNotification)
		{
			switch (feedNotification)
			{
				case "notification":
					_notificationsPage.WaitForLoad();
					_notificationsPage.VisitLatestNotification();
					break;

				case "feed":
					_feedPage.ClickNewestFeed();
					break;
				case "message":
					_messagesPage.ClickLatestMessage();
					break;
			}
		}

		[StepDefinition(@"I try to search the userlist for (.*)")]
		public void ITryToSearchUserlist(string username)
		{
			_mentionUserModal.AddDetailsToSearchForUser(username);
		}
	}
}