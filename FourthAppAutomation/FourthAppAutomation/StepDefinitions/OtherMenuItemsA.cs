using TechTalk.SpecFlow;
using Fourth.Mobile.Framework.PageObject;
using NUnit.Framework;

namespace Fourth.Mobile.Framework
{
	[Binding]
	public class OtherMenuItemsSteps
	{
		private OtherMenuItemsPages _otherMenuItemsPages;

		public OtherMenuItemsSteps(OtherMenuItemsPages otherMenuItemsPages)
		{
			_otherMenuItemsPages = otherMenuItemsPages;
		}

        [Then(@"Suppliers page should display")]
        public void ThenSuppliersPageShouldDisplay()
        {
            _otherMenuItemsPages.ValidateUrl("#/app/suppliers");
            _otherMenuItemsPages.ValidatePageContainer();
        }

        [Then(@"Services page should display")]
        public void ThenServicesPageShouldDisplay()
        {
            _otherMenuItemsPages.ValidateUrl("#/app/services");
            _otherMenuItemsPages.ValidatePageContainer();
        }


        [Then(@"Notices page should display")]
        public void ThenNoticesPageShouldDisplay()
        {
            _otherMenuItemsPages.ValidateUrl("#/app/notices");
            _otherMenuItemsPages.ValidatePageContainer();
        }


        [Then(@"Help page should display")]
        public void ThenHelpPageShouldDisplay()
        {
            _otherMenuItemsPages.ValidateUrl("#/app/help");
            _otherMenuItemsPages.ValidatePageContainer();
        }
    }
}
