using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Threading;
using West.EnterpriseUX.Automation.MobileNew.Setup;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class BasePage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
        public InboxPage _inboxPageInstance;

        public BasePage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region BasePage Elements

        public IList<IWebElement> LoaderImage => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='LoaderImage']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> HamberMenu => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='hamberMenu']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> Logout => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Logout']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> LogoutOkButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='okButton']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> AllLoadingTexts => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text,'Loading') or contains(@text,'Fetching') or contains(@text,'Fetching Modules') or contains(@text,'Preparing') or contains(@text,'Retry') or contains(@text,'Authenticating user') or contains(@text,'Adding') or contains(@text,'Saving') or contains(@text,'Deleting') or contains(@text,'Removing') or contains(@text,'Refreshing') or contains(@text,'Please wait') or contains(@text,'Sharing Insights') or contains(@text,'Fetching')]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> UserInfromationPopUp => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='confirmationOptions']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> DashboardIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/icon'])[1]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FavoriteIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/icon'])[2]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> InsightsIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/icon'])[3]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> InboxesIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/icon'])[4]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> MyTaskIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("(//*[@resource-id='com.westpharma.uxframework.uat:id/icon'])[5]"), iosLocator: MobileBy.XPath(""));

        #endregion

        #region BasePage Actions

        public InboxPage NavigateToInboxPage()
        {
            try
            {
                if(InboxesIcon.Count > 0)
                {
                    InboxesIcon[0].Click();
                    Thread.Sleep(2000);
                    _inboxPageInstance = new InboxPage(_driver);
                    return _inboxPageInstance;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        #endregion
    }
}
