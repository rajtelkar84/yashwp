using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class KpisPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public KpisPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region KpisPage Elements

        public IWebElement KpisAbstractionTabTitle => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='KPIS']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetKPIToZoom(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/parent::*/descendant::*[@content-desc='zoomIcon']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> GetKPIToRefresh(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='RefreshBlock']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> GetKPIToFavorite(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='Favourite']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> KpiPageTitle => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='PageTitleLabel']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetKPIToApplyFilterOn(string kpiName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + kpiName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='MicroFilter']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> GetMicroFilterOption(string option)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + option + "') and @content-desc='Name']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> AppliedMicroFilterText => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='AppliedMicroFilterText']"), iosLocator: MobileBy.XPath(""));

        #endregion KpisPage Elements

        #region KpisPage Actions

        public void SelectKPIToZoom(string kpiName)
        {
            try
            {
                //IList<IWebElement> zoomButton = GetKPIToZoom(kpiName);

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

        public void SelectKPIToRefresh(string kpiName)
        {
            try
            {
                //IList<IWebElement> refreshButton = GetKPIToRefresh(kpiName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetKPIToRefresh(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetKPIToRefresh(kpiName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available/configured to Zoom");
            }
        }

        public void SelectKPIToApplyFilterOn(string kpiName)
        {
            try
            {
                //IList<IWebElement> filterButton = GetKPIToApplyFilterOn(kpiName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetKPIToApplyFilterOn(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetKPIToApplyFilterOn(kpiName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available/configured to Zoom");
            }
        }

        public FilterPage SelectMicroFilterOption(string option)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetMicroFilterOption(option).Count == 0)
                {
                    ScrollUpInMicroFilterView();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetMicroFilterOption(option)[0].Click();
                WaitForMoment(3);
                return new FilterPage(_driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{option} Micro filter option is not available");
            }
            return null;
        }

        public void VerifyKpiPageTitle(string kpiName)
        {
            try
            {
                WaitForMoment(2);
                Assert.IsTrue(KpiPageTitle.Count > 0);
                Assert.IsTrue(KpiPageTitle[0].Displayed);
                Assert.IsTrue(KpiPageTitle[0].Text.Equals(kpiName));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not Zoomed in.");
            }
        }

        public void SelectKPIToFavorite(string kpiName)
        {
            try
            {
                //IList<IWebElement> favoriteIcon = GetKPIToFavorite(kpiName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetKPIToFavorite(kpiName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetKPIToFavorite(kpiName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available/configured to Zoom");
            }
        }

        #endregion KpisPage Actions
    }
}
