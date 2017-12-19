using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Fourth.Mobile.Framework.PageObject
{
	public class SignOutModal : BasePage
    { 
		public SignOutModal(IWebDriver webDriver) : base(webDriver)
		{
		}

		[FindsBy(How = How.ClassName, Using = "popup-buttons")]
		public IWebElement SignOutModalButtons { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[.='Sign Out']")]
        public IWebElement SignOutButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[.='Cancel']")]
        public IWebElement CancelButton { get; set; }

        public void WaitForButtons()
		{
			Driver.WaitIsClickable(SignOutModalButtons);
		}

        public void ConfirmSignOut()
        {
            WaitForButtons();
            SignOutButton.Click();

            if (Driver.AsMobile().IsMobileApp())
            {
                Thread.Sleep(3000);
                if (Driver.IsIos())
                {
                    Driver.AsMobile().CloseApp();
                    WaitForNoWebView();
                    Driver.AsMobile().LaunchApp();
                    WaitForWebView();
                }
                else
                {
                    Driver.SwitchTo().Window(Driver.WindowHandles.Last());
                }
                Driver.AsMobile().SwitchToWebViewContext();
            }
        }

        public void CancelSignOut()
        {
            WaitForButtons();
            CancelButton.Click();
        }

        private void WaitForNoWebView()
        {
            new WebDriverWait(Driver, DriverFactory.DriverInfo.Timeout.DefaultWait).Until(drv => Driver.AsMobile().Contexts.Count(d => d != "NATIVE_APP") == 0);
        }

        private void WaitForWebView()
        {
            new WebDriverWait(Driver, DriverFactory.DriverInfo.Timeout.DefaultWait).Until(drv => Driver.AsMobile().Contexts.Count(d => d != "NATIVE_APP") > 0);
        }
    }
}