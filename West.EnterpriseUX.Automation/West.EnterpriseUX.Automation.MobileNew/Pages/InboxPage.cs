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
        public IWebElement DetailsAbstractionTab => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='Details']"), iosLocator: MobileBy.XPath(""));
        public IWebElement KpisAbstractionTab => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='KPIs']"), iosLocator: MobileBy.XPath(""));
        public IWebElement ChartsAbstractionTab => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='Charts']"), iosLocator: MobileBy.XPath(""));
        public IWebElement StoryboardsAbstractionTab => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='Storyboards']"), iosLocator: MobileBy.XPath(""));
        
        #endregion InboxPage Elements

        #region InboxPage Actions

        public KpisPage NavigateToInbox(string persona, string inbox)
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

                return new KpisPage(_driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
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

        public DetailsPage NavigateToInboxByGlobalSearch(string persona, string inbox)
        {
            try
            {
                GlobalSearchIcon.Click();
                WaitForMoment(1);
                SearchForInbox.Click();
                new Actions(_driver).SendKeys(inbox.Trim() + " (" + persona.Trim() + ")").Perform();
                new Actions(_driver).SendKeys(Keys.Enter).Perform();
                WaitForMoment(1);
                SearchButton.Click();

                return new DetailsPage(_driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public KpisPage OpenKpisAbstraction()
        {
            try
            {
                if (KpisAbstractionTab.Displayed && KpisAbstractionTab.Enabled)
                {
                    KpisAbstractionTab.Click();
                    return new KpisPage(_driver);
                }
                else
                {
                    Console.WriteLine("Kpis abstraction is not displayed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public ChartsPage OpenChartsAbstraction()
        {
            try
            {
                if(ChartsAbstractionTab.Displayed && ChartsAbstractionTab.Enabled)
                {
                    ChartsAbstractionTab.Click();
                    return new ChartsPage(_driver);
                }
                else
                {
                    Console.WriteLine("Charts abstraction is not displayed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public StoryboardsPage OpenStoryboardsAbstraction()
        {
            try
            {
                if (StoryboardsAbstractionTab.Displayed && StoryboardsAbstractionTab.Enabled)
                {
                    StoryboardsAbstractionTab.Click();
                    return new StoryboardsPage(_driver);
                }
                else
                {
                    Console.WriteLine("Storyboards abstraction is not displayed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        #endregion InboxPage Actions
    }
}
