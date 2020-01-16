using automframework.Ui_test.Features.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace automframework.Ui_test.Features.Pages
{
    public class GoogleSearchPage : BasePage
    {
        //Class constructor, initialize the web element.
        public GoogleSearchPage()
        {
            PageFactory.InitElements(DriverProperties.GetDriver, this);
        }

        #region "Web Elements"
        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement searchGoogleTextbox;

        [FindsBy(How = How.Name, Using = "btnK")]
        public IWebElement searchButton;
        #endregion

        /// <summary>
        /// Verify is the load google.
        /// </summary>
        /// <returns><c>true</c>, if load google was ised, <c>false</c> otherwise.</returns>
        public bool IsLoadGoogle()
        {
            return IsElementDisplayed(searchGoogleTextbox);
           
        }

        /// <summary>
        /// Types the search google.
        /// </summary>
        /// <param name="search">Search.</param>
        public void TypeSearchGoogle(string search)
        {
            ClearAndSendKeys(searchGoogleTextbox, search);
            SendKeys(searchGoogleTextbox, Keys.Enter);
        }

        /// <summary>
        /// Gets the result search google.
        /// </summary>
        /// <returns>The result search google.</returns>
        public string GetResultSearchGoogle()
        {
            return GetAttibuteValue(searchGoogleTextbox, "value");
        }

        /// <summary>
        /// Gets the title google page.
        /// </summary>
        public void GetTitleGooglePage()
        {
            GetTitleGooglePage();
        }
    }
}
