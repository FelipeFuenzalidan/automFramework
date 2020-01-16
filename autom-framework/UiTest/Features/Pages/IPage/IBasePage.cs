using System;
using OpenQA.Selenium;

namespace automframework.Ui_test.Features.Pages.IPage
{
    public interface IBasePage
    {
        string GetUrl();

        string GetTextElement(IWebElement element);

        bool ContainsTextElement(IWebElement element, string text);

        void WaitAndDoubleClickElement(IWebElement element);

        void DoubleClickElement(IWebElement element);

        string GetAttibuteValue(IWebElement element, string attribute);








        /// <summary>
        /// Sends the keys.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="keys">Keys.</param>
        void SendKeys(IWebElement element, string keys);




        /// <summary>
        /// Verify is the element displayed.
        /// </summary>
        /// <returns><c>true</c>, if element displayed was ised, <c>false</c> otherwise.</returns>
        /// <param name="element">Element.</param>
        bool IsElementDisplayed(IWebElement element);

        /// <summary>
        /// Clicks the element.
        /// </summary>
        /// <param name="element">Element.</param>
        void ClickElement(IWebElement element);

        /// <summary>
        /// Waits the and click element.
        /// </summary>
        /// <param name="element">Element.</param>
        void WaitAndClickElement(IWebElement element);

        string GetTitle();
    }
}
