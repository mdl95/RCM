using NUnit.Allure.Core;
using NUnit.Framework;
using RCM.UI.Methods;
using RCM.UI.Support;
using RCM_UI.Tests;
using System;

namespace RCM.UI.Tests.Smoke
{
    [TestFixture]
    [AllureNUnit]
    public class SmokeTest : BaseTest
    {
        [Test, Order(0)]
        public void System_DisplayTestEnvironmentInfo()
        {
            Console.WriteLine($"Operating System: {Environment.OSVersion}");
            Console.WriteLine($"    Machine Name: {Environment.MachineName}");
            //Console.WriteLine($"         Browser: {TestData.BrowserName}");
            //Console.WriteLine($" Browser Version: {TestData.BrowserVersion}");
        }

        [Test, Order(10), Category("Critical")]
        public void UI_User_CanGoToLoginPage()
        {
            loginPage.GoToLoginPage(Config.DEV_URL_RCM_CONSOLE);

            Assert.That(loginPage.IsRCMLoginPageDisplayed(), Is.True);
        }

        [Test, Order(20), Category("Critical")]
        public void UI_User_AreAllLoginPageElementsDisplayed()
        {
            Assert.Multiple(() =>
            {
                Assert.That(loginPage.IsLoginPageElementDisplayed(LoginPage.LOGO), 
                    Is.True, "Outbound logo not displayed or its locator has changed...");
                Assert.That(loginPage.IsLoginPageElementDisplayed(LoginPage.EMAIL_TEXTBOX),
                    Is.True, "Email label not displayed or its locator has changed...");
                Assert.That(loginPage.IsLoginPageElementDisplayed(LoginPage.EMAIL_TEXTBOX),
                    Is.True, "Email textbox not displayed or its locator has changed...");
                Assert.That(loginPage.IsLoginPageElementDisplayed(LoginPage.PASSWORD_LABEL),
                    Is.True, "Password label not displayed or its locator has changed...");
                Assert.That(loginPage.IsLoginPageElementDisplayed(LoginPage.PASSWORD_TEXTBOX),
                    Is.True, "Password textbox not displayed or its locator has changed...");
                Assert.That(loginPage.IsLoginPageElementDisplayed(LoginPage.LOGIN_BUTTON),
                    Is.True, "Login button not displayed or its locator has changed...");
                Assert.That(loginPage.IsLoginPageElementDisplayed(LoginPage.FORGOT_PASSWORD_LINK),
                    Is.True, "Forgot Password link not displayed or its locator has changed...");
            });
        }

        [Test, Order(30), Category("Critical")]
        public void UI_User_IsClaimsPageDisplayed()
        {
            loginPage.SetEmail(Config.DEV_EMAIL);
            loginPage.SetPassword(Config.DEV_PASSWORD);
            loginPage.ClickLogin();

            Assert.That(claimsPage.IsClaimsHeaderDisplayed(), Is.True);
        }

        [Test, Order(40)]
        public void UI_User_AreAllClaimsPageStatusNeededColumnsDisplayed()
        {
            Assert.Multiple(() =>
            {
                foreach (string column in TestData.StatusNeededColumns)
                {
                    Assert.That(claimsPage.IsColumnDisplayed(column),
                        Is.True, $"{column} column not displayed or has changed...");
                }
            });
        }
    }
}
