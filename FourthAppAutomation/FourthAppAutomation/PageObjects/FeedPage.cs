using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Infrastructure;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using System.Configuration;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections;
using System.Security.AccessControl;

namespace Fourth.Mobile.Framework.PageObject
{
	public class FeedPage : BasePage
	{
		#region Constructor
		public FeedPage(IWebDriver webDriver) : base(webDriver)
		{
		}
		#endregion

		#region GlobalVariables
		public string firstFeedNewsItemText;
		#endregion

		#region PageObjects
		[FindsBy(How = How.ClassName, Using = "click-block-hide")]
		public IWebElement ClickBlockHidden { get; set; }

		[FindsBy(How = How.CssSelector, Using = "fmp-feed-element")]
		public IList<IWebElement> FeedNewsItemsList { get; set; }

		[FindsBy(How = How.CssSelector, Using = "fmp-order-element")]
		public IList<IWebElement> FeedOrderItemsList { get; set; }

		[FindsBy(How = How.ClassName, Using = "feed-text-area")]
		public IWebElement PostTextArea { get; set; }

		[FindsBy(How = How.ClassName, Using = "primary-button")]
		public IWebElement ReplyPostButton { get; set; }

		[FindsBy(How = How.ClassName, Using = "comment-item")]
		public IWebElement CommentItem { get; set; }

		[FindsBy(How = How.CssSelector, Using = ".icon-talk-conversation + span")]
		public IWebElement CommentCount { get; set; }

		public By ArticleFeedText = By.ClassName("content-text");
		#endregion

		#region Methods
		public void WaitForInput()
		{
			Driver.WaitElementToExists(ClickBlockHidden);
			Driver.WaitIsClickable(PostTextArea);
		}

		public void GetFeedTextAndLastUpdatedTime(string feedText)
		{
			firstFeedNewsItemText = FeedNewsItemsList.First(article => article.FindElement(ArticleFeedText).Text == feedText).Text;
		}

		public void VerifyFeedTextAndLastUpdatedTime(string feedText, string lastUpdatedTime)
		{
			Assert.True(firstFeedNewsItemText.Contains(feedText));
			Assert.True(firstFeedNewsItemText.Contains(lastUpdatedTime));
		}

		public void ClickNewestFeed()
		{
			FeedNewsItemsList.First().Click();
		}

		public void WriteAndSubmitReply(string replyText)
		{
			WaitForInput();
			PostTextArea.SendKeys(replyText);
			ReplyPostButton.Click();
		}

		public void VerifyReplyPostText(string replyPost)
		{
			WaitForInput();
			Assert.True(CommentItem.Text.Contains(replyPost));
		}

		public void VerifyReplyCount(string replyCount)
		{
			Assert.True(CommentCount.Text.Equals(replyCount));
		}
		#endregion
	}
}