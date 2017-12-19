using TechTalk.SpecFlow;
using Fourth.Mobile.Framework.PageObject;

namespace Fourth.Mobile.Framework
{
	[Binding]
	public class LoginSteps
	{
		private Login _login;
		private MainPage _mainPage;
        private SignOutModal _signOutModal;

        public LoginSteps(Login login, MainPage mainPage, SignOutModal signOutModal)
		{
			_login = login;
			_mainPage = mainPage;
            _signOutModal = signOutModal;
		}

		[Given(@"I log in with (.*) credentials")]
		public void GivenILoginWithCredentials(string credentials)
		{
			_login.OpenLoginPage();
			_login.PerformLogin(credentials);
		}

		[Then(@"I see the Hamburger Menu button")]
		public void ThenISeeTheHamburgerMenuIcon()
		{
			_mainPage.VerifyHamburgerButton();
		}

		[Then(@"I see the (.*) credentials error message")]
		public void ThenISeeError(string credentialType)
		{
			_login.VerifyError(credentialType);
		}

        [Then(@"a logout can be performed")]
        public void ThenALogoutCanBePerformed()
        {
            _mainPage.PerformSignOut();
            _signOutModal.ConfirmSignOut();
            _login.VerifyFourthFooter();
        }

        [Then(@"logout attempt can be cancelled")]
        public void ThenLogoutAttemptCanBeCancelled()
        {
            _mainPage.PerformSignOut();
            _signOutModal.CancelSignOut();
            _mainPage.VerifySidePanelButton("Sign Out");
        }
    }
}