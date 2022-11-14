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
    public class FilterPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public FilterPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region FilterPage Elements

        public IList<IWebElement> AddFilterButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='+ ADD NEW CONDITION']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterField => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='FilterFieldPicker Input Field']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterFieldViewGroup => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='FilterFieldPicker_Container']/parent::*/following-sibling::android.view.ViewGroup"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterOperator => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Select Filter Operator']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> OperatorPicker => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@resource-id='android:id/numberpicker_input']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterValueTextBox => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Editor']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> DeleteFilter => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='DeleteFilterImage']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterJoinCheckBox => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='DeleteFilterImage']/preceding-sibling::*/child::android.widget.CheckBox"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterJoinField => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='DeleteFilterImage']/following-sibling::*/child::android.widget.Button"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterJoinCondition(string condition)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='" + condition + "']"), iosLocator: MobileBy.XPath(""));
        }
        public IWebElement SelectFilterField(string value)
        {
            return WaitAndFindElement(androidLocator: MobileBy.XPath("//*[contains(@text,'" + value + "')]"), iosLocator: MobileBy.XPath(""));
        }
        public IWebElement SelectOperator(string value)
        {
            return WaitAndFindElement(androidLocator: MobileBy.XPath("//*[contains(@text,'" + value + "')]"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> OkButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='OK']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ApplyFilterButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='APPLY']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ClearAllButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='CLEAR ALL']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ActiveFiltersTexts => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='ActiveFilters']/descendant::android.widget.TextView"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ConfirmButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='YES']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> DenyButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='NO']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterCheckBoxes => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='FilterConditions']/descendant::android.widget.CheckBox"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterGroupButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='FilterConditions']/descendant::*[@text='GROUP']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterGroupIdTexts => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='FilterConditions']/descendant::android.widget.TextView"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> FilterConjunctionButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='and. ']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> SelectFilterConjunction(string value)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text,'" + value + "')]"), iosLocator: MobileBy.XPath(""));
        }



        #endregion FilterPage Elements

        #region FilterPage Actions

        public void ClickOnAddFilter()
        {
            try
            {
                bool isAddFilterDisplayed = AddFilterButton[0].Displayed;

                if (!isAddFilterDisplayed)
                {
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                    while (AddFilterButton.Count == 0)
                    {
                        ScrollUp();
                    }
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    AddFilterButton[0].Click();

                    WaitForMoment(1);
                }
                else
                    AddFilterButton[0].Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SelectFilterFieldValue(string fieldValue, int filterNo)
        {
            int errorCount = 0;
            do
            {
                try
                {
                    bool isFilterFieldDisplayed = FilterField[filterNo - 1].Displayed;

                    if (!isFilterFieldDisplayed)
                    {
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                        while (FilterField.Count == 0)
                        {
                            ScrollUp();
                        }
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                        FilterField[filterNo - 1].Click();
                        FilterField[filterNo - 1].Clear();
                    }
                    else
                    {
                        FilterField[filterNo - 1].Click();
                        FilterField[filterNo - 1].Clear();
                    }

                    WaitForMoment(0.5);
                    FilterField[filterNo - 1].SendKeys(fieldValue);
                    WaitForMoment(0.5);
                    _driver.HideKeyboard();
                    WaitForMoment(1);
                    IWebElement fieldValueElement = SelectFilterField(fieldValue);
                    new TouchAction(_driver).Tap(fieldValueElement).Perform();
                    new Actions(_driver).SendKeys(Keys.Enter).Perform();
                    WaitForMoment(2);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    errorCount++;
                }
            } while (errorCount < 2);
        }

        public void SelectOperatorValue(string operatorValue, int filterNo)
        {
            int errorCount = 0;
            do
            {
                try
                {
                    bool isOperatorDisplayed = FilterOperator[filterNo - 1].Displayed;

                    if (!isOperatorDisplayed)
                    {
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                        while (FilterOperator.Count == 0)
                        {
                            ScrollUp();
                        }
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                        FilterOperator[filterNo - 1].Click();
                        FilterOperator[filterNo - 1].Clear();
                    }
                    else
                    {
                        FilterOperator[filterNo - 1].Click();
                        FilterOperator[filterNo - 1].Clear();
                    }

                    WaitForMoment(0.5);
                    FilterOperator[filterNo - 1].SendKeys(operatorValue);
                    WaitForMoment(0.5);
                    _driver.HideKeyboard();
                    WaitForMoment(1);
                    IWebElement OperatorElement = SelectOperator(operatorValue);
                    new TouchAction(_driver).Tap(OperatorElement).Perform();
                    new Actions(_driver).SendKeys(Keys.Enter).Perform();
                    WaitForMoment(2);
                    break;

                    /*
                    if (!OperatorPicker[0].Text.Equals(operatorValue))
                    {
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                        while (!OperatorPicker[0].Text.Equals(operatorValue))
                        {
                            ScrollUpInFilterOpratorPicker();
                        }
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                        OperatorPicker[0].Click();
                        OkButton[0].Click();
                        break;
                    }
                    else
                    {
                        OkButton[0].Click();
                        break;
                    }
                    */
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    errorCount++;
                }
            } while (errorCount < 2);
        }

        public void EnterFilterValue(string filterValue, int filterNo)
        {
            int errorCount = 0;
            do
            {
                try
                {
                    bool isFilterValueTextBoxDisplayed = FilterValueTextBox[filterNo - 1].Displayed;

                    if (!isFilterValueTextBoxDisplayed)
                    {
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                        while (FilterValueTextBox.Count == 0)
                        {
                            ScrollUp();
                        }
                        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                        FilterValueTextBox[filterNo - 1].Click();
                    }
                    else
                    {
                        FilterValueTextBox[filterNo - 1].Click();
                    }
                        
                    WaitForMoment(0.5);
                    FilterValueTextBox[filterNo - 1].Clear();
                    WaitForMoment(0.5);
                    FilterValueTextBox[filterNo - 1].SendKeys(filterValue);
                    WaitForMoment(0.5);
                    _driver.HideKeyboard();
                    WaitForMoment(2);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    errorCount++;
                }
            } while (errorCount < 2);
        }

        public void ClickOnApplyFilter()
        {
            try
            {
                if (ApplyFilterButton[0].Displayed && ApplyFilterButton[0].Enabled)
                {
                    ApplyFilterButton[0].Click();
                }
                else
                    Console.WriteLine("Apply button is not diaplyed/enabled");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public bool IsFilterPresentInActiveFilters(string filterField, string operatorValue, string filterValue)
        {
            bool isFilterPresentInActiveFilters = false;

            try
            {
                if (ActiveFiltersTexts.Count > 0)
                {
                    IList<string> activeFiltersTexts = new List<string>();

                    foreach (IWebElement element in ActiveFiltersTexts)
                    {
                        activeFiltersTexts.Add(element.Text);
                    }

                    if (activeFiltersTexts.Contains(filterField) && activeFiltersTexts.Contains(operatorValue) && activeFiltersTexts.Contains(filterValue))
                    {
                        isFilterPresentInActiveFilters = true;
                        return isFilterPresentInActiveFilters;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return isFilterPresentInActiveFilters;
        }

        public void ClickOnClearAll()
        {
            try
            {
                if (ClearAllButton[0].Displayed && ClearAllButton[0].Enabled)
                {
                    ClearAllButton[0].Click();
                    WaitForMoment(0.5);

                    if(ConfirmButton[0].Displayed && ConfirmButton[0].Enabled)
                    {
                        ConfirmButton[0].Click();
                        WaitForMoment(0.5);
                    }
                    else
                        Console.WriteLine("Confirmation popup is not diaplyed");
                }
                else
                    Console.WriteLine("Clear All button is not diaplyed/enabled");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FilterConjunction(string conjuction)
        {
            try
            {
                WaitForMoment(1);
                if(FilterConjunctionButton.Count > 0)
                {
                    FilterConjunctionButton[0].Click();
                    WaitForMoment(1);

                    IList<IWebElement> filterConjunction = SelectFilterConjunction(conjuction);
                    if (filterConjunction.Count > 0)
                    {
                        filterConjunction[0].Click();
                    }
                    else
                    {
                        Assert.Fail("Filter conjunction option " + conjuction + "  is not present.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail("Filter conjunction button is not present.");
            }
        }

        public void GroupFilterConditions(int groupFilters)
        {
            try
            {
                WaitForMoment(1);
                for (int i = 0; i < groupFilters; i++)
                {
                    FilterCheckBoxes[i].Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail("Filter grouping checkboxes are not present.");
            }
        }

        public void ClickOnGroupFilterButton()
        {
            try
            {
                WaitForMoment(1);
                FilterGroupButton[0].Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail("Filter group button is not present.");
            }
        }

        #endregion FilterPage Actions
    }
}
