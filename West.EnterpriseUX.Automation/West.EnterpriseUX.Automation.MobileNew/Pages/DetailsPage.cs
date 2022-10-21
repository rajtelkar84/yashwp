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
    public class DetailsPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
        public SemanticPage _semanticPageInstance;

        public DetailsPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region DetailsPage Elements

        public IWebElement DetailsAbstractionTabTitle => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='DETAILS']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FirstWidgetTextValues => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='ExpandableListViewID']/android.widget.LinearLayout[1]/android.view.ViewGroup/android.widget.FrameLayout/android.view.ViewGroup/descendant::*[contains(@class, 'android.widget.TextView')]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> BlankViewGroup => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='ExpandableListViewID']/android.view.ViewGroup"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> LabelDropdownButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='parentInboxGridView']/descendant::android.widget.TextView/following-sibling::android.widget.ImageView"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> Label(string label)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + label + "']"), iosLocator: MobileBy.XPath(""));
        }

        #endregion DetailsPage Elements

        #region DetailsPage Actions

        public string GetFirstWidgetTextValues()
        {
            string allTextValues = "";

            if(FirstWidgetTextValues.Count > 0)
            {
                FirstWidgetTextValues[0].Click();
                WaitForMoment(2);

                foreach (IWebElement element in FirstWidgetTextValues)
                {
                    allTextValues = allTextValues + ", " + element.Text.Trim();
                }

                FirstWidgetTextValues[0].Click();
                WaitForMoment(2);

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

        public SemanticPage ClickOnViewDetails()
        {
            if (FirstWidgetTextValues.Count > 0)
            {
                foreach (IWebElement element in FirstWidgetTextValues)
                {
                    if(element.Text.Trim().Equals("View Details"))
                    {
                        element.Click();
                        _semanticPageInstance = new SemanticPage(_driver);
                        break;
                    }
                }
                return _semanticPageInstance;
            }
            return null;
        }

        public void NavigateToAllLables(ISet<string> allLables)
        {
            try
            {
                if (allLables.Count > 0)
                {
                    foreach (string label in allLables)
                    {
                        if(LabelDropdownButton[0].Displayed && LabelDropdownButton[0].Enabled)
                            LabelDropdownButton[0].Click();
                        else
                            Console.WriteLine("Label dropdown button is not displayed.");

                        var contexts = _driver.Contexts;
                        Console.WriteLine(contexts.Count);
                        Console.WriteLine(contexts[0].ToString());

                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

                        var labelText = Label(label)[0].Text;
                        var labelCount = Label(label).Count;

                        while (Label(label).Count == 0)
                        {
                            ScrollUpInLabelsDropdown();
                        }

                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                        Label(label)[0].Click();
                        WaitForMoment(20);
                    }
                }
                else
                {
                    Console.WriteLine("Labels are not displayed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail("Navigating to all the labels verification failed.");
            }
        }

        #endregion DetailsPage Actions
    }
}
