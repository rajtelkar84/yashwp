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

        #endregion ChartsPage Elements

        #region ChartsPage Actions



        #endregion ChartsPage Actions
    }
}
