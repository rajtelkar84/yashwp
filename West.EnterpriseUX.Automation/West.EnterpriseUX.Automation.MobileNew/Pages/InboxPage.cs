using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
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

        public IList<IWebElement> LoaderImage => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='LoaderImage']"), iosLocator: MobileBy.XPath(""));
       
        #endregion

        #region InboxPage Actions

        public void NavigateToInbox(string function, string inboxName)
        {
            try
            {
                Console.Write(function + ", " + inboxName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
    }
}
