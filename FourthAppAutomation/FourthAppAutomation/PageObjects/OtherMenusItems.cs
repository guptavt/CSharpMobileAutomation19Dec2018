using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Fourth.Automation.Framework.Page;
using Fourth.Automation.Framework.Extension;
using System.Threading;
using NUnit.Framework;
using Fourth.Automation.Framework.Mobile;
using System.Collections.Generic;

namespace Fourth.Mobile.Framework.PageObject
{
	public class OtherMenusItems
	{
        #region Constructor
        public OtherMenusItems(IWebElement parent)
        {
            PageFactory.InitElements(parent, this);
        }
        #endregion

        #region PageObjects
        [FindsBy(How = How.CssSelector, Using = "a[class='item-content'] > img")]
		public IWebElement Image { get; set; }

        [FindsBy(How = How.CssSelector, Using = "a[class='item-content'] div[class*='listing-item-left-text']")]
        public IWebElement TextContent { get; set; }
        #endregion
	}
}
