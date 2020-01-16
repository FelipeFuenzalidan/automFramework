using System;
using automframework.Ui_test.Features.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace automframework.Ui_test.Features.Steps
{
    [Binding]
    public class GoogleSearchStep
    {
        //Set object GoogleSearchPage class.
        private readonly GoogleSearchPage googleSearchPage;

        //Class constructor.
        public GoogleSearchStep()
        {
            googleSearchPage = new GoogleSearchPage();
        }

        #region "Given Step"
        [Given(@"I am Google search page")]
        public void ISeeTheGooglePageFullyLoaded()
        {
            Assert.IsTrue(googleSearchPage.IsLoadGoogle(), "The google page is not loaded.");
        }
        #endregion

        #region "When Step"
        [When(@"I type (.*) keyword")]
        public void ITypeSearchKeywordAs(string search)
        {
            googleSearchPage.TypeSearchGoogle(search);
        }
        #endregion

        #region "Then Step"
        [Then(@"I should see the (.*)")]
        public void IShouldSeeTheResult(String result)
        {
            Assert.AreEqual(result, googleSearchPage.GetResultSearchGoogle(), "The result does not correspond to the search."); 
            
        }
        #endregion
    }
}
