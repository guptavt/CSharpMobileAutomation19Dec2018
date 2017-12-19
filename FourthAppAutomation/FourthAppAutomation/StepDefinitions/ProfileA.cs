using System;
using TechTalk.SpecFlow;
using Fourth.Mobile.Framework.PageObject;
using System.Threading;
using NUnit.Framework;

namespace Fourth.Mobile.Framework
{
	[Binding]
	public class ProfileSteps
	{

		private MainPage _mainPage;
		private ProfilePage _profilePage;

		private string newLastName, modifiedLastName;

		public ProfileSteps(MainPage mainPage, ProfilePage profilePage)
		{
			_mainPage = mainPage;
			_profilePage = profilePage;
		}

		[Given(@"I click the user profile button")]
		public void GivenIClickTheUserProfileButton()
		{
			_profilePage.ClickProfileButton();
			// SHOULD BE DEFINED ON MAINPAGE
		}

		[Given(@"I remember the Last Name")]
		public void GivenIRememberLastName()
		{
			modifiedLastName = _profilePage.LastNameLabel.Text;
		}

		[When(@"I click to (.*) my Profile")]
		public void WhenIClickProfileHeaderButton(string button)
		{
			switch (button.ToLower())
			{
				case "edit":
					_profilePage.ClickEditButton();
					break;
				case "save":
					_profilePage.ClickSaveButton();
					break;
			}
		}

		[When(@"I modify the (.*) Last Name")]
		public void GivenIModifyTheLastName(string lastName)
		{
			newLastName = lastName + DateTime.Now.ToString("dd-MM-yyyy HH:mm");
			_profilePage.EnterLastName(newLastName);
		}

		[When(@"I cancel the Edit Profile process")]
		public void WhenICancelEditingProfile()
		{
			_mainPage.ClickBackButton();
			_mainPage.RefreshPage();
		}

		[Then(@"I verify that my Profile changes are kept")]
		public void ThenIVerifyChanges()
		{
			Assert.True(newLastName.Equals(_profilePage.LastNameLabel.Text));
		}
		// PROBABLY COULD MERGE THESE TWO
		[Then(@"I verify that my Profile changes are not kept")]
		public void ThenIVerifyNoChanges()
		{
			Assert.False(newLastName.Equals(_profilePage.LastNameLabel.Text));
		}
	}
}



