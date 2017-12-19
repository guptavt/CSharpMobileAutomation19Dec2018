using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Fourth.Mobile.Framework.PageObject
{
	public class OtherMenuItemsPages : BasePage
	{
		public OtherMenuItemsPages(IWebDriver webDriver) : base(webDriver)
		{
		}

        [FindsBy(How = How.ClassName, Using = "conent-list-header")]
		public IWebElement ContentListHeaderText { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".feeds > .list > .listing-item")]
        public IList<IWebElement> ItemsContainer { get; set; }

        public IList<OtherMenusItems> Items => this.ItemsContainer.Select(p => new OtherMenusItems(p)).ToList();

        public void ValidateUrl(string endsWith)
        {
            StringAssert.EndsWith(endsWith, Driver.Url); 
        }

        public void ValidatePageContainer()
        {
            Driver.WaitListItemsLoad(ItemsContainer);
            Assert.IsNotEmpty(ContentListHeaderText.Text);
            Assert.AreEqual(ContentListHeaderText.Text.Substring(0, ContentListHeaderText.Text.IndexOf(" ")), Items.Count.ToString());

            foreach (var item in Items)
            {
                Driver.ScrollToElement(item.TextContent);
                Assert.IsTrue(item.Image.Exist());
                Assert.IsTrue(item.TextContent.Exist());
                Assert.IsNotEmpty(item.TextContent.Text);
            }
        }
	}
}
