using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Extension;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Page;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace Fourth.Mobile.Framework.PageObject
{
    public class Pin : BasePage
    {
        public Pin(IWebDriver webDriver) : base(webDriver)
        {
            Driver.AsMobile().SwitchToNativeContext();
        }

        [FindsBy(How = How.Id, Using = "Hello")]
        [FindsBy(How = How.Id, Using = "com.fourth.marketplace.qa:id/sf__passcode_title")]
        public IWebElement CreatePinMessage { get; set; }

        [FindsBy(How = How.Id, Using = "Yes")]
        [FindsBy(How = How.Id, Using = "com.fourth.marketplace.qa:id/passcode_positive")]
        public IWebElement YesButton { get; set; }

        [FindsBy(How = How.Id, Using = "No")]
        [FindsBy(How = How.Id, Using = "com.fourth.marketplace.qa:id/passcode_negative")]
        public IWebElement NoButton { get; set; }

        //[FindsBy(How = How.XPath, Using = "//XCUIElementTypeSecureTextField")]
        //[FindsBy(How = How.Id, Using = "com.fourth.marketplace.qa:id/sf__passcode_text")]
        //public IWebElement EnterPin { get; set; }

        [FindsBy(How = How.ClassName, Using = "XCUIElementTypeSecureTextField")]
        [FindsBy(How = How.Id, Using = "com.fourth.marketplace.qa:id/sf__passcode_text")]
        public IWebElement EnterConfirmPinText { get; set; }

        [FindsBy(How = How.Name, Using = "Create")]
        [FindsBy(How = How.Name, Using = "Confirm")]
        [FindsBy(How = How.Name, Using = "Verify")]
        public IWebElement ConfirmVerifyButton { get; set; }

        public void InsertPin(string pinValue)
        {
            Driver.WaitIsClickable(YesButton);

            YesButton.Click();

            Driver.WaitIsClickable(EnterConfirmPinText);
            EnterConfirmPinText.SendKeys(pinValue + "\n");

            if (ConfirmVerifyButton.Exist()) ConfirmVerifyButton.Click();

            Driver.WaitIsClickable(EnterConfirmPinText);
            EnterConfirmPinText.SendKeys(pinValue + "\n");

            if (ConfirmVerifyButton.Exist()) ConfirmVerifyButton.Click();
        }

        public void VerifyPin(string pinValue)
        {
            Driver.WaitIsClickable(EnterConfirmPinText);
            EnterConfirmPinText.SendKeys(pinValue + "\n");
            if (ConfirmVerifyButton.Exist()) ConfirmVerifyButton.Click();
        }

        public void SkipPin()
        {
            Driver.WaitIsClickable(NoButton);
            NoButton.Click();
        }
    }
}