using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;

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
        public IWebElement KPIsAndChartsTab => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@content-desc='KPIs & ChartsSelected tab']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> CheckForInboxInFavoriteInboxes(string inboxName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + inboxName + "']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> CheckForKPIsAndChartsInFavorite(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + kpiName + "' and @content-desc='Title']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> InboxFavouriteIcons => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='InboxFavourite']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> KpisAndChartsFavouriteIcons => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Favourite']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetKPIToZoom(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/parent::*/descendant::*[@content-desc='zoomIcon']"), iosLocator: MobileBy.XPath(""));
        }

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

        public void UnfavoriteAllKPIsAndCharts()
        {
            try
            {
                if (KPIsAndChartsTab.Displayed)
                {
                    KPIsAndChartsTab.Click();
                    WaitForMoment(10);
                }

                IList<IWebElement> favouriteIcons = KpisAndChartsFavouriteIcons;

                while (favouriteIcons.Count > 0)
                {
                    favouriteIcons[0].Click();
                    WaitForMoment(5);
                    favouriteIcons = KpisAndChartsFavouriteIcons;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SelectKPIToZoom(string kpiName)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetKPIToZoom(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetKPIToZoom(kpiName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available/configured to Zoom");
            }
        }


        #endregion FavoritePage Actions
    }
}
