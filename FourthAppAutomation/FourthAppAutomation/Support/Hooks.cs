using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Fourth.Automation.Framework.Core;
using Fourth.Automation.Framework.Mobile.Resolvers;
using BoDi;
using Fourth.Automation.Framework.Mobile;
using Fourth.Automation.Framework.Extension;
using OpenQA.Selenium.Firefox;

namespace Fourth.Mobile.Framework
{
    [Binding]
	public sealed class Hooks
	{
		private readonly IObjectContainer objectContainer;
        //private readonly AppiumDebugServers appiumServers;
		private IWebDriver driver;

        public Hooks(IObjectContainer container)
        {
            this.objectContainer = container;
            //this.appiumServers = new AppiumDebugServers(
            //    new TerminalCommand[]
            //    {
            //        new AppiumServer(DriverFactory.DriverInfo),
            //        new IOSWebkitDebugProxy(DriverFactory.DriverInfo)
            //    });
        }

		[BeforeTestRun]
		public static void BeforeTestRun()
		{            
            DriverFactory.Resolvers.Add(new AndroidResolver());
			DriverFactory.Resolvers.Add(new IOSResolver());
		}

		[BeforeScenario]
		public void BeforeScenario()
		{
            //this.appiumServers.Start(DriverFactory.DriverInfo);
            driver = DriverFactory.Create();
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

		[AfterScenario]
		public void AfterScenario()
		{
            if (driver.AsMobile().IsMobileApp())
            {
                //ensures that a late pop is close before ending the test
                if (driver.IsIos()) driver.AcceptAlert(false);

                driver.AsMobile().UninstallApp();
            }
            else
            {
                driver.Quit();
            }
            //this.appiumServers.Stop();
        }
	}
}
