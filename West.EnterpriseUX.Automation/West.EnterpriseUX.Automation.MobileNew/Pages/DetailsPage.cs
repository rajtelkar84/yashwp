﻿using OpenQA.Selenium;
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

        #region InboxPage Elements

        public IList<IWebElement> FirstWidgetTextValues => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='ExpandableListViewID']/android.widget.LinearLayout[1]/android.view.ViewGroup/android.view.ViewGroup/descendant::*[contains(@class, 'android.widget.TextView')]"), iosLocator: MobileBy.XPath(""));

        #endregion

        #region InboxPage Actions

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

        #endregion
    }
}
