using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace RCM.UI.Support
{
    public static class Driver
    {
        public enum Browser
        {
            CHROME, EDGE, FIREFOX
        }


        [ThreadStatic]
        public static IWebDriver Instance;

        public static void Initialize(Browser browser)
        {
            switch (browser)
            {
                case Browser.CHROME:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    ChromeOptions chromeOptions = new ChromeOptions();
                    //chromeOptions.AddUserProfilePreference("download.default_directory", "");
                    chromeOptions.AddArgument("--disable-web-security");
                    chromeOptions.AcceptInsecureCertificates = true;
                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    Instance = new ChromeDriver(chromeOptions);
                    break;
                case Browser.EDGE:
                    // https://docs.microsoft.com/en-us/microsoft-edge/webdriver-chromium/capabilities-edge-options
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    EdgeOptions edgeOptions = new EdgeOptions();
                    edgeOptions.AddArgument("--disable-web-security");
                    edgeOptions.AcceptInsecureCertificates = true;
                    edgeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    Instance = new EdgeDriver(edgeOptions);
                    break;
                case Browser.FIREFOX:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    FirefoxOptions firefoxOptions = new FirefoxOptions();
                    FirefoxProfile firefoxProfile = new FirefoxProfile();
                    TestData.BrowserName = firefoxOptions.BrowserName;
                    TestData.BrowserVersion = firefoxOptions.BrowserVersion;
                    //firefoxProfile.SetPreference("download.default_directory", "");
                    firefoxOptions.Profile = firefoxProfile;
                    firefoxOptions.AddArgument("--disable-web-security");
                    firefoxOptions.AcceptInsecureCertificates = true;
                    firefoxOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    Instance = new FirefoxDriver(firefoxOptions);
                    break;
                default:
                    break;
            }

            Instance.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(5);
            Instance.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(180);
            //Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }
    }
}