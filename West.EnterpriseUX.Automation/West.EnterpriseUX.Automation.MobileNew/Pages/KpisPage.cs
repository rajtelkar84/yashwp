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
        public IList<IWebElement> KpiPageTitle => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='PageTitleLabel']"), iosLocator: MobileBy.XPath(""));

        #endregion KpisPage Elements

        #region KpisPage Actions

        public void SelectKPIToZoom(string kpiName)
        {
            try
            {
                IList<IWebElement> kpiToZoon = GetKPIToZoom(kpiName);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (kpiToZoon.Count == 0)
                {
                    ScrollDown();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                kpiToZoon[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{kpiName} KPI is not available/configured to Zoom");
            }
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

        #endregion KpisPage Actions
    }
}
