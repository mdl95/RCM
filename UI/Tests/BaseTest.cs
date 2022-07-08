using Allure.Commons;
using log4net;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using RCM.UI.Methods;
using RCM.UI.Support;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace RCM_UI.Tests
{
    [TestFixture]
    [AllureNUnit]
    public abstract class BaseTest
    {
        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private bool _stopTests;
        private Stopwatch _stopwatch = new Stopwatch();


        #region PAGE OBJECTS

        protected LoginPage loginPage = new LoginPage();
        protected ClaimsPage claimsPage = new ClaimsPage();

        #endregion PAGE OBJECTS


        #region NUNIT HOOKS

        [OneTimeSetUp]
        protected void OneTimeSetUp()
        {
            TestData.UniqueCode = GenerateUniqueCode();

            SetupDriver();
            //AllureLifecycle.Instance.CleanupResultDirectory();
        }

        [SetUp]
        protected void SetUp()
        {
            _stopwatch.Start();

            Console.WriteLine($"\n            Test: {TestContext.CurrentContext.Test.Name}");

            if (_stopTests)
            {
                Assert.Inconclusive("Test skipped...");
            }
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            Driver.Instance.Quit();
            CleanupChromeInstances();
            CleanupFirefoxInstances();
            CleanupEdgeInstances();
        }

        [TearDown]
        protected void TearDown()
        {
            var category = (IList)TestContext.CurrentContext.Test.Properties["Category"];
            var path = $"{TestData.Workspace}\\screenshots\\{TestData.UniqueCode} - {TestContext.CurrentContext.Test.Name}.png";

            Console.WriteLine($"   Browser Title: {Driver.Instance.Title}");
            Console.WriteLine($"             URL: {Driver.Instance.Url}");

            _stopwatch.Stop();
            Console.WriteLine($"  Execution Time: {_stopwatch.Elapsed}");
            Console.WriteLine($"   Error Message: {TestContext.CurrentContext.Result.Message}");
            _stopwatch.Reset();

            TakeScreenshot(TestData.UniqueCode, TestContext.CurrentContext.Test.Name);
            AllureLifecycle.Instance.AddAttachment(TestData.UniqueCode, "image/png", path);

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed && category.Count != 0 && category[0].Equals("Critical"))
            {
                _stopTests = true;
            }
        }

        #endregion NUNIT HOOKS


        protected static string GenerateUniqueCode()
        {
            string uniqueCode = PadSingleDigit(DateTime.Now.Month) +
                PadSingleDigit(DateTime.Now.Day) +
                DateTime.Now.Year.ToString().Substring(2) + "-" +
                PadSingleDigit(DateTime.Now.Hour) +
                PadSingleDigit(DateTime.Now.Minute) +
                PadSingleDigit(DateTime.Now.Second) + "-" +
                DateTime.Now.Millisecond.ToString();

            return uniqueCode;
        }


        #region INTERNAL SUPPORT

        private void SetupDriver()
        {
            Driver.Initialize(Driver.Browser.CHROME);

            try
            {
                Driver.Instance.Manage().Window.Maximize();
            }
            catch
            {
                Console.WriteLine("Error when trying to initialize page. The Driver instance may not been created");
            }
        }

        private static string PadSingleDigit(int digit)
        {
            string paddedDigit;

            if (digit < 10)
            {
                paddedDigit = "0" + digit;
            }
            else
            {
                paddedDigit = digit.ToString();
            }

            return paddedDigit;
        }

        private void TakeScreenshot(string uniqueCode, string test)
        {
            string testName = $"{uniqueCode} - {test}";
            string folderPath = $"{TestData.Workspace}\\screenshots\\";
            string screenshotPath = $"{folderPath}{testName}.png";

            CheckForScreenshotsFolder(folderPath);
            Screenshot screenshot = (Driver.Instance as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
        }

        private void CheckForScreenshotsFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                DirectoryInfo folder = Directory.CreateDirectory(folderPath);
            }
        }

        private void CleanupChromeInstances()
        {
            Process[] chromeDriverInstances = Process.GetProcessesByName("chromedriver");
            CleanupProcess(chromeDriverInstances);
        }

        private void CleanupFirefoxInstances()
        {
            Process[] geckoDriverInstances = Process.GetProcessesByName("geckodriver");
            CleanupProcess(geckoDriverInstances);
        }

        private void CleanupEdgeInstances()
        {
            Process[] edgeDriverInstances = Process.GetProcessesByName("msedgedriver");
            CleanupProcess(edgeDriverInstances);
        }

        private void CleanupProcess(Process[] processes)
        {
            foreach (Process process in processes)
            {
                process.StartInfo.Verb = "runas";
                process.Kill();
                process.CloseMainWindow();
                process.Close();
            }
        }

        #endregion INTERNAL SUPPORT
    }
}