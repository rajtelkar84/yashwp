using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;
using West.EnterpriseUX.Automation.MobileNew.Setup;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class ChartsPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public ChartsPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region ChartsPage Elements

        public IWebElement ChartsAbstractionTabTitle => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='CHARTS']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetAllChartsByFavoriteIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Favourite']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetAllChartsTitles => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Title']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetChartToZoom(string chartName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + chartName + "') and @content-desc='Title']/parent::*/parent::*/parent::*/descendant::*[@content-desc='zoomIcon']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> ChartPageTitle => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='PageTitleLabel']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetChartToRefresh(string chartName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + chartName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='RefreshBlock']"), iosLocator: MobileBy.XPath(""));
        }

        #endregion ChartsPage Elements

        #region ChartsPage Actions

        public string SelectChartToFavorite()
        {
            string favoritedChartName = string.Empty;
            IList<IWebElement> allCharts = GetAllChartsByFavoriteIcon;
            if (allCharts.Count > 0)
            {
                allCharts[0].Click();
                WaitForMoment(10);

                favoritedChartName = GetAllChartsTitles[0]?.Text;
            }
            else
            {
                Console.WriteLine($"No Chart found in the Charts Page to favorite.");
            }
            return favoritedChartName;
        }

        public void SelectChartToZoom(string chartName)
        {
            try
            {
                //IList<IWebElement> zoomButton = GetChartToZoom(chartName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetChartToZoom(chartName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetChartToZoom(chartName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{chartName} Chart is not available/configured to Zoom");
            }
        }

        public void VerifyChartPageTitle(string chartName)
        {
            try
            {
                WaitForMoment(2);
                Assert.IsTrue(ChartPageTitle.Count > 0);
                Assert.IsTrue(ChartPageTitle[0].Displayed);
                Assert.IsTrue(ChartPageTitle[0].Text.Equals(chartName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{chartName} Chart is not Zoomed in.");
            }
        }

        public void SelectChartToRefresh(string chartName)
        {
            try
            {
                //IList<IWebElement> refreshButton = GetChartToRefresh(chartName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetChartToRefresh(chartName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetChartToRefresh(chartName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{chartName} Chart is not available/configured to Zoom");
            }
        }

        #endregion ChartsPage Actions
    }
}
