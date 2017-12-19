using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using System.Configuration;
using NUnit.Framework;
using System;
using System.Threading;
using System.Collections.Generic;

namespace Fourth.Mobile.Framework.PageObject
{
	public class MentionUserModal : BasePage
	{
		#region Constructor
		public MentionUserModal(IWebDriver webDriver) : base(webDriver)
		{
		}
		#endregion

		#region PageObjects
		[FindsBy(How = How.ClassName, Using = "click-block-hide")]
		public IWebElement ClickBlockHidden { get; set; }

		[FindsBy(How = How.CssSelector, Using = "input[type='search']")]
		public IWebElement SearchInputField { get; set; }

		[FindsBy(How = How.CssSelector, Using = "span.autocomplete-label")]
		public IList<IWebElement> SearchResultsNamesList { get; set; }

		[FindsBy(How = How.ClassName, Using = "mention-search")]
		public IWebElement SearchResultsItems { get; set; }
		#endregion

		#region Methods
		public void WaitForInput()
		{
			Driver.WaitElementToExists(ClickBlockHidden);
			Driver.WaitIsClickable(SearchInputField);
		}

		public void CompleteSearchFlowForUser(string username)
		{
			switch (username)
			{
				case "myself":
					WaitForInput();
					SearchInputField.ClearAndSendKeys("approver"); // TODO: Go to Profile and get data from there for this particular case only (based on App.config).
					Driver.WaitElementToExists((OpenQA.Selenium.IWebElement)SearchResultsNamesList);
					Driver.WaitElementToExists(Driver.FindElement(By.XPath("//span[.='approver testington']")));
					Driver.FindElement(By.XPath("//span[.='approver testington']")).Click();
					break;

				default:
					WaitForInput();
					SearchInputField.ClearAndSendKeys("Dont Disturb me 3"); // TODO: Go to Profile and get data from there for this particular case only (based on App.config).
					Driver.WaitElementToExists((OpenQA.Selenium.IWebElement)SearchResultsNamesList);
					Driver.WaitElementToExists(Driver.FindElement(By.XPath("//span[.='Dont Disturb me 3']")));
					Driver.FindElement(By.XPath("//span[.='Dont Disturb me 3']")).Click();
					break;
			}
		}

		public void AddDetailsToSearchForUser(string username)
		{
			switch (username)
			{
				case "myself":
					WaitForInput();
					SearchInputField.ClearAndSendKeys("approver"); // TODO: Go to Profile and get data from there for this particular case only (based on App.config).
					break;

				default:
					WaitForInput();
					SearchInputField.ClearAndSendKeys("Dont Disturb me 3"); // TODO: Go to Profile and get data from there for this particular case only (based on App.config).
					break;
			}
		}

		public void VerifyEmptySearchResultsList()
		{
			Assert.IsFalse(SearchResultsItems.Exist());
		}
		#endregion
	}
}