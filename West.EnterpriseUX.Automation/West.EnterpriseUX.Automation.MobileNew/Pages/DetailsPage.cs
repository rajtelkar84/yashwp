using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
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
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + label + "')]"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> CreateLabelButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Save_Container']/android.view.ViewGroup/android.view.ViewGroup[2]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> LabelNameTextBox => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Label Name']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> SaveButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='SAVE']"), iosLocator: MobileBy.XPath(""));

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

        public void ClickOnCreateLabelButton()
        {
            try
            {
                if (CreateLabelButton.Count > 0 && CreateLabelButton[0].Displayed && CreateLabelButton[0].Enabled)
                {
                    CreateLabelButton[0].Click();
                    WaitForMoment(2);
                }
                else
                {
                    Console.WriteLine("Save Label button is not present on Details page.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail("Save Label button is not present on Details page.");
            }
        }

        public void EnterLabelName(string labelName)
        {
            try
            {
                if (LabelNameTextBox.Count > 0 && LabelNameTextBox[0].Displayed && LabelNameTextBox[0].Enabled)
                {
                    new TouchAction(_driver).Tap(LabelNameTextBox[0]).Perform();
                    new Actions(_driver).SendKeys(labelName).Perform();
                    _driver.HideKeyboard();
                }
                else
                {
                    Console.WriteLine("Label Name text box is not present.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Assert.Fail("Label Name text box is not present.");
            }
        }

        #endregion DetailsPage Actions
    }
}
