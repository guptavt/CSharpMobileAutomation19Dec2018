using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;

namespace Fourth.Mobile.Framework.PageObject
{
    public class NotificationsPage : BasePage
	{
		#region Constructor
		public NotificationsPage(IWebDriver webDriver) : base(webDriver)
		{
		}
		#endregion

		#region PageObjects
		[FindsBy(How = How.XPath, Using = "//p[.='a few seconds ago']")]
		public IWebElement LatestNotificationTimeLabel { get; set; }
		#endregion

		#region Methods
		public void WaitForLoad()
		{
			Driver.WaitIsClickable(LatestNotificationTimeLabel);
		}

		public void VisitLatestNotification()
		{
			LatestNotificationTimeLabel.Click();
		}
		#endregion
	}
}