using TechTalk.SpecFlow;
using Fourth.Mobile.Framework.PageObject;
using NUnit.Framework;
using System;
using Fourth.Automation.Framework.Core;

namespace Fourth.Mobile.Framework
{
	[Binding]
	public class ConnectedAppsSteps
	{
		private MainPage _mainPage;
		private AllApplicationsModal _allApplicationsModal;

		private ESSConnectedApp ESSConnectedApp;

		public ConnectedAppsSteps(MainPage mainPage, AllApplicationsModal allApplicationsModal, ESSConnectedApp essConnectedApp)
		{
			_mainPage = mainPage;
			_allApplicationsModal = allApplicationsModal;

			ESSConnectedApp = essConnectedApp;
		}

		[When("I select the (.*) Connected App")]
		public void WhenISelectConnectedApp(string connectedAppName)
		{
			_mainPage.OpenAllApplications();
			_allApplicationsModal.WaitForButtons();
			_allApplicationsModal.ClickToOpenConnectedApp(connectedAppName);
		}

		[Then("I see (.*) has loaded")]
		public void ThenISeeLoaded(string connectedAppName)
		{
			switch (connectedAppName)
			{
				case "ESS":
					ESSConnectedApp.ValidatePageOpen();
					break;
			}
		}
	}
}
