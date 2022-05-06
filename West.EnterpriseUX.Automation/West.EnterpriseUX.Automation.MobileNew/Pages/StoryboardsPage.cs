using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;
using West.EnterpriseUX.Automation.MobileNew.Setup;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class StoryboardsPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public StoryboardsPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region StoryboardsPage Elements

        public IWebElement StoryboardsAbstractionTabTitle => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='STORYBOARDS']"), iosLocator: MobileBy.XPath(""));

        #endregion StoryboardsPage Elements

        #region StoryboardsPage Actions



        #endregion StoryboardsPage Actions
    }
}
