using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using System.Configuration;
using NUnit.Framework;

namespace Fourth.Mobile.Framework.PageObject
{
	public class Login : BasePage
	{
		public Login(IWebDriver webDriver) : base(webDriver)
		{
            if (Driver.IsMobile())
            {
                if (Driver.AsMobile().IsIos()) Driver.AcceptAlert(false); 
                Driver.AsMobile().SwitchToWebViewContext();
            }
        }

		[FindsBy(How = How.CssSelector, Using = "input[id*='username']")]
		public IWebElement UserNameInput { get; set; }

		[FindsBy(How = How.CssSelector, Using = "input[type='password']")]
		public IWebElement PasswordInput { get; set; }

        [FindsBy(How = How.ClassName, Using = "android.widget.Button")]
        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        public IWebElement SignInButton { get; set; }

		[FindsBy(How = How.ClassName, Using = "error-msg")]
		public IWebElement ErrorMessageText { get; set; }

		[FindsBy(How = How.ClassName, Using = "fourth-link")]
		public IWebElement FourthFooterText { get; set; }

        public string pinCode = "123456";

        public void OpenLoginPage()
		{
            if (!Driver.AsMobile().IsMobileApp())
            {
                Driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["WebSite.Url"]);
            }
		}

		public void PerformLogin(string credentials)
		{
			WaitForPageToLoad();
			switch (credentials)
			{
				case "valid":
					UserNameInput.ClearAndSendKeys(ConfigurationManager.AppSettings["User"]);
					PasswordInput.ClearAndSendKeys(ConfigurationManager.AppSettings["Password"]);
                    ClickSignInButton();
                    SetMobilePin();
					break;
				case "blank":
                    UserNameInput.Clear();
					PasswordInput.Clear();
                    ClickSignInButton();
                    break;
				case "invalid":
					UserNameInput.ClearAndSendKeys("improper@user.com");
					PasswordInput.ClearAndSendKeys("password");
                    ClickSignInButton();
                    break;
			}
		}

		public void VerifyError(string credentialType)
		{
            Driver.WaitElementToExists(ErrorMessageText);

			if (Driver.AsMobile().IsMobileApp())
            {	
            	Assert.True("Your username and/or password is not correct.".Equals(ErrorMessageText.Text.Trim()));
            }			else
            {
				switch (credentialType)
				{
					case "blank":
						Assert.True("Your username and/or password is not correct.".Equals(ErrorMessageText.Text.Trim()));
						break;
					case "invalid":
						Assert.True("Your login attempt has failed. Make sure the username and password are correct.".Equals(ErrorMessageText.Text.Trim()));
						break;
				}
            }
		}

		public void VerifyFourthFooter()
		{
			WaitForPageToLoad();
			Assert.True(FourthFooterText.Exist());
		}

		public void WaitForPageToLoad()
		{
			Driver.WaitIsClickable(PasswordInput);
		}

        private void SetMobilePin()
        {
            if (Driver.AsMobile().IsMobileApp())
            {
                var pinPage = new Pin(Driver);

                pinPage.InsertPin(pinCode);

                if (Driver.AsMobile().IsIos()) Driver.AcceptAlert(false);

                Driver.AsMobile().CloseApp();
                Driver.AsMobile().LaunchApp();

                pinPage.VerifyPin(pinCode);

                if (Driver.AsMobile().IsIos()) Driver.AcceptAlert(false);
            }
        }

        private void ClickSignInButton()
        {
            if (Driver.AsMobile().IsMobileApp() && Driver.IsAndroid())
            {
                Driver.AsMobile().SwitchToNativeContext();
                Driver.AsMobile().Tap(1, SignInButton, 1);
                Driver.AsMobile().SwitchToWebViewContext();
            }
            else
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", SignInButton);
            }
        }
	}
}