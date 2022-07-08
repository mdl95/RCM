using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using RCM.UI.Support;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;

namespace RCM.UI.Methods
{
    public abstract class BaseMethods
    {
        protected const int TIME_OUT = 90;
        protected const int DEFAULT_SYNCH_WAIT_SECONDS = 1;
        protected const int PAGE_LOAD_WAIT_SECONDS = 120;
        protected const int ELEMENT_WAIT_PERIOD_SECONDS = 15;

        protected static string status;
        protected static IList<IWebElement> elements;

        protected static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        protected IWebElement GetElement(By locator)
        {
            try
            {
                new WebDriverWait(Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return Driver.Instance.FindElement(locator);
        }

        protected IList<IWebElement> GetElements(IWebElement element, By locator)
        {
            try
            {
                new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return element.FindElements(locator);
        }


        protected bool VerifyElementAndText(By element, string expectedText)
        {
            bool result = true;
            string message = "";
            string actualText = "";

            if (!IsElementDisplayed(element))
            {
                message = "Element was not displayed...";
                result = false;
            }
            else
            {
                actualText = GetTextFromElement(element).Trim();
            }

            if (!actualText.StartsWith(expectedText))
            {
                message = $"Expected [{expectedText}] but actual text was [{actualText}]";
                result = false;
            }

            if (!result)
            {
                Log.Warn(message);
            }

            return result;
        }

        protected string ExecuteJavaScript(string javascript)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver.Instance;
            return (string)executor.ExecuteScript(javascript);
        }

        protected void GoToPage(string url)
        {
            try
            {
                Driver.Instance.Navigate().GoToUrl(url);
            }
            catch (WebDriverException e)
            {
                Log.Error($"ERROR: Could not access {url}\n{e.Message}");
            }
        }

        protected void ClickElement(By locator)
        {
            try
            {
                new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Click();
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }
        }

        protected void SelectDropdownValue(By locator, String value)
        {
            try
            {
                new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

                ClickElement(locator);

                SelectElement selectElement = new SelectElement(Driver.Instance.FindElement(locator));
                selectElement.SelectByText(value);
                ClickElement(locator);
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }
        }

        protected void SetTextboxValue(By locator, string value)
        {
            try
            {
                IWebElement element = new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

                element.Clear();
                element.SendKeys(value);
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }
        }

        protected string GetTextFromElement(By locator)
        {
            var text = "";

            try
            {
                text = new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Text.Trim();
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return text;
        }

        protected string GetJSPropertyValueFromElement(By locator, string javascript)
        {
            string value = "";

            try
            {
                new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
                value = (string)ExecuteJavaScript(javascript);
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return value;
        }

        protected string GetAttributeValueFromElement(By locator, string attribute)
        {
            string value = "";

            try
            {
                value = new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).GetAttribute(attribute);
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return value;
        }

        protected string GetCssValueFromElement(By locator, string cssProperty)
        {
            var value = "";

            try
            {
                value = new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).GetCssValue(cssProperty);
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return value;
        }

        protected string GetSelectedValueFromElement(By locator)
        {
            var text = "";

            try
            {
                new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

                ClickElement(locator);

                SelectElement selectElement = new SelectElement(Driver.Instance.FindElement(locator));

                text = selectElement.SelectedOption.Text;
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return text;
        }

        protected bool IsElementDisplayedNoWait(By locator)
        {
            bool isElementDisplayed;

            try
            {
                if (new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(3)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Displayed)
                {
                    isElementDisplayed = true;
                }
                else
                {
                    isElementDisplayed = false;
                }
            }
            catch (Exception e)
            {
                if (e is WebDriverException)
                {
                    isElementDisplayed = false;
                    ProcessError(e, locator);
                }
                else
                {
                    isElementDisplayed = false;
                }
            }

            return isElementDisplayed;
        }

        protected bool IsElementDisplayed(By locator)
        {
            bool isElementDisplayed;

            try
            {
                if (new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Displayed)
                {
                    isElementDisplayed = true;
                }
                else
                {
                    isElementDisplayed = false;
                }
            }
            catch (Exception e)
            {
                if (e is WebDriverException)
                {
                    isElementDisplayed = false;
                    ProcessError(e, locator);
                }
                else
                {
                    isElementDisplayed = false;
                }
            }

            return isElementDisplayed;
        }

        protected bool IsElementEnabled(By locator)
        {
            bool isElementEnabled = false;

            try
            {
                isElementEnabled = new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).Enabled;
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return isElementEnabled;
        }

        protected bool IsElementNotDisplayed(By locator)
        {
            bool isElementNotDisplayed;

            try
            {
                if (new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator)))
                {
                    isElementNotDisplayed = true;
                }
                else
                {
                    isElementNotDisplayed = false;
                }
            }
            catch (Exception)
            {
                isElementNotDisplayed = false;
            }

            return isElementNotDisplayed;
        }

        private void ProcessError(Exception e, By locator)
        {
            string error;

            if (e is ElementNotVisibleException ||
                e is NoSuchElementException ||
                e is TimeoutException ||
                e is WebDriverException ||
                e is WebDriverTimeoutException)
            {
                error = "Following element not found: " + locator.ToString();
            }
            else if (e is InvalidOperationException)
            {
                error = locator.ToString() + " possibly blocked by another element...";
            }
            else
            {
                error = "Check the " + locator.ToString() + " locator...";
            }

            Console.WriteLine(error);
        }

        protected void Synch(int seconds) => Thread.Sleep(seconds * 1000);

        protected bool IsPageSynched(By element)
        {
            bool isPageSynched;
            int timer = 0;

            while ((!IsElementDisplayedNoWait(element)) && timer < PAGE_LOAD_WAIT_SECONDS)
            {
                Synch(1);
                timer++;
            }

            if (timer < PAGE_LOAD_WAIT_SECONDS)
            {
                isPageSynched = true;
            }
            else
            {
                isPageSynched = false;
            }

            return isPageSynched;
        }

        protected IList<IWebElement> GetOptionsInSelectElement(By locator)
        {
            try
            {
                new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

                SelectElement selectElement = new SelectElement(Driver.Instance.FindElement(locator));
                elements = selectElement.Options;
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return elements;
        }

        protected int GetNumberOfOptionsInSelectElement(By locator)
        {
            int numberOfOptions = 0;

            try
            {
                new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));

                SelectElement selectElement = new SelectElement(Driver.Instance.FindElement(locator));
                elements = selectElement.Options;
                numberOfOptions = elements.Count;
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return numberOfOptions;
        }

        protected bool DoActualItemsMatchExpectedItems(IList<IWebElement> actualItems, string[] expectedItems)
        {
            bool[] expectedItemsAccountedFor = new bool[expectedItems.Length];
            string webElementString;
            bool doActualItemsMatchExpectedItems = true;
            bool isThereAMatch;

            for (int i = 0; i < expectedItemsAccountedFor.Length; ++i)
            {
                expectedItemsAccountedFor[i] = false;
            }

            foreach (IWebElement item in actualItems)
            {
                isThereAMatch = false;
                webElementString = item.Text.Trim();

                for (int i = 0; i < expectedItems.Length; ++i)
                {
                    if (webElementString.Trim().Equals(expectedItems[i]))
                    {
                        isThereAMatch = true;
                        expectedItemsAccountedFor[i] = true;
                    }
                    else
                    {
                        isThereAMatch = false;
                    }
                }

                if (!isThereAMatch)
                {
                    StringBuilder error = new StringBuilder("Expecting:");

                    foreach (string expectedItem in expectedItems)
                    {
                        error.Append("\n" + expectedItem);
                    }

                    error.Append("\nActual:");
                    foreach (IWebElement actualItem in actualItems)
                    {
                        error.Append("\n" + actualItem.Text);
                    }
                }
            }

            for (int i = 0; i < expectedItemsAccountedFor.Length; ++i)
            {
                if (!expectedItemsAccountedFor[i])
                {
                    doActualItemsMatchExpectedItems = false;
                }
            }

            return doActualItemsMatchExpectedItems;
        }

        protected string GetCssValue(By locator, string css)
        {
            string cssValue = "";

            try
            {
                cssValue = new WebDriverWait(
                    Driver.Instance,
                    TimeSpan.FromSeconds(ELEMENT_WAIT_PERIOD_SECONDS)).
                    Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator)).GetCssValue(css);
            }
            catch (Exception e)
            {
                ProcessError(e, locator);
            }

            return cssValue;
        }

        protected void RefreshBrowser()
        {
            Driver.Instance.Navigate().Refresh();
        }

        protected int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        protected bool IsCheckboxChecked(By checkbox)
        {
            bool isCheckboxChecked;
            string cssValue = GetCssValue(checkbox, "background-image");

            if (cssValue.Equals("none"))
            {
                isCheckboxChecked = false;
            }
            else
            {
                isCheckboxChecked = true;
            }

            return isCheckboxChecked;
        }

        protected string GetUrl()
        {
            return Driver.Instance.Url;
        }

        protected string PadSingleDigit(int digit)
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

        protected DateTime GetAdjustedTime()
        {
            const double TIME_DIFFERENCE_BETWEEN_LOCAL_AND_SERVER_HOURS = -3.0;

            DateTime dateTime = DateTime.Now.AddHours(TIME_DIFFERENCE_BETWEEN_LOCAL_AND_SERVER_HOURS);

            return dateTime;
        }
    }
}
