using TechTalk.SpecFlow;
using Fourth.Mobile.Framework.PageObject;
using System;

namespace Fourth.Mobile.Framework
{
	[Binding]
	public class FeedSteps
	{
		private FeedPage _feedPage;

		public FeedSteps(FeedPage feedPage)
		{
			_feedPage = feedPage;
		}

		[Then(@"I verify Feed body to contain (.*) and Last Updated Time to be (.*)")]
		public void ThenIVerifyFeedBodyToContainAndLastUpdatedTimeToBe(string feedText, string lastUpdatedTime)
		{
			_feedPage.GetFeedTextAndLastUpdatedTime(feedText);
			_feedPage.VerifyFeedTextAndLastUpdatedTime(feedText, lastUpdatedTime);
		}

		[When(@"I add reply (.*)")]
		public void WhenIAddReply(string replyText)
		{
			_feedPage.WriteAndSubmitReply(replyText);
		}

		//[When(@"I click on ""(.*)"" button")]
		//public void WhenIClickOnButton(string Post)
		//{
		//	FeedPage.ClickReplyPostButton();
		//}

		[Then(@"I verify that (.*) appears on the message trail")]
		public void ThenIVerifyThatReplyAppearsOnTheMessageTrail(string replyText)
		{
			_feedPage.VerifyReplyPostText(replyText);
		}

		[Then(@"number of replies text updated to (.*)")]
		public void ThenNumberOfRepliesTextUpdatedTo(string replyCount)
		{
			_feedPage.VerifyReplyCount(replyCount);
		}
	}
}