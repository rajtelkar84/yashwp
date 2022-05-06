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

        #endregion KpisPage Elements

        #region KpisPage Actions



        #endregion KpisPage Actions
    }
}
