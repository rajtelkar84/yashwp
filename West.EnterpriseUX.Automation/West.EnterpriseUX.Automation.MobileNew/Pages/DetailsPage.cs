using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;
using West.EnterpriseUX.Automation.MobileNew.Setup;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class DetailsPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public DetailsPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region DetailsPage Elements

        public IWebElement DetailsAbstractionTabTitle => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='DETAILS']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FirstWidgetTextValues => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='ExpandableListViewID']/android.widget.LinearLayout[1]/android.view.ViewGroup/android.view.ViewGroup/descendant::*[contains(@class, 'android.widget.TextView')]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> BlankViewGroup => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='ExpandableListViewID']/android.view.ViewGroup"), iosLocator: MobileBy.XPath(""));
        
        #endregion DetailsPage Elements

        #region DetailsPage Actions

        public string GetFirstWidgetTextValues()
        {
            string allTextValues = "";

            if(FirstWidgetTextValues.Count > 0)
            {
                foreach(IWebElement element in FirstWidgetTextValues)
                {
                    allTextValues = allTextValues + ", " + element.Text.Trim();
                }
                return allTextValues;
            }
            return allTextValues;
        }

        public bool VerifyScrollingFunctionalityOnDetailsPage()
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (BlankViewGroup.Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                return BlankViewGroup[0].Displayed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return !BlankViewGroup[0].Displayed;
        }

        #endregion DetailsPage Actions
    }
}
