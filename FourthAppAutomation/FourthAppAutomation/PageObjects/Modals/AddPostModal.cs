using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using System.Configuration;
using NUnit.Framework;
using System;

namespace Fourth.Mobile.Framework.PageObject
{
	public class AddPostModal : BasePage
	{
		#region Constructor
		public AddPostModal(IWebDriver webDriver) : base(webDriver)
		{
		}
		#endregion

		#region PageObjects
		[FindsBy(How = How.ClassName, Using = "click-block-hide")]
		public IWebElement ClickBlockHidden { get; set; }

		[FindsBy(How = How.ClassName, Using = "feed-text-area")]
		public IWebElement PostTextArea { get; set; }

		[FindsBy(How = How.ClassName, Using = "icon-user-single-add")]
		public IWebElement MentionButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "button[ng-click='cancelModalAction()']")]
		public IWebElement ModalCancelButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "button[ng-click='submitModalAction()']")]
		public IWebElement ModalSubmitButton { get; set; }
		#endregion

		#region Methods
		public void WaitToBeReady()
		{
			Driver.WaitElementToExists(ClickBlockHidden);
			Driver.WaitIsClickable(PostTextArea);
		}

		public void AddText(string text)
		{
			WaitToBeReady();
			PostTextArea.ClearAndSendKeys(text);
		}

		public void ClickToMention()
		{
			WaitToBeReady();
			MentionButton.Click();
		}

		public void ClickToSubmit()
		{
			WaitToBeReady();
			ModalSubmitButton.Click();
		}
		#endregion
	}
}