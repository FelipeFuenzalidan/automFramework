using System;
using System.Configuration;

namespace automframework.Ui_test.Utils
{
    public static class ParametersExecution
    {
        enum NameEnvironment
        {
            QA,
            UAT,
            PRODUCTION
        }
        #region "Class variables"
        //Set envoroment url from app.config.
        private static readonly string environment = ConfigurationManager.AppSettings["Environment"];

        //Set browser url from app.config.
        private static readonly string browser = ConfigurationManager.AppSettings["Browser"];
        #endregion

        /// <summary>
        /// Gets name browser
        /// </summary>
        /// <returns></returns>
        public static string GetNameBrowser()
        {
            try
            {
                return browser;
            }
            catch(Exception)
            {
                throw new Exception("Browser is not support.");
            }

        }

        /// <summary>
        /// Gets name environment.
        /// </summary>
        public static string GetEnviroment()
        {
            string environmetUrl = null;

            try
            {

                if (environment.ToUpper() == NameEnvironment.QA.ToString())
                {
                    environmetUrl = "https://www.google.com";
                }

                if (environment.ToUpper() == NameEnvironment.UAT.ToString())
                {
                    environmetUrl = "https://www.google.com";
                }

                if (environment.ToUpper() == NameEnvironment.PRODUCTION.ToString())
                {
                    environmetUrl = "https://www.google.com";
                }
            }
            catch (Exception)
            {
                throw new Exception("Envirenmet is not support");
            }

            return environmetUrl;
        }
    }
}
