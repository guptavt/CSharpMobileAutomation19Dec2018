using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using System.Threading;

namespace Fourth.Mobile.Framework.PageObject
{
	public class ProfilePage : BasePage
	{
		#region Constructor
		public ProfilePage(IWebDriver webDriver) : base(webDriver)
		{
		}
		#endregion

		#region PageObjects
		[FindsBy(How = How.ClassName, Using = "click-block-hide")]
		public IWebElement ClickBlockHidden { get; set; }

		[FindsBy(How = How.Id, Using = "menu-image")]
		public IWebElement ProfileButton { get; set; }

		[FindsBy(How = How.XPath, Using = "//input[@ng-model='user.LastName']")]
		public IWebElement LastNameInput { get; set; }

		[FindsBy(How = How.ClassName, Using = "last-name")]
		public IWebElement LastNameLabel { get; set; }

		[FindsBy(How = How.ClassName, Using = "edit-button")]
		public IWebElement EditProfileButton { get; set; }

		[FindsBy(How = How.ClassName, Using = "save-button")]
		public IWebElement SaveProfileButton { get; set; }
		#endregion

		#region Methods
		public void WaitToBeReady()
		{
			Driver.WaitElementToExists(ClickBlockHidden);
			Driver.WaitIsClickable(ProfileButton);
		}

		public void ClickProfileButton()
		{
			WaitToBeReady();
			ProfileButton.Click();
		}

		public void ClickEditButton()
		{
			EditProfileButton.Click();
		}

		public void ClickSaveButton()
		{
			SaveProfileButton.Click();
		}

		public void EnterLastName(string lastName)
		{
			LastNameInput.ClearAndSendKeys(lastName);
		}

		public void RefreshProfilePage()
		{
			Driver.Navigate().Refresh();
		}
		#endregion
	}
}


