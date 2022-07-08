using OpenQA.Selenium;

namespace RCM.UI.Methods
{
    public class ClaimsPage : BaseMethods
    {
        #region LOCATORS

        public static By CLAIMS_HEADER = By.CssSelector("main h1");

        public By GetClaimsPageTableLocator(string column) =>
            By.CssSelector($"main [data-testid='tableComponent'] table tr th[title='{column}']");

        #endregion LOCATORS


        #region METHODS
        #endregion METHODS


        #region VERIFICATIONS

        public bool IsClaimsHeaderDisplayed() => 
            VerifyElementAndText(CLAIMS_HEADER, "Claims");

        public bool IsColumnDisplayed(string column) => 
            VerifyElementAndText(GetClaimsPageTableLocator(column), column.ToUpper());

        #endregion VERIFICATIONS
    }
}
