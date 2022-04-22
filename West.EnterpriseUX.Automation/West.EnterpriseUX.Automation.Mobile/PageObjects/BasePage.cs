using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using West.EnterpriseUX.Automation.Mobile.Utilities;

namespace West.EnterpriseUX.Automation.Mobile.PageObjects
{
    public class BasePage : BaseTest
    {
        public static AppiumDriver<AppiumWebElement> _driver;
       

        public BasePage(AppiumDriver<AppiumWebElement> driver)
        {
            _driver = driver;
        }

        public AppiumWebElement FindElement(string locator)
        {
            AppiumWebElement mobileElement = null;
            string locatorType = string.Empty;
            string locatorValue = string.Empty;
            string[] xpathExpression = locator.Split(new char[] { ':' }, 2);
            locatorType = xpathExpression[0].ToLower();
            locatorValue = xpathExpression[1];

            switch (locatorType)
            {
                case "accessibilityid":
                    mobileElement = _driver.FindElementByAccessibilityId(locatorValue);
                    break;
                case "classname":
                    mobileElement = _driver.FindElementByClassName(locatorValue);
                    break;
                case "name":
                    mobileElement = _driver.FindElementByName(locatorValue);
                    break;
                case "xpath":
                    mobileElement = _driver.FindElementByXPath(locatorValue);
                    break;
                case "id":
                    mobileElement = _driver.FindElementById(locatorValue);
                    break;
                default:
                    Console.WriteLine("Search field is not found");
                    break;
            }
            return mobileElement;
        }
        public IList<AppiumWebElement> FindElements(string locator)
        {
            IList<AppiumWebElement> mobileElement = null;
            string locatorType = string.Empty;
            string locatorValue = string.Empty;
            string[] xpathExpression = locator.Split(new char[] { ':' }, 2);
            locatorType = xpathExpression[0].ToLower();
            locatorValue = xpathExpression[1];

            switch (locatorType)
            {
                case "accessibilityid":
                    mobileElement = _driver.FindElementsByAccessibilityId(locatorValue).ToList();
                    break;
                case "classname":
                    mobileElement = _driver.FindElementsByClassName(locatorValue);
                    break;
                case "name":
                    mobileElement = _driver.FindElementsByName(locatorValue);
                    break;
                case "xpath":
                    mobileElement = _driver.FindElementsByXPath(locatorValue);
                    break;
                case "id":
                    mobileElement = _driver.FindElementsById(locatorValue);
                    break;
                default:
                    Console.WriteLine("Search field is not found");
                    break;
            }
            return mobileElement;
        }

        #region Common Elements

        #region IOS Platform
        public IList<AppiumWebElement> IOSSkipButton => FindElements(Locators.Name.ToString() + ":Skip");
        public IList<AppiumWebElement> IOSOkButton => FindElements(Locators.AccessibilityId.ToString() + ":OK");
        public IList<AppiumWebElement> IOSLoaders => FindElements(Locators.AccessibilityId.ToString() + ":LoaderLabel");
        public IList<AppiumWebElement> IOSUserConfirmation => FindElements(Locators.AccessibilityId.ToString() + ":I Understand");

        #endregion

        #region Android Platform

        public IWebElement AndroidHomeTitle => FindElement(Locators.AccessibilityId.ToString() + ":wdTitle");
        public IWebElement AndroidRefresh => FindElement(Locators.AccessibilityId.ToString() + ":Refresh");
        public IWebElement AndroidProfile => FindElement(Locators.AccessibilityId.ToString() + ":ProfileImage");
        public IWebElement AndroidFeedback => FindElement(Locators.AccessibilityId.ToString() + ":Feedback");
        public IList<AppiumWebElement> AndroidHamberMenu => FindElements(Locators.AccessibilityId.ToString() + ":hamberMenu");
        public IWebElement AndroidHome => FindElement(Locators.AccessibilityId.ToString() + ":Home");
        public IWebElement AndroidLogout => FindElement(Locators.XPath.ToString() + "://android.widget.TextView[@text='Logout']");
        public IList<AppiumWebElement> ConfirmationMessage => FindElements(Locators.AccessibilityId.ToString() + ":okButton");
        public IWebElement ConfirmationPopUpYes => FindElement(Locators.XPath.ToString() + "://android.widget.Button[@content-desc='okButton']");
        public IList<AppiumWebElement> StartUpModules => FindElements(Locators.XPath.ToString() + "://android.widget.Button[contains(@text,'SKIP')]");
        public IList<AppiumWebElement> AndroidAllLoaderTexts => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Loading') or contains(@text,'Fetching') or contains(@text,'Fetching Modules') or contains(@text,'Preparing') or contains(@text,'Retry') or contains(@text,'Authenticating user') or contains(@text,'Please') or contains(@text,'Logging') or contains(@text,'Adding') or contains(@text,'Saving') or contains(@text,'Deleting') or contains(@text,'Removing') or contains(@text,'Refreshing') or contains(@text,'Please wait')]");
        public IList<AppiumWebElement> AndroidLoaderLabel => FindElements(Locators.AccessibilityId.ToString() + ":LoaderLabel");
        public IList<AppiumWebElement> AndroidLoaderImage => FindElements(Locators.AccessibilityId.ToString() + ":LoaderImage");
        public IList<AppiumWebElement> AndroidProgressImage => FindElements(Locators.Id.ToString() + ":com.westpharma.uxframework.dev:id/loadingProgressBar");
        public IList<AppiumWebElement> AndroidEmptyLabel => FindElements(Locators.AccessibilityId.ToString() + ":EmptyLabel");
        public IList<AppiumWebElement> SelectAbstraction(string abstractionName)
        {
            return FindElements(Locators.XPath.ToString() + $"://android.widget.TextView[@text='{abstractionName}']");
        }
        public IList<AppiumWebElement> AndroidConfirmationOKButton => FindElements(Locators.AccessibilityId.ToString() + ":confirmationOptions");
        public IList<AppiumWebElement> AndroidOKPopUpMessage => FindElements(Locators.AccessibilityId.ToString() + ":dialogMessage");
        public IList<AppiumWebElement> AndroidPostDailog => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@resource-id,'com.westpharma.uxframework.shopfloor.dev:id/snackbar_text')]");
        public IList<AppiumWebElement> AndroidLoaderText => FindElements(Locators.XPath.ToString() + "://android.widget.TextView[contains(@text,'Loading')]");
        public IList<AppiumWebElement> AndroidUserCreatedTab => FindElements(Locators.XPath.ToString() + "://android.view.View[contains(@content-desc,'Created ')]");
        #endregion

        public void WaitForAndroidLoginLoaderToDisappear()
        {
            _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            int timeout = 60;
            Stopwatch stopwatch = new Stopwatch();
            IList<AppiumWebElement> loadingElement = null;
            TimeSpan timeTaken = new TimeSpan();

            WaitForMoment(1);
            stopwatch.Start();
            try
            {
                bool isPresent;
                do
                {
                    loadingElement = AndroidAllLoaderTexts;
                    if (loadingElement.Count > 0)
                    {
                        IList<AppiumWebElement> userInfromationPopUp = ConfirmationMessage;
                        if (userInfromationPopUp.Count > 0)
                        {
                            userInfromationPopUp[0].Click();
                        }
                        isPresent = loadingElement.Count > 0;
                    }
                    else
                    {
                        break;
                    }
                    
                    WaitForMoment(1);
                } while (isPresent && timeTaken.TotalSeconds < timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
            }
            finally
            {
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Console.WriteLine($"Loading Pop-Up : presence on screen = {stopwatch.Elapsed.Seconds} seconds.");
            }
            if (stopwatch.Elapsed.Seconds >= timeout)
            {
                Console.WriteLine($"Loading Pop-Up : is not getting dissappearing even after {timeout} seconds also.");
                Assert.Fail($"Loading Pop-Up : is not getting dissappearing even after {timeout} seconds also");
            }
            stopwatch.Stop();
        }
        public void WaitForAndroidLoaderToDisappear()
        {
            _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            int timeout = 60;
            Stopwatch stopwatch = new Stopwatch();
            IList<AppiumWebElement> loadingElement = null;
            TimeSpan timeTaken = new TimeSpan();

            WaitForMoment(1);
            stopwatch.Start();
            try
            {
                bool isPresent;
                do
                {
                    loadingElement = AndroidLoaderImage;
                    if (loadingElement.Count > 0)
                    {
                        isPresent = loadingElement.Count > 0;
                    }
                    else
                    {
                        break;
                    }

                    WaitForMoment(1);
                } while (isPresent && timeTaken.TotalSeconds < timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
            }
            finally
            {
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Console.WriteLine($"Loading Pop-Up : presence on screen = {stopwatch.Elapsed.Seconds} seconds.");
            }
            if (stopwatch.Elapsed.Seconds >= timeout)
            {
                Console.WriteLine($"Loading Pop-Up : is not getting dissappearing even after {timeout} seconds also.");
                Assert.Fail($"Loading Pop-Up : is not getting dissappearing even after {timeout} seconds also");
            }
            stopwatch.Stop();
        }
        public void WaitForAndroidProgressBarToDisappear()
        {
            _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            int timeout = 60;
            Stopwatch stopwatch = new Stopwatch();
            IList<AppiumWebElement> loadingElement = null;
            TimeSpan timeTaken = new TimeSpan();

            WaitForMoment(1);
            stopwatch.Start();
            try
            {
                bool isPresent;
                do
                {
                    loadingElement = AndroidProgressImage;
                    if (loadingElement.Count > 0)
                    {
                        isPresent = loadingElement.Count > 0;
                    }
                    else
                    {
                        break;
                    }

                    WaitForMoment(1);
                } while (isPresent && timeTaken.TotalSeconds < timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
            }
            finally
            {
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Console.WriteLine($"Loading Pop-Up : presence on screen = {stopwatch.Elapsed.Seconds} seconds.");
            }
            if (stopwatch.Elapsed.Seconds >= timeout)
            {
                Console.WriteLine($"Loading Pop-Up : is not getting dissappearing even after {timeout} seconds also.");
                Assert.Fail($"Loading Pop-Up : is not getting dissappearing even after {timeout} seconds also");
            }
            stopwatch.Stop();
        }
        public void WaitForIOSLoaderToDisappear()
        {
            _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            int timeout = 60;
            Stopwatch stopwatch = new Stopwatch();
            IList<AppiumWebElement> loadingElement = null;
            TimeSpan timeTaken = new TimeSpan();

            WaitForMoment(1);
            stopwatch.Start();
            try
            {
                bool isPresent;
                do
                {
                    loadingElement = IOSLoaders;
                    if (loadingElement.Count > 0)
                    {
                        IList<AppiumWebElement> userInfromationPopUp = IOSOkButton;
                        if (userInfromationPopUp.Count > 0)
                        {
                            userInfromationPopUp[0].Click();
                        }
                        isPresent = loadingElement.Count > 0;
                    }
                    else
                    {
                        break;
                    }

                    WaitForMoment(1);
                } while (isPresent && timeTaken.TotalSeconds < timeout);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message} {ex.StackTrace}");
            }
            finally
            {
                _session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Console.WriteLine($"Loading Pop-Up : presence on screen = {stopwatch.Elapsed.Seconds} seconds.");
            }
            if (stopwatch.Elapsed.Seconds >= timeout)
            {
                Console.WriteLine($"Loading Pop-Up : is not getting dissappearing even after {timeout} seconds also.");
                Assert.Fail($"Loading Pop-Up : is not getting dissappearing even after {timeout} seconds also");
            }
            stopwatch.Stop();
        }
        #endregion
    }
}
