using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
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

        #endregion

        #region InboxPage Actions

        public void NavigateToInbox(string persona, string inbox)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (PersonaName(persona).Count == 0)
                {
                    Scroll();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                PersonaName(persona)[0].Click();

                Thread.Sleep(1000);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (InboxName(inbox).Count == 0)
                {
                    Scroll();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                InboxName(inbox)[0].Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
