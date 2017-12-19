using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile.Resolvers;
using BoDi;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Extension;

namespace Fourth.Mobile.Framework
{
	public static class Support
    {
		public static void ScrollToElement(this IWebDriver self, IWebElement element)
        {
            ((IJavaScriptExecutor)self).ExecuteScript("arguments[0].scrollIntoView()", element);
        }
	}
}
