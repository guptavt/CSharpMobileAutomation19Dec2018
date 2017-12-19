﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.2.0.0
//      SpecFlow Generator Version:2.2.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace FourthAppAutomation.Features.Messages
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.2.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Engage -- Messages -- A")]
    public partial class Engage_Messages_AFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "MessagesA.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Engage -- Messages -- A", "    As an Engage user\r\n    I expect to have Direct Message functionality\r\n    So " +
                    "that I can efficiently communicate with my work colleagues, in private", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
    #line 7
     testRunner.Given("I log in with valid credentials", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
     testRunner.And("I click the \"Messages\" side panel button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The logged-in user cannot Direct Message himself")]
        public virtual void TheLogged_InUserCannotDirectMessageHimself()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The logged-in user cannot Direct Message himself", ((string[])(null)));
#line 10
    this.ScenarioSetup(scenarioInfo);
#line 6
    this.FeatureBackground();
#line 11
     testRunner.When("I start writing a new Direct Message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
        testRunner.And("I try to search the userlist for myself", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
        testRunner.Then("the search result should be empty", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The logged-in user can send a Direct Message")]
        [NUnit.Framework.TestCaseAttribute("this is a private message", "a minute ago", null)]
        public virtual void TheLogged_InUserCanSendADirectMessage(string messageText, string messageAfterTime, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The logged-in user can send a Direct Message", exampleTags);
#line 15
    this.ScenarioSetup(scenarioInfo);
#line 6
    this.FeatureBackground();
#line 16
     testRunner.When("I start writing a new Direct Message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
  testRunner.And("I try to search the userlist for another user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
        testRunner.And(string.Format("I write {0} in the message body", messageText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
        testRunner.And("I submit the Message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
        testRunner.Then(string.Format("I verify Direct Message body to contain {0} and the Last Updated Time to be {1}", messageText, messageAfterTime), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("The logged-in user can reply to a Direct Message")]
        [NUnit.Framework.TestCaseAttribute("New Message expecting reply", "Replying to your message", null)]
        public virtual void TheLogged_InUserCanReplyToADirectMessage(string messageText, string replyText, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The logged-in user can reply to a Direct Message", exampleTags);
#line 26
   this.ScenarioSetup(scenarioInfo);
#line 6
    this.FeatureBackground();
#line 27
    testRunner.When("I start writing a new Direct Message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
  testRunner.And("I try to search the userlist for another user", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 29
        testRunner.And(string.Format("I write {0} in the message body", messageText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
        testRunner.And("I submit the Message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
  testRunner.When("I click the latest message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
        testRunner.And(string.Format("I add reply {0}", replyText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
        testRunner.And("I click the \"Post\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
        testRunner.Then(string.Format("I verify that {0} appears on the message trail", replyText), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 35
        testRunner.And("the number of replies updates to \"1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion