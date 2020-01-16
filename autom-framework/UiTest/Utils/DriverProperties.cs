using System;
using automframework.Ui_test.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using OpenQA.Selenium.Support.UI;

namespace automframework.Ui_test.Features.Utils
{
    public static class DriverProperties

    {
        //Set object web driver.
        private static IWebDriver driver;

        #region "Methods of the class"
        /// <summary>
        /// Loads the web driver.
        /// </summary>
        public static void LoadDriver()
        {
            try
            {
                switch (ParametersExecution.GetNameBrowser())
                {
                    case "CHROME":
                        driver = new ChromeDriver();
                        break;

                    case "FIREFOX":
                        driver = new FirefoxDriver();
                        break;

                    default:
                        throw new Exception(ParametersExecution.GetNameBrowser() + "Browser not support");
                }
            }
            catch(Exception)
            {
                throw new Exception("Browser is not loaded");
            }
        }

        /// <summary>
        /// Gets the get web driver.
        /// </summary>
        /// <value>The get driver.</value>
        public static IWebDriver GetDriver
        {
            get
            {
                try
                {
                    if (driver != null)
                    {
                        return driver;
                    }

                    LoadDriver();
                    return driver;
                }
                catch(Exception)
                {
                    throw new Exception("Driver is not loaded");
                }
            }
        }

        /// <summary>
        /// Gets the driver wait.
        /// </summary>
        /// <returns>The driver wait.</returns>
        /// <param name="timeout">Timeout.</param>
        public static WebDriverWait GetDriverWait(int timeout)
        {
            WebDriverWait waitDriver;

            try
            {
                waitDriver = new WebDriverWait(GetDriver, TimeSpan.FromSeconds(timeout));
            }
            catch(Exception)
            {
                throw new Exception("Error Cuatico!");
            }

            return waitDriver;
        }
        #endregion
    }
}
