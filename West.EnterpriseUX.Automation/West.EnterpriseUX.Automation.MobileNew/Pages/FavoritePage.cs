using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
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

        public IWebElement InboxesTab => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='InboxesSelected tab']"), iosLocator: MobileBy.XPath(""));
        public IWebElement KPIsAndChartsTab => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='KPIs & Charts']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> CheckForInboxInFavoriteInboxes(string inboxName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + inboxName + "']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> InboxFavouriteIcons => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='InboxFavourite']"), iosLocator: MobileBy.XPath(""));


        #endregion FavoritePage Elements

        #region FavoritePage Actions

        public void UnfavoriteAllInboxes()
        {
            try
            {
                if (InboxesTab.Displayed)
                {
                    InboxesTab.Click();
                    WaitForMoment(1);
                }
                
                IList<IWebElement> inboxFavouriteIcons = InboxFavouriteIcons;

                while (inboxFavouriteIcons.Count > 0)
                {
                    inboxFavouriteIcons[0].Click();
                    WaitForMoment(5);
                    inboxFavouriteIcons = InboxFavouriteIcons;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion FavoritePage Actions
    }
}
