using TechTalk.SpecFlow;
using Fourth.Mobile.Framework.PageObject;

namespace Fourth.Mobile.Framework
{
	[Binding]
	public class NotificationsSteps
	{
		private MainPage _mainPage;

		public NotificationsSteps(MainPage mainPage)
		{
			_mainPage = mainPage;
		}

		[Then(@"I see the count of unread notifications (.*)")]
		public void ThenISeeTheCountOfUnreadNotificationsChange(string change)
		{
			switch (change)
			{
				case "increment":
					_mainPage.WaitToBeReady();
					_mainPage.WaitForClickBlock();
					_mainPage.AssertNotificationsGreaterByOne();
					break;
				case "decrement":
					_mainPage.WaitToBeReady();
					_mainPage.WaitForClickBlock();
					_mainPage.AssertNotificationsLowerByOne();
					break;
			}
		}
	}
}
