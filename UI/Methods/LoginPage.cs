using OpenQA.Selenium;

namespace RCM.UI.Methods
{
    public class LoginPage : BaseMethods
    {
        #region LOCATORS

        public static By LOGO = By.CssSelector(".logo[data-testid='companyLogo']");
        public static By EMAIL_LABEL = By.CssSelector("label[for='usernameField']");
        public static By EMAIL_TEXTBOX = By.Id("usernameField");
        public static By PASSWORD_LABEL = By.CssSelector("label[for='password']");
        public static By PASSWORD_TEXTBOX = By.Id("password");
        public static By LOGIN_BUTTON = By.CssSelector("button[data-testid='login-button']");
        public static By FORGOT_PASSWORD_LINK = By.CssSelector(".forgot-password");

        #endregion LOCATORS


        #region METHODS

        public void GoToLoginPage(string url) => GoToPage(url);

        public void SetEmail(string email) => SetTextboxValue(EMAIL_TEXTBOX, email);

        public void SetPassword(string password) => SetTextboxValue(PASSWORD_TEXTBOX, password);

        public void ClickLogin() => ClickElement(LOGIN_BUTTON);

        #endregion METHODS


        #region VERIFICATIONS

        public bool IsRCMLoginPageDisplayed() => 
            IsElementDisplayed(LOGO);

        public bool IsLoginPageElementDisplayed(By locator) =>
            IsElementDisplayed(locator);

        public bool IsLoginPageElementDisplayed(By locator, string expectedText) =>
            VerifyElementAndText(locator, expectedText);

        #endregion VERIFICATIONS
    }
}
