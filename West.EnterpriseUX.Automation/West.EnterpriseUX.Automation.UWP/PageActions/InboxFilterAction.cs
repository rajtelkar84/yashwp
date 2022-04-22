using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class InboxFilterAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly InboxFilterPage _pageInstance;

        public InboxFilterAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new InboxFilterPage(_session);
        }
        public void ClickOnAddFilterButton()
        {
            WaitForMoment(1);
            _pageInstance.AddFilterButton.Click();
        }
        public void SelectFilterFieldValueFromSearchField(string fieldValue, int filterNo)
        {
            int errorCount = 0;
            do
            {
                try
                {
                    _pageInstance.FilterFieldComboBoxesSearchField(filterNo).Clear();
                    char[] filterFieldValue = fieldValue.ToCharArray();
                    foreach (var eachValue in filterFieldValue)
                    {
                        _pageInstance.FilterFieldComboBoxesSearchField(filterNo).SendKeys(eachValue.ToString());
                    }
                    WaitForMoment(0.5);
                    WindowsElement fieldValueListItem = _pageInstance.SelectFilterFieldValue(fieldValue);
                    MouseClickOnWindowsElement(fieldValueListItem);
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    LogError($"Selecting Filter Field error: {ex.Message} : {ex.StackTrace}");
                    errorCount++;
                }
            } while (errorCount != 0 && errorCount < 3);
        }
        public void SelectOperatorValueFromSearchField(string operatorValue, int filterNo)
        {
            int errorCount = 0;
            do
            {
                try
                {
                    char[] filterFieldValue = operatorValue.ToCharArray();
                    foreach (var eachValue in filterFieldValue)
                    {
                        _pageInstance.OperatorComboBoxesSearchField(filterNo).SendKeys(operatorValue);
                    }
                    WaitForMoment(0.5);
                    WindowsElement fieldValueListItem = _pageInstance.SelectFilterFieldValue(operatorValue);
                    MouseClickOnWindowsElement(fieldValueListItem);
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    LogError($"Selecting Operator Value error: {ex.Message} : {ex.StackTrace}");
                    errorCount++;

                }
            } while (errorCount != 0 && errorCount < 3);

        }
        public void SelectFilterValue(string filterValue, int filterNo = 1)
        {
            int errorCount = 0;
            do
            {
                try
                {
                    _pageInstance.FilterValueDropdowns(filterNo).SendKeys(filterValue);
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    LogError($"Selecting Filter Value error: {ex.Message} : {ex.StackTrace}");
                    errorCount++;
                }
            } while (errorCount != 0 && errorCount < 3);
            if (errorCount == 3)
            {
                LogInfo($"Filter Value dropdown does not have column : {filterValue} to filter");
                Assert.Fail($"Filter Value dropdown does not have column : {filterValue} to filter");
            }
            WaitForMoment(0.1);
        }
        public void EnterFilterValue(string value, int filterNo = 1)
        {
            _mouseActions.SendKeys(Keys.Tab);
            _pageInstance.FilterValueEdits(filterNo).SendKeys(value);
        }
        public void ClickOnApplyButton()
        {
            WindowsElement filterApplyButton = _pageInstance.FilterApplyButton;
            ClickElement(filterApplyButton);
            WaitForLoadingToDisappear();
        }
        public void ClickOnApplyFilterButton()
        {
            WindowsElement filterApplyButton = _pageInstance.FilterApplyButton;
            ClickElement(filterApplyButton);
        }
        public void ClickOnClearAllButton()
        {
            IList<WindowsElement> deleteFilterOption = _pageInstance.DeleteFilterOption;
            if (deleteFilterOption.Count > 0)
            {
                WindowsElement ClearAllButton = _pageInstance.ClearAllButton;
                if (ClearAllButton.Enabled)
                {
                    ClearAllButton.Click();
                }
                else
                {
                    LogInfo("Clear All button is disabled.");
                    Assert.Fail("Clear All button is disabled.");
                }
            }
            else
            {
                LogInfo("Filter is not applied, so Clear All button is disabled.");
                Assert.Fail("Filter is not applied, so Clear All button is disabled.");
            }
        }
        public void ClickOnYes()
        {
            _pageInstance.ConfirmationYesButton.Click();
            WaitForMoment(0.3);
            WaitForLoadingToDisappear();
        }
        public void CloseFilterWindow()
        {
            IList<WindowsElement> filterWindowClosePopUp = _pageInstance.ClosePopup;
            MouseClickOnWindowsElement(filterWindowClosePopUp[0]);
            WaitForMoment(0.3);
        }
        public void ApplyFilter(string fieldValue, string operatorValue, string value, int filterNo = 1)
        {
            WaitForMoment(1);
            ClickOnAddFilterButton();
            WaitForMoment(1);
            SelectFilterFieldValueFromSearchField(fieldValue, filterNo);
            WaitForMoment(1);
            SelectOperatorValueFromSearchField(operatorValue, filterNo);
            WaitForMoment(1);
            if ((operatorValue.Trim().ToLower().Contains("equal") || operatorValue.ToLower().Contains("not equal")) && !value.ToLower().Equals("na") && !value.IsNumeric())
            {
                if (value.Trim().ToLower().Contains("all"))
                {
                    SelectAllFilterValues(filterNo);
                }
                else
                {
                    int errorCount = 0;
                    do
                    {
                        try
                        {
                            List<string> values = value.Split(',').ToList();
                            SelectFilterValue(values, filterNo);
                            errorCount = 0;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errorCount++;
                        }
                    } while (errorCount != 0 && errorCount < 3);
                }
            }
            else if ((operatorValue.Trim().ToLower().Contains("equal") || operatorValue.ToLower().Contains("not equal")) && value.IsNumeric())
            {
                EnterFilterValue(value, filterNo);
            }
            else if (operatorValue.Trim().ToLower().Contains("rolling date"))
            {
                SelectFilterValue(value, filterNo);
            }
            else if (operatorValue.Trim().ToLower().Contains("between") && !operatorValue.Trim().ToLower().Equals("dynamic between"))
            {
                SelectDateOperatorValue("between", value);
            }
            else if (operatorValue.Trim().ToLower().Contains("dynamic date"))
            {
                SelectDateOperatorValue("dynamic date", value);
            }
            else if (operatorValue.Trim().ToLower().Contains("dynamic between"))
            {
                SelectDateOperatorValue("dynamic between", value);
            }
            else
            {
                if (value.ToLower().Equals("na"))
                {
                    LogInfo("No need to select filter Value");
                }
                else
                {
                    EnterFilterValue(value, filterNo);
                }
            }
            ClickOnApplyButton();
            WaitForLoadingToDisappear();
        }
        public void SelectFilterValue(List<string> values, int filterNo)
        {
            //_pageInstance.FilterValueTextBoxes(filterNo).Click();
            if (values.Count > 1)
            {
                foreach (var value in values)
                {
                    WaitForMoment(2);
                    _pageInstance.PopUpFilterValueEdit.Clear();
                    WaitForMoment(0.5);
                    _pageInstance.PopUpFilterValueEdit.SendKeys(value);
                    WaitForMoment(0.5);
                    _pageInstance.PopUpFilterValueEdit.SendKeys(Keys.Enter);
                    WaitForMoment(4);
                    _pageInstance.PopUpFilteredValueCheckbox(value).Click();
                    WaitForMoment(0.5);
                    _pageInstance.PopUpFilterValueEdit.Click();
                }
            }
            else
            {
                WaitForMoment(2);
                _pageInstance.PopUpFilterValueEdit.Clear();
                WaitForMoment(0.5);
                _pageInstance.PopUpFilterValueEdit.SendKeys(values[0]);
                WaitForMoment(0.5);
                _pageInstance.PopUpFilterValueEdit.SendKeys(Keys.Enter);
                WaitForMoment(4);
                _pageInstance.PopUpFilteredValueCheckbox(values[0]).Click();
            }
            WaitForMoment(0.5);
            _pageInstance.PopUpApplyButton.Click();
        }
        public void SelectAllFilterValues(int filterNo)
        {
            int retryCount = 0;
            //MouseClickOnWindowsElement(_pageInstance.FilterValueTextBoxes(filterNo));
            WaitForMoment(1);
            OpenFilterValuePopup(filterNo);
            WaitForMoment(4);
            IList<WindowsElement> allFilterValueCheckboxes;
            do
            {
                allFilterValueCheckboxes = _pageInstance.AllFilterValueCheckboxes.Where(x => x.Text != "").ToList();
                if (allFilterValueCheckboxes.Count > 0)
                {
                    foreach (WindowsElement eachOption in allFilterValueCheckboxes)
                    {
                        WaitForMoment(0.5);
                        MouseClickOnWindowsElement(eachOption);
                    }
                }
                else
                {
                    WaitForMoment(0.5);
                    retryCount++;
                }
            } while (allFilterValueCheckboxes.Count == 0 && retryCount < 5);
            WaitForMoment(0.5);
            _pageInstance.PopUpApplyButton.Click();
        }
        public void SelectDateOperatorValue(string operatorValue, string value, int filterNo = 1)
        {
            switch (operatorValue)
            {
                case "between":
                    MouseClickOnWindowsElement(_pageInstance.FilterValueCalendarFrom(filterNo));
                    WaitForMoment(0.5);
                    _pageInstance.CalendarPreviousButton[0].Click();
                    WaitForMoment(0.5);
                    _pageInstance.CalendarDate.Click();
                    WaitForMoment(0.5);
                    break;
                case "dynamic date":
                    List<string> values = value.Split(',').ToList();
                    _pageInstance.DynamicDateFromFrequency.SendKeys(values[0]);
                    _pageInstance.DynamicDateToFrequency.SendKeys(values[1]);
                    break;
                case "dynamic between":
                    _pageInstance.DynamicBetweenFromField.SendKeys(value);
                    break;
                default:
                    Console.WriteLine("Operator Value field is not found for seelcting date filter");
                    break;
            }
        }
        public void VerifyAppliedFilterExists(string filterCondition = "Filter Condition", bool isPresent = false)
        {
            IList<WindowsElement> editableFilterRemoveButtons = _pageInstance.EditableFilterRemove;
            if (isPresent)
            {
                if (editableFilterRemoveButtons.Count > 0)
                {
                    LogInfo($"Filter condition {filterCondition} exists after apply operation.");
                }
                else
                {
                    LogInfo($"Filter condition {filterCondition} doesnt exists after apply operation.");
                    Assert.Fail($"Filter condition {filterCondition} doesnt exists after apply operation.");
                }
            }
            else
            {
                if (editableFilterRemoveButtons.Count > 0)
                {
                    LogInfo($"Filter condition {filterCondition} exists after reload/clear-all operation.");
                    Assert.Fail($"Filter condition {filterCondition} exists after reload/clear-all operation.");
                }
                else
                {
                    LogInfo($"Filter condition {filterCondition} is successfuly cleared after reload/clear-all operation.");
                }
            }
        }
        public void ClickOnEditFilterButton()
        {
            WaitForMoment(1);
            _pageInstance.EditFilterOption[0].Click();
        }
        public void GroupFilterConditions(int groupFilters = 2)
        {
            WaitForMoment(1);
            IList<WindowsElement> filterConditions = _pageInstance.FilterConditionsCheckbox;
            for (int i = 0; i < groupFilters; i++)
            {
                MouseClickOnWindowsElement(filterConditions[i]);
            }
        }
        public void ClickOnGroupFilterButton()
        {
            WaitForMoment(1);
            _pageInstance.GroupFilterButton.Click();
        }
        public void FilterConjunction(string filterJoiningOperator, int filterPosition = 1)
        {
            WaitForMoment(1);
            IList<WindowsElement> filterConditions = _pageInstance.FilterConjunction;
            filterConditions[filterPosition].Click();
            WaitForMoment(1);
            IList<WindowsElement> filterConjunction = _pageInstance.GetElementByText(filterJoiningOperator);
            if (filterConjunction.Count > 0)
            {
                MouseClickOnWindowsElement(filterConjunction[0]);
            }
            else
            {
                filterConjunction = _pageInstance.FilterConjunctions.Where(x => x.Text == filterJoiningOperator).ToList();
                MouseClickOnWindowsElement(filterConjunction[0]);
            }
        }
        public void VerifyDynamicBetweenDateFilter(string fieldValue, string operatorValue, int filterNo = 1)
        {
            //Add Date Filter 
            ClickOnAddFilterButton();
            SelectFilterFieldValueFromSearchField(fieldValue, filterNo);
            SelectOperatorValueFromSearchField(operatorValue, filterNo);

            String CurrentDate = DateTime.Now.ToString("M/d/yyyy");
            LogInfo($"Current date: " + CurrentDate);

            //Verify Dynamic between from date in Filter Value field
            if (_pageInstance.DynamicBetweenFromDate.Text.Equals(CurrentDate))
            {
                LogInfo($"Dynamic Between 'From' Date: {_pageInstance.DynamicBetweenFromDate.Text} matches Current Date: {CurrentDate} in Filter Value field");
            }
            else
            {
                Assert.Fail($"Dynamic Between From Date: {_pageInstance.DynamicBetweenFromDate.Text} does not match Current Date: {CurrentDate} in Filter Value field");
            }

            //Verify Dynamic between 'To' date in Filter Value field
            if (_pageInstance.DynamicBetweenToDate.Text.Equals(CurrentDate))
            {
                LogInfo($"Dynamic Between 'To' Date: {_pageInstance.DynamicBetweenToDate.Text} matches Current Date: {CurrentDate} in Filter Value field");
            }
            else
            {
                Assert.Fail($"Dynamic Between 'To' Date: {_pageInstance.DynamicBetweenToDate.Text} does not match Current Date: {CurrentDate} in Filter Value field");
            }

            _pageInstance.FromIncrementType.Click();
            WaitForMoment(1);
            _pageInstance.FromIncrementTypeMinus.Click();

            _pageInstance.FromIncrementByValue.Clear();
            _pageInstance.FromIncrementByValue.SendKeys("1");
            _pageInstance.FromIncrementByValue.SendKeys(Keys.Tab);
            _pageInstance.FromDateFrequency.SendKeys(Keys.ArrowDown);

            ClickOnApplyButton();
            WaitForLoadingToDisappear();
        }
        public void VerifyEmptyFilterPopUpTextInDetailsAbstraction(string expectedPopUpMessage)
        {
            IList<WindowsElement> popupmessagetext = _pageInstance.ConfirmationPopupTextPlaceholder;

            if (popupmessagetext.Count > 0)
            {
                LogInfo($"Popup appeared successfully after applying Empty Filter. Now checking text on pop-up");

                string actualPopUpMessage = popupmessagetext[0].Text;
                Assert.AreEqual(expectedPopUpMessage, actualPopUpMessage, "Pop Up message for empty filter condition is not matching");
            }
            else
            {
                Assert.Fail($"Pop-Up message is not displaying for empty filter condition");
            }
        }
        public void VerifyRecentFiltersTitle()
        {
            Assert.AreEqual(GetAttribute(_pageInstance.RecentFilters, "Name"), "Recent filters");
            LogInfo("Verified Recent filters Title");
        }
        public void VerifyRecentFiltersDisplayed()
        {
            try
            {
                WaitForMoment(3);
                Assert.IsTrue(_pageInstance.RecentFilterItems.Displayed); 
                LogInfo("On Clicking on Filter icon, Recent Filter diaplyed with Recently Applied Filter");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
        public void ClickOnRecentFilterIcon()
        {
            try
            {
                WaitForMoment(3);
                _pageInstance.EditableFilterImage.Click();
                LogInfo("Clicked On Edit Recent Filter");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        public void EditRecentFilter(string fieldValue, string operatorValue, string value, int filterNo = 1)
        {
            WaitForMoment(1);
            SelectFilterFieldValueFromSearchField(fieldValue, filterNo);
            WaitForMoment(1);
            SelectOperatorValueFromSearchField(operatorValue, filterNo);
            WaitForMoment(1);
            if ((operatorValue.Trim().ToLower().Contains("equal") || operatorValue.ToLower().Contains("not equal")) && !value.ToLower().Equals("na") && !value.IsNumeric())
            {
                if (value.Trim().ToLower().Contains("all"))
                {
                    SelectAllFilterValues(filterNo);
                }
                else
                {
                    int errorCount = 0;
                    do
                    {
                        try
                        {
                            List<string> values = value.Split(',').ToList();
                            SelectFilterValue(values, filterNo);
                            errorCount = 0;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errorCount++;
                        }
                    } while (errorCount != 0 && errorCount < 3);
                }
            }
            else if ((operatorValue.Trim().ToLower().Contains("equal") || operatorValue.ToLower().Contains("not equal")) && value.IsNumeric())
            {
                EnterFilterValue(value, filterNo);
            }
            else if (operatorValue.Trim().ToLower().Contains("rolling date"))
            {
                SelectFilterValue(value, filterNo);
            }
            else if (operatorValue.Trim().ToLower().Contains("between") && !operatorValue.Trim().ToLower().Equals("dynamic between"))
            {
                SelectDateOperatorValue("between", value);
            }
            else if (operatorValue.Trim().ToLower().Contains("dynamic date"))
            {
                SelectDateOperatorValue("dynamic date", value);
            }
            else if (operatorValue.Trim().ToLower().Contains("dynamic between"))
            {
                SelectDateOperatorValue("dynamic between", value);
            }
            else
            {
                if (value.ToLower().Equals("na"))
                {
                    LogInfo("No need to select filter Value");
                }
                else
                {
                    EnterFilterValue(value, filterNo);
                }
            }
            ClickOnApplyButton();
            LogInfo("Clicked on Apply Button after Edit Recent Filter");
            WaitForLoadingToDisappear();
        }
        public void VerifyActiveFiltersTitleAndActiveFiltersDisplayed()
        {
            try 
            {
                Assert.AreEqual(GetAttribute(_pageInstance.ActiveFilters, "Name"), "Active Filters");
                LogInfo("Verified Active Filters Title");
                WaitForMoment(3);
                Assert.IsTrue(_pageInstance.ActiveFilterView.Displayed);
                LogInfo("On Clicking on Filter icon, Active Filter diaplyed with Recently Applied Filter");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        #region New Filter Method

        public void ApplyFilterUpdated(string fieldValue, string operatorValue, string value, int filterNo = 1)
        {
            WaitForMoment(0.5);
            ClickOnAddFilterButton();
            WaitForMoment(0.5);
            SelectFilterFieldValueFromSearchFieldUpdated(fieldValue, filterNo);
            WaitForMoment(0.5);
            SelectOperatorValueFromSearchFieldUpdated(operatorValue, filterNo);
            WaitForMoment(0.5);
            if ((operatorValue.Trim().ToLower().Contains("equal") || operatorValue.ToLower().Contains("not equal")) && !value.ToLower().Equals("na") && !value.IsNumeric())
            {
                if (value.Trim().ToLower().Contains("all"))
                {
                    SelectAllFilterValues(filterNo);
                }
                else
                {
                    int errorCount = 0;
                    do
                    {
                        try
                        {
                            OpenFilterValuePopup(filterNo);
                            WaitForMoment(4);
                            List<string> values = value.Split(',').ToList();
                            SelectFilterValue(values, filterNo);
                            errorCount = 0;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            errorCount++;
                        }
                    } while (errorCount != 0 && errorCount < 3);
                }
            }
            else if ((operatorValue.Trim().ToLower().Contains("equal") || operatorValue.ToLower().Contains("not equal")) && value.IsNumeric())
            {
                EnterFilterValue(value, filterNo);
            }
            else if (operatorValue.Trim().ToLower().Contains("rolling date"))
            {
                SelectFilterValue(value, filterNo);
            }
            else if (operatorValue.Trim().ToLower().Contains("between") && !operatorValue.Trim().ToLower().Equals("dynamic between"))
            {
                SelectDateOperatorValue("between", value);
            }
            else if (operatorValue.Trim().ToLower().Contains("dynamic date"))
            {
                SelectDateOperatorValue("dynamic date", value);
            }
            else if (operatorValue.Trim().ToLower().Contains("dynamic between"))
            {
                SelectDateOperatorValue("dynamic between", value);
            }
            else
            {
                if (value.ToLower().Equals("na"))
                {
                    LogInfo("No need to select filter Value");
                }
                else
                {
                    EnterFilterValue(value, filterNo);
                }
            }
            ClickOnApplyButton();
            WaitForLoadingToDisappear();
        }
        public void SelectFilterFieldValueFromSearchFieldUpdated(string fieldValue, int filterNo)
        {
            int errorCount = 0;
            do
            {
                try
                {
                    WindowsElement filterfield = _pageInstance.FilterFieldComboBoxesSearchField(filterNo);
                    filterfield.SendKeys(fieldValue);
                    WaitForMoment(0.5);
                    MouseClickOnWindowsElement(filterfield);
                    WaitForMoment(0.5);
                    WindowsElement fieldValueListItem = _pageInstance.SelectFilterFieldValue(fieldValue);
                    MouseClickOnWindowsElement(fieldValueListItem);
                    break;
                }
                catch (Exception ex)
                {
                    LogError($"Selecting Filter Field error: {ex.Message} : {ex.StackTrace}");
                    errorCount++;
                }
            } while (errorCount < 2);
        }
        public void SelectOperatorValueFromSearchFieldUpdated(string operatorValue, int filterNo)
        {
            int errorCount = 0;
            do
            {
                try
                {
                    WindowsElement operatorfield = _pageInstance.OperatorComboBoxesSearchField(filterNo);
                    operatorfield.SendKeys(operatorValue);
                    WaitForMoment(0.5);
                    WindowsElement fieldValueListItem = _pageInstance.SelectFilterFieldValue(operatorValue);
                    MouseClickOnWindowsElement(fieldValueListItem);
                    break;
                }
                catch (Exception ex)
                {
                    LogError($"Selecting Operator Value error: {ex.Message} : {ex.StackTrace}");
                    errorCount++;

                }
            } while (errorCount < 2);

        }
        public void OpenFilterValuePopup(int filterNo=0)
        {
            IList<WindowsElement> filterValuePicker = _pageInstance.FilterValuePicker;
            if(filterValuePicker.Count>0)
            {
                filterValuePicker[filterNo-1].Click();
                WaitForMoment(1);
                IList<WindowsElement> filterValuePopup = _pageInstance.FilterValuePopUp;
                if(filterValuePopup.Count==0)
                {
                    MouseClickOnWindowsElement(filterValuePicker[filterNo-1]);
                }
            }
        }
        public void EditFiltervalue(string filterValue)
        {
            IList<WindowsElement> filterValuePicker = _pageInstance.EditFilterOption;
            filterValuePicker[0].Click();
            WaitForMoment(0.5);
            _pageInstance.FilterValuePickerIcon.Click();
            WaitForMoment(0.5);
            _pageInstance.PopUpFilterValueEdit.SendKeys(filterValue);
            WaitForMoment(0.5);
            _pageInstance.PopUpSearchButton.Click();
            WaitForMoment(0.5);
            _pageInstance.SelectCheckBox(filterValue).Click();
            WaitForMoment(0.5);
            _pageInstance.PopUpApplyButton.Click();
        
        }
        public void Filter(string fieldValue, string operatorValue,string filterValue,int filterNo =1)
        {
            try
            {
                WaitForMoment(1);
             //  ClickOnAddFilterButton();
                WaitForMoment(4);
                _pageInstance.AddFilterButton.Click();
                WaitForMoment(3);
                SelectFilterFieldValueFromSearchField(fieldValue, filterNo);
                WaitForMoment(1);
                SelectOperatorValueFromSearchField(operatorValue, filterNo);
                WaitForMoment(1);
               _pageInstance.FilterValuePickerIcon.Click();
                WaitForMoment(0.5);
                _pageInstance.PopUpFilterValueEdit.SendKeys(filterValue);
                WaitForMoment(0.5);
                _pageInstance.PopUpSearchButton.Click();
                WaitForMoment(0.5);
                _pageInstance.SelectCheckBox(filterValue).Click();
                WaitForMoment(0.5);
                _pageInstance.PopUpApplyButton.Click();
                ClickOnApplyButton();
                WaitForLoadingToDisappear();
            }
            catch (Exception ex)
            {
                LogError($"Add Filter is not working : {ex.Message} : {ex.StackTrace}");
            }

        }
        #endregion
    }
}

