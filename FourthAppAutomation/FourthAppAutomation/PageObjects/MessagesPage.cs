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
	public class MessagesPage : BasePage
	{
		#region Constructor
		public MessagesPage(IWebDriver webDriver) : base(webDriver)
		{
		}
		#endregion

		#region GlobalVariables
		public string firstDirectMessageText;
		#endregion

		#region PageObjects
		[FindsBy(How = How.ClassName, Using = "click-block-hide")]
		public IWebElement ClickBlockHidden { get; set; }

		[FindsBy(How = How.CssSelector, Using = "fmp-message-element")]
		public IList<IWebElement> DirectMessagesList { get; set; }

		[FindsBy(How = How.CssSelector, Using = "textarea#post-textarea")]
		public IWebElement MessageBox { get; set; }

		public By DirectMessageText = By.ClassName("content-text");
		#endregion

		#region Methods
		public void WaitToBeReady()
		{
			Driver.WaitElementToExists(ClickBlockHidden);
		}

		public void WriteMessageBody(string messageText)
		{
			WaitToBeReady();
			MessageBox.ClearAndSendKeys(messageText);
		}

		public void ClickLatestMessage()
		{
			DirectMessagesList.First().Click();
		}

		public void GetMessageTextAndLastUpdatedTime(string messageText)
		{
			WaitToBeReady();
			firstDirectMessageText = DirectMessagesList.First(dm => dm.FindElement(DirectMessageText).Text == messageText).Text;
		}

		public void VerifyMessageTextAndLastUpdatedTime(string messageText, string lastUpdatedTime)
		{
			WaitToBeReady();
			Assert.True(firstDirectMessageText.Contains(messageText));
			Assert.True(firstDirectMessageText.Contains(lastUpdatedTime));
		}
		#endregion
	}
}
