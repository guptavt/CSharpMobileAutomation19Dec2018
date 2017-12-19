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
	public class AllApplicationsModal : BasePage
	{
		#region Constructor
		public AllApplicationsModal(IWebDriver webDriver) : base(webDriver)
		{
		}
		#endregion

		#region PageObjects
		[FindsBy(How = How.ClassName, Using = "app-label")]
		public IWebElement AllApplicationsModalButton { get; set; }
		#endregion

		#region Methods
		public void WaitForButtons()
		{
			Driver.WaitIsClickable(AllApplicationsModalButton);
		}

		public void ClickToOpenConnectedApp(string buttonLabel)
		{
			Driver.FindElement(By.XPath("//label[.=" + buttonLabel + "]")).Click();
			Driver.WaitNewWindowOpen();
		}
		#endregion
	}
}