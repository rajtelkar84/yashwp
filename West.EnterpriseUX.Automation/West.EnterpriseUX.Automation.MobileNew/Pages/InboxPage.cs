using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;
using West.EnterpriseUX.Automation.MobileNew.Setup;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class InboxPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public InboxPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region InboxPage Elements

        public IList<IWebElement> PersonaName(string personaName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='"+ personaName + "']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> InboxName(string inboxName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + inboxName + "']"), iosLocator: MobileBy.XPath(""));
        }
        public IWebElement GlobalSearchIcon => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='SearchIcon']"), iosLocator: MobileBy.XPath(""));
        public IWebElement SearchForInbox => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='InboxPicker_Container']"), iosLocator: MobileBy.XPath(""));
        public IWebElement SearchForRecords => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='SearchRecords_Container']"), iosLocator: MobileBy.XPath(""));
        public IWebElement SearchButton => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='SEARCH']"), iosLocator: MobileBy.XPath(""));
        public IWebElement InboxNameText => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='InboxName']"), iosLocator: MobileBy.XPath(""));

        #endregion

        #region InboxPage Actions

        public void NavigateToInbox(string persona, string inbox)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (PersonaName(persona).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                PersonaName(persona)[0].Click();

                Thread.Sleep(1000);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (InboxName(inbox).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                InboxName(inbox)[0].Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DetailsPage PerformGlobalSearch(string persona, string inbox, string searchRecord)
        {
            try
            {
                GlobalSearchIcon.Click();
                WaitForMoment(1);
                SearchForInbox.Click();
                new Actions(_driver).SendKeys(inbox.Trim() + " (" + persona.Trim() + ")").Perform();
                new Actions(_driver).SendKeys(Keys.Enter).Perform();
                WaitForMoment(1);
                SearchForRecords.Click();
                new Actions(_driver).SendKeys(searchRecord.Trim()).Perform();
                new Actions(_driver).SendKeys(Keys.Enter).Perform();
                WaitForMoment(1);
                SearchButton.Click();

                return new DetailsPage(_driver);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
            return null;
        }

        #endregion
    }
}
