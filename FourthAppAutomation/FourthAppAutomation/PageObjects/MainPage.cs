using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Fourth.Mobile.Framework.PageObject
{
	public class MainPage : BasePage
	{
		public MainPage(IWebDriver webDriver) : base(webDriver)
		{
		}

		public int unreadNotificationsCounter;

		[FindsBy(How = How.ClassName, Using = "click-block-hide")]
		public IWebElement ClickBlockHidden { get; set; }

		[FindsBy(How = How.ClassName, Using = "icon-interface-sidebar-hamburger")]
		public IWebElement HamburgerButton { get; set; }

		[FindsBy(How = How.CssSelector, Using = "ion-side-menu[side='left']")]
		public IWebElement SidePanel { get; set; }

        [FindsBy(How = How.ClassName, Using = "nav-bar-title")]
        public IList<IWebElement> HeadersList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#applications ion-item[target]")]
        public IList<IWebElement> TopThreeApplicationsList { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#apps-popup .app")]
        public IList<IWebElement> AllApplications { get; set; }

        [FindsBy(How = How.Id, Using = "applications-all-apps")]
        public IWebElement AllApplicationsButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "span.badge.right")]
		public IWebElement UnreadNotifications { get; set; }

		[FindsBy(How = How.ClassName, Using = "icon-editorial-pencil-write")]
		public IWebElement WriteNewFeedButton { get; set; }

		[FindsBy(How = How.ClassName, Using = "icon-uniE90C")]
		public IWebElement AddNewMessageButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "ion-item[class*='user-menu-image'] span")]
        public IWebElement UserName { get; set; }



        private void SetMobileContext()
        {
			if (Driver.IsMobile())
			{
                Driver.AsMobile().SwitchToWebViewContext();
            }
		}

		public void WaitToBeReady()
		{
            SetMobileContext();
            Driver.WaitIsClickable(HamburgerButton);
        }

        public void WaitForClickBlock()
		{
			Driver.WaitElementToExists(ClickBlockHidden);
		}

		public void OpenAllApplications()
		{
			SetMobileContext();
            Driver.WaitIsClickable(AllApplicationsButton);
            Driver.WaitListItemsLoad(TopThreeApplicationsList);
            AllApplicationsButton.Click();
		}

        public void SelectApplication(string option)
        {
            WaitToBeReady();
            AllApplicationsButton.Click();
            AllApplications.ElementByText(option).Click();
        }

        public void ScrollToSidePanelButton(string buttonLabel)
		{
			WaitToBeReady();
            if (HamburgerButton.Location.X <= 0)
			{
				HamburgerButton.Click();
				((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(false)", FindXPathLabelledItem(buttonLabel));
			}
			else
			{
				((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(false)", FindXPathLabelledItem(buttonLabel));
			}
		}

		public void ClickSidePanelButton(string buttonLabel)
		{
			WaitToBeReady();
			FindXPathLabelledItem(buttonLabel).Click();
		}

		public void VerifySidePanelButton(string sidePanelButtonLabel)
		{
			WaitToBeReady();
			Assert.True(FindXPathLabelledItem(sidePanelButtonLabel).Exist());
		}

		public IWebElement FindXPathLabelledItem(string itemLabel)
		{
			WaitToBeReady();
			return Driver.FindElement(By.XPath("//span[.='" + itemLabel + "']"));
		}

		public void RememberCurrentNotifications()
		{
			try
			{
				Driver.WaitElementToExists(UnreadNotifications);
				unreadNotificationsCounter = int.Parse(UnreadNotifications.Text.Trim());
			}
			catch (Exception ex)
			{
				unreadNotificationsCounter = 0;
				throw ex;
			}
		}

		public void AssertNotificationsGreaterByOne()
		{
			int currentNotifications = int.Parse(UnreadNotifications.Text.Trim());
			Assert.True(currentNotifications == ++unreadNotificationsCounter, "The current notification count was not incremented.");
		}

		public void AssertNotificationsLowerByOne()
		{
			int currentNotifications = int.Parse(UnreadNotifications.Text.Trim());
			Assert.True(currentNotifications == --unreadNotificationsCounter, "The current notification count was not decremented.");
		}

		public void VerifyHamburgerButton()
		{
			WaitToBeReady();
            Assert.True(HamburgerButton.Exist());
		}

		public void ClickAddMessageButton()
		{
			Driver.WaitElementToExists(ClickBlockHidden);
			AddNewMessageButton.Click();
		}

		public void ClickBackButton()
		{
			HamburgerButton.Click();
		}

		public void RefreshPage()
		{
			Driver.Navigate().Refresh();
		}

        public void PerformSignOut()
        {
            ScrollToSidePanelButton("Sign Out");
            ClickSidePanelButton("Sign Out");
        }
	}
}