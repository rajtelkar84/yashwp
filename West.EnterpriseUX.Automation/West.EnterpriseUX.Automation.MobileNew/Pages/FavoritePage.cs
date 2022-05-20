using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.MobileNew.Setup;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class FavoritePage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public FavoritePage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region FavoritePage Elements

        public IWebElement InboxesTab => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='Inboxes']"), iosLocator: MobileBy.XPath(""));
        public IWebElement KPIsAndChartsTab => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='KPIs & Charts']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> CheckForInboxInFavoriteInboxes(string inboxName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + inboxName + "']"), iosLocator: MobileBy.XPath(""));
        }
        #endregion FavoritePage Elements

        #region FavoritePage Actions

        #endregion FavoritePage Actions
    }
}
