using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using System.Configuration;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using System.Linq;
using OpenQA.Selenium.Interactions;

namespace Fourth.Mobile.Framework.PageObject
{
	public class ESSConnectedApp : BasePage
	{
		#region Constructor
		public ESSConnectedApp(IWebDriver webDriver) : base(webDriver)
		{
		}
		#endregion

		#region PageObjects
		[FindsBy(How = How.Id, Using = "ember702")]
		public IWebElement MyRotasLink { get; set; }
		#endregion

		#region Methods
		public void WaitForMyRotasLink()
		{
			Driver.WaitElementToExists(MyRotasLink);
		}

		public void ValidatePageOpen()
		{
			SetDesktopWindow();
			WaitForMyRotasLink();
			Assert.True(MyRotasLink.Exist());
		}

		public void SetDesktopWindow()
		{
			Task.Delay(1000);
			Driver.SwitchTo().Window(Driver.WindowHandles[Driver.WindowHandles.Count - 1]);
		}
		#endregion
	}
}