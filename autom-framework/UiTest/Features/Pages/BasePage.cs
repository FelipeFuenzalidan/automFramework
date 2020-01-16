using System;
using automframework.Ui_test.Features.Pages.IPage;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace automframework.Ui_test.Features.Utils
{
    public class BasePage : IBasePage
    {
        //TiemOut for wait web elements
        internal enum TimeOut
        {
            min = 10,
            medium = 30,
            max = 60
        }

        #region "Methods of the class"
        /// <summary>
        /// Gets the URL.
        /// </summary>
        /// <returns>The URL.</returns>
        public string GetUrl()
        {
            try
            {
                return DriverProperties.GetDriver.Url;
            }
            catch(Exception)
            {
                throw new Exception("Failed to get url.");
            }
        }

        /// <summary>
        /// Gets the web element.
        /// </summary>
        /// <returns>The web element.</returns>
        /// <param name="element">Element.</param>
        public IWebElement GetWebElement(IWebElement element)
        {
            try
            {
                return element;
            }
            catch (Exception)
            {
                throw new Exception("Failed to return the element.");
            }
        }

        /// <summary>
        /// Gets the text element.
        /// </summary>
        /// <returns>The text element.</returns>
        /// <param name="element">Element.</param>
        public string GetTextElement(IWebElement element)
        {
            try
            {
                return element.GetAttribute("value");
            }
            catch (Exception)
            {
                throw new Exception("The value element in not return.");
            }
        }

        /// <summary>
        /// Sends the keys.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="keys">Keys.</param>
        public void SendKeys(IWebElement element, string keys)
        {
            try
            {
                element.SendKeys(keys);
            }
            catch
            {
                throw new Exception("Error the sendKeys at element");
            }
        }

        /// <summary>
        /// Clears the and send keys.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="keys">Keys.</param>
        public void ClearAndSendKeys(IWebElement element, string keys)
        {
            try
            {
                element.Clear();
                element.SendKeys(keys);
            }
            catch (Exception)
            {
                throw new Exception("Error the clear and sendKeys at element.");
            }
        }

        /// <summary>
        /// Containses the text element.
        /// </summary>
        /// <returns><c>true</c>, if text element was containsed, <c>false</c> otherwise.</returns>
        /// <param name="element">Element.</param>
        /// <param name="text">Text.</param>
        public bool ContainsTextElement(IWebElement element, string text)
        {
            try
            {
                return text.Contains(GetTextElement(element));
            }
            catch (Exception)
            {
                throw new Exception("The text in not contains in the element.");
            }
        }

        /// <summary>
        /// Waits the and click element.
        /// </summary>
        /// <param name="element">Element.</param>
        public void WaitAndClickElement(IWebElement element)
        {
            try
            {
                DriverProperties.GetDriverWait((int)TimeOut.min).Until(ExpectedConditions.ElementToBeClickable(element));

                element.Click();
            }
            catch (Exception)
            {
                throw new Exception("The element can not be clicked. TimeOut is at limit.");
            }
        }

        /// <summary>
        /// Clicks the element.
        /// </summary>
        /// <param name="element">Element.</param>
        public void ClickElement(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception)
            {
                throw new Exception("The element can not be clicked.");
            }
        }

        /// <summary>
        /// Waits the and double click element.
        /// </summary>
        /// <param name="element">Element.</param>
        public void WaitAndDoubleClickElement(IWebElement element)
        {
            try
            {
                DriverProperties.GetDriverWait((int)TimeOut.medium).Until(ExpectedConditions.ElementToBeClickable(element));

                element.Click();

                element.Click();
            }
            catch (Exception)
            {
                throw new Exception("The element can not be clicked. TimeOut is at limit.");
            }
        }

        /// <summary>
        /// Doubles the click element.
        /// </summary>
        /// <param name="element">Element.</param>
        public void DoubleClickElement(IWebElement element)
        {
            try
            {
                element.Click();

                element.Click();
            }
            catch (Exception)
            {
                throw new Exception("The element can not be clicked.");
            }
        }

        /// <summary>
        /// Ises the element displayed.
        /// </summary>
        /// <returns><c>true</c>, if element displayed was ised, <c>false</c> otherwise.</returns>
        /// <param name="element">Element.</param>
        public bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                return element.Displayed;
            }
            catch(Exception)
            {
                throw new Exception("The element in not displayed");
            }
        }

        /// <summary>
        /// Gets the title URL.
        /// </summary>
        /// <returns>The title URL.</returns>
        public string GetTitle()
        {
            try
            {
                return DriverProperties.GetDriver.Title;
            }
            catch(Exception)
            {
                throw new Exception("Error the get url title");
            }
        }

        /// <summary>
        /// Gets the attibute value.
        /// </summary>
        /// <returns>The attibute value.</returns>
        /// <param name="element">Element.</param>
        /// <param name="attribute">Attribute.</param>
        public string GetAttibuteValue(IWebElement element, string attribute)
        {
            try
            {
                return element.GetAttribute(attribute);
            }
            catch (Exception)
            {
                throw new Exception("Failed the get attribute element");
            }
        }
        #endregion
    }
}
