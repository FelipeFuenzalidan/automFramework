using TechTalk.SpecFlow;
using automframework.Ui_test.Utils;
using automframework.Ui_test.Features.Utils;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System.Reflection;
using System.IO;
using System;
using OpenQA.Selenium;

namespace automframework.Ui_test.Features.Steps
{
    [Binding]
    public class BaseStep
    {
        #region "Class variables"
        private static ExtentReports extent;

        private static ExtentTest feature;

        private static ExtentTest scenario;
        #endregion

        #region "Methods of the class"
        /// <summary>
        /// Initializes the browser.
        /// </summary>
        private static void InitializeBrowser()
        {
            try
            {
                if (DriverProperties.GetDriver != null)
                {
                    DriverProperties.GetDriver.Manage().Window.Maximize();

                    DriverProperties.GetDriver.Navigate().GoToUrl(ParametersExecution.GetEnviroment());
                }
            }
            catch (Exception)
            {
                throw new Exception("The browser could not be initialized");
            }
        }

        /// <summary>
        /// Exits the broser.
        /// </summary>
        private static void ExitBroser()
        {
            try
            {
                if (DriverProperties.GetDriver != null)
                {
                    DriverProperties.GetDriver.Quit();
                }
            }
            catch (Exception)
            {
                throw new Exception("The browser could not be closed");
            }
        }

        /// <summary>
        /// Gets the save path report.
        /// </summary>
        /// <returns>The save path report.</returns>
        private static string GetSavePathReport()
        {
            try
            {
                string workingDirectory = Environment.CurrentDirectory;

                string pathReport = Directory.GetParent(workingDirectory).Parent.FullName + "/Report/ExecutionReport.html";

                return pathReport;
            }
            catch(Exception)
            {
                throw new Exception("The path where the report was saved could not be obtained");
            }
        }

        /// <summary>
        /// Gets the type of the step.
        /// </summary>
        /// <returns>The step type.</returns>
        private static string GetStepType()
        {
            try
            {
                string stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

                return stepType;
            }
            catch(Exception)
            {
                throw new Exception("Error the step type");
            }
        }

        /// <summary>
        /// Gets the test result.
        /// </summary>
        /// <returns>The test result.</returns>
        private static string GetTestResult()
        {
            try
            {
                PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);

                MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);

                object TestResult = getter.Invoke(ScenarioContext.Current, null);

                return TestResult.ToString();
            }
            catch(Exception)
            {
                throw new Exception("Error the get test result");
            }
        }

        /// <summary>
        /// Gets the screen shot.
        /// </summary>
        /// <returns>The screen shot.</returns>
        private static string GetScreenShot()
        {
            Screenshot ss = ((ITakesScreenshot)DriverProperties.GetDriver).GetScreenshot();

            string screenshot = ss.AsBase64EncodedString;

            return screenshot;

        }

        /// <summary>
        /// Sets up.
        /// </summary>
        [BeforeTestRun]
        public static void SetUp()
        {
            try
            {
                //Set path report
                var htmlReporter = new ExtentHtmlReporter(GetSavePathReport());

                htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;

                extent = new ExtentReports();

                extent.AttachReporter(htmlReporter);

                InitializeBrowser();
            }
            catch(Exception)
            {
                throw new Exception("Error initializing the report");
            }

        }

        /// <summary>
        /// Gets the name feature.
        /// </summary>
        [BeforeFeature]
        public static void GetNameFeature()
        {
            try
            {
                feature = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            }
            catch(Exception)
            {
                throw new Exception("The feature name has not been captured for the report");
            }
        }

        /// <summary>
        /// Gets the name scenario.
        /// </summary>
        [BeforeScenario]
        public void GetNameScenario()
        {
            try
            {
                scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            }
            catch(Exception)
            {
                throw new Exception("The scenario name has not been captured for the report");
            }
        }

        /// <summary>
        /// Gets the result spep.
        /// </summary>
        [AfterStep]
        public static void GetResultSpep()
        {
            try
            {
                //Passed Status
                if (GetTestResult() == ScenarioExecutionStatus.OK.ToString())
                {
                    switch (GetStepType())
                    {
                        case "Given":
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).
                                Log(Status.Info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                        case "When":
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).
                                Log(Status.Info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                        case "Then":
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).
                                Log(Status.Info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                        case "And":
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).
                                Log(Status.Info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                    }
                }
                //Fail Status
                else if (GetTestResult() == ScenarioExecutionStatus.TestError.ToString())
                {
                    switch (GetStepType())
                    {
                        case "Given":
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).
                                Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                        case "When":
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).
                                Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                        case "Then":
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).
                                Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                        case "And":
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).
                                Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                    }
                }
                //Pending Status            
                if (GetTestResult() == ScenarioExecutionStatus.StepDefinitionPending.ToString())
                {
                    switch (GetStepType())
                    {
                        case "Given":
                            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).
                                Skip("Step Definition Pending", MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                        case "When":
                            scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).
                                Skip("Step Definition Pending", MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                        case "Then":
                            scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).
                                Skip("Step Definition Pending", MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                        case "And":
                            scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).
                                Skip("Step Definition Pending", MediaEntityBuilder.CreateScreenCaptureFromBase64String(GetScreenShot()).Build());
                            break;
                    }
                }
            }
            catch(Exception)
            {
                throw new Exception("The step name has not been captured for the report");
            }
        }

        [AfterScenario]
        public static void ExecuteAllAssert()
        { 
        }

        /// <summary>
        /// Tears down.
        /// </summary>
        [AfterFeature]
        public static void TearDown()
        {
            try
            {
                //Save report
                extent.Flush();

                ExitBroser();
            }
            catch(Exception)
            {
                throw new Exception("The report has not been saved");
            }
        }
        #endregion
    }
}
