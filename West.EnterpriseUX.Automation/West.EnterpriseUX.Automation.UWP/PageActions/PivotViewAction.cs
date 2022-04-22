using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class PivotViewAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly PivotViewPage _pageInstance;

        public PivotViewAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new PivotViewPage(_session);
        }
        public void SelectMeasures(string measureValue)
        {
            WaitForMoment(1);
            char[] values = measureValue.ToCharArray();
            foreach (var eachCharacter in values)
            {
                _pageInstance.MeasureField.SendKeys(eachCharacter.ToString());
            }
            WaitForMoment(0.5);
            WindowsElement fieldValueListItem = _pageInstance.SelectFieldValue(measureValue);
            MouseClickOnWindowsElement(fieldValueListItem);
        }
        public void SelectDimension(string dimensionValue)
        {
            WaitForMoment(1);
            char[] values = dimensionValue.ToCharArray();
            foreach (var eachCharacter in values)
            {
                _pageInstance.DiemensionField.SendKeys(eachCharacter.ToString());
            }
            WaitForMoment(0.5);
            WindowsElement fieldValueListItem = _pageInstance.SelectFieldValue(dimensionValue);
            MouseClickOnWindowsElement(fieldValueListItem);
        }
        public void ClickOnGenerate()
        {
            _pageInstance.GenerateButton.Click();
            WaitForLoadingToDisappear();
        }
        public void ClickOnCreatePivotView()
        {
            _pageInstance.CreatePivotButton.Click();
        }

        public void SelectPivotDimensions(string dimensionsValue)
        {
            _pageInstance.PivotDimensionFieldComboBox.Click();
            _pageInstance.PivotDimensionFieldComboBox.Clear();
            char[] filterFieldValue = dimensionsValue.ToCharArray();
            foreach (var eachValue in filterFieldValue)
            {
                _pageInstance.PivotDimensionFieldComboBox.SendKeys(eachValue.ToString());
            }
            WindowsElement expectedValue = _pageInstance.SelectDropdownValue(dimensionsValue);
            MouseClickOnWindowsElement(expectedValue);
        }
        public void SelectPivotMeasures(string measureValue)
        {
            _pageInstance.PivotMeasureFieldComboBox.Click();
            _pageInstance.PivotMeasureFieldComboBox.Clear();
            char[] filterFieldValue = measureValue.ToCharArray();
            foreach (var eachValue in filterFieldValue)
            {
                _pageInstance.PivotMeasureFieldComboBox.SendKeys(eachValue.ToString());
            }
            WindowsElement expectedValue = _pageInstance.SelectDropdownValue(measureValue);
            MouseClickOnWindowsElement(expectedValue);
        }

        public void VerifyContentsOnPivotPage()
        {
            try
            {
                Assert.AreEqual(GetAttribute(_pageInstance.PivotTitle, "Name"), "Pivot");
                LogInfo("Verified Pivot Title");
                Assert.AreEqual(GetAttribute(_pageInstance.GlobalPivotTabTitle, "Name"), "Global");
                LogInfo("Verified Global Pivot Tab Title");
                Assert.AreEqual(GetAttribute(_pageInstance.CreatedByMePivotTabTitle, "Name"), "Created by me");
                LogInfo("Verified Created By Me Pivot Tab Title");
                Assert.IsTrue(_pageInstance.NoPivotAvailableOnPage.Displayed, "'No Pivot View Available' not displayed on page");
                WaitForMoment(2);
                _pageInstance.CreateButton.Click();
                LogInfo("Clicked on Create Button on Pivot Page");
                Assert.IsTrue(_pageInstance.TitleOfPivot.Displayed, "Title of Pivot not displayed");
                Assert.IsTrue(_pageInstance.DescriptionInPivot.Displayed, "Description In Pivot not displayed");
                Assert.IsTrue(_pageInstance.DimensionInPivot.Displayed, "Dimension In Pivot not displayed");
                Assert.IsTrue(_pageInstance.MeasureInPivot.Displayed, "Measure In Pivot not displayed");
                Assert.IsTrue(_pageInstance.GenerateButtonInPivot.Displayed, "Generate Button In Pivot not displayed");
                Assert.IsTrue(_pageInstance.DownloadButtonInPivot.Displayed, "Download Button In Pivot not displayed");
                Assert.IsTrue(_pageInstance.SaveButtonInPivot.Displayed, "Save Button In Pivot not displayed");
                Assert.IsTrue(_pageInstance.CloseButtonInPivot.Displayed, "Close Button In Pivot not displayed");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        public void ClickPivotCreateButton()
        {
            _pageInstance.CreateButton.Click();
            LogInfo("Clicked on Pivot Create Button ");
        }
        public void EnterPivotDescription(string pivotDescription)
        {
            _pageInstance.PivotDescriptionTextField.Clear();
            _pageInstance.PivotDescriptionTextField.SendKeys(pivotDescription);
            LogInfo("Entered Description in Description Text Field ");
        }
        public void ClickOnPivotGenerateButton()
        {
            _pageInstance.GenerateButtonInPivot.Click();
            LogInfo("Clicked on Pivot Generate Button");
            WaitForMoment(3);
            WaitForLoadingToDisappear();
        }
        public void ClickOnPivotSaveButton()
        {
            _pageInstance.SaveButtonInPivot.Click();
            LogInfo("Clicked on Pivot Save Button");
            WaitForLoadingToDisappear();
        }
        public void ClickOnPivotGlobalTab()
        {
            _pageInstance.GlobalTab.Click();
            LogInfo("Clicked on Pivot Global Tab");
        }
        public void ClickOnPivotSharedWithMeTab()
        {
            _pageInstance.SharedWithMeTabInPivot.Click();
            LogInfo("Clicked on Pivot Shared with Me Tab");
        }
        public void ClickOnPivotCreatedByMeTab()
        {
            _pageInstance.CreatedByMeTabInPivot.Click();
            LogInfo("Clicked on Pivot Created by Me Tab");
        }
        public void VerifyGlobalPivotTabTitle()
        {
            Assert.AreEqual(GetAttribute(_pageInstance.GlobalPivotTabTitle, "Name"), "Global");
            LogInfo("Verified Global Pivot Tab Title");
        }
        public void VerifyCreatedByMePivotTabTitle()
        {
            Assert.AreEqual(GetAttribute(_pageInstance.CreatedByMePivotTabTitle, "Name"), "Created by me");
            LogInfo("Verified Created by me Pivot Tab Title");
        }
        public void VerifySharedWithMePivotTabTitle()
        {
            Assert.AreEqual(GetAttribute(_pageInstance.SharedWithMePivotTabTitle, "Name"), "Shared with me");
            LogInfo("Verified Shared with me Pivot Tab Title");
        }
        public void VerifyPivotPresentOnCretedByMeTab(string pivotName)
        {
            if (_pageInstance.CreatedByMeTabInPivot.Displayed && _pageInstance.CreatedByMeTabInPivot.Enabled)
            {
                _pageInstance.CreatedByMeTabInPivot.Click();
            }
            else
            {
                LogInfo($"Created by me tab in Pivot is not present ");
            }

            IList<WindowsElement> pivotCount = _pageInstance.GetElementByText(pivotName);
            if (pivotCount.Count > 0)
            {
                LogInfo($"Pivot :{pivotName} is present in the Created by me page");
            }
            else
            {
                LogInfo($"Pivot :{pivotName} is not present in the Created by me page");
            }
        }

        public void DeleteUserCreatedPivot()
        {
            int totalDeleteCount = 0;
            WaitForMoment(1);
            IList<WindowsElement> pivotTotalData = _pageInstance.UserCreatedPivot;
            IList<WindowsElement> pivotDisplayedData = _pageInstance.UserCreatedPivot.Where(d => d.Displayed.Equals(true)).ToList();
            try
            {
                do
                {
                    if (pivotDisplayedData.Count == 0 && pivotTotalData.Count > pivotDisplayedData.Count)
                    {
                        ScrollTillEnd();
                        pivotDisplayedData = _pageInstance.UserCreatedPivot.Where(d => d.Displayed.Equals(true)).ToList();
                    }

                    if (pivotDisplayedData.Count > 0 && pivotDisplayedData[0].Displayed)
                    {
                        WaitForMoment(1);
                        IList<WindowsElement> deleteOption = _pageInstance.DeleteButtonInPivot;
                        WaitForMoment(1);
                        if (deleteOption.Count > 0)
                        {
                            deleteOption[0].Click();
                            WaitForMoment(1);
                            WindowsElement confirmationYesButton = _pageInstance.ConfirmationYesButtonPivot;
                            MouseClickOnWindowsElement(confirmationYesButton);
                            WaitForMoment(1);
                            WaitForLoadingToDisappear(LoadingText.Removing.ToString());
                            totalDeleteCount++;
                        }
                    }
                    pivotDisplayedData = _pageInstance.UserCreatedPivot.Where(d => d.Displayed.Equals(true)).ToList();

                } while (pivotDisplayedData.Count != 0 && totalDeleteCount <= 10);

                LogInfo($"Total Deleted Pivot : {totalDeleteCount}");
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }
        public void ClickOnAddPivotImage()
        {
            WaitForMoment(2);
            _pageInstance.AddPivotImage.Click();
        }
        public void ClickEditButtonOnPivot()
        {
            WaitForMoment(2);
            _pageInstance.EditButtonInPivot.Click();
        }
        public void ClearPivotDimension()
        {
            WaitForMoment(2);
            _pageInstance.ClearPivotDimension.Click();
        }
        public void ClearPivotMeasure()
        {
            WaitForMoment(2);
            _pageInstance.ClearPivotMeasure.Click();
        }
        public void ClickDeleteButtonOnPivot()
        {
            WaitForMoment(2);
            _pageInstance.DeleteImageInPivot.Click();
            WaitForMoment(2);
            _pageInstance.ConfirmationYesButtonPivot.Click();
            WaitForMoment(2);
        }
        public void SearchAndVerifyPivotWithContains(string containsValue)
        {
            WaitForMoment(3);
            ClickOnSearchPicker();
            _pageInstance.ContainsSearchButton.Click();
            _pageInstance.SearchBox.SendKeys(containsValue);
            _pageInstance.SearchButton.Click();
            WaitForMoment(5);
            int maxNumber = GetSearchRangeMaximumNumber();
            int randomNumber = GenerateRandomNumber(maxNumber);
            VerifyRandomSearchedRecordForContains(randomNumber, containsValue);
            ClearSearchBox();
        }

        public void SearchAndVerifyPivotWithStartsWith(string startsWithValue)
        {
            WaitForMoment(3);
            ClickOnSearchPicker();
            _pageInstance.StartsWithSearchButton.Click();
            _pageInstance.SearchBox.SendKeys(startsWithValue);
            _pageInstance.SearchButton.Click();
            WaitForMoment(5);
            int maxNumber = GetSearchRangeMaximumNumber();
            int randomNumber = GenerateRandomNumber(maxNumber);
            VerifyRandomSearchedRecordForStartsWith(randomNumber, startsWithValue);
            ClearSearchBox();
        }

        public void SearchAndVerifyPivotWithEndsWith(string endsWithValue)
        {
            WaitForMoment(3);
            ClickOnSearchPicker();
            _pageInstance.EndsWithSearchButton.Click();
            _pageInstance.SearchBox.SendKeys(endsWithValue);
            _pageInstance.SearchButton.Click();
            WaitForMoment(5);
            int maxNumber = GetSearchRangeMaximumNumber();
            int randomNumber = GenerateRandomNumber(maxNumber);
            VerifyRandomSearchedRecordForEndsWith(randomNumber, endsWithValue);
            ClearSearchBox();
        }

        public void VerifyRandomSearchedRecordForContains(int randomNumber, string filterValue)
        {
            string recordText = (GetAttribute(_pageInstance.SelectRandomPivotRecord(randomNumber), "Name"));
            bool isRecordContainsFilteredValue = recordText.ToLower().Contains(filterValue);
            Assert.IsTrue(isRecordContainsFilteredValue);
            LogInfo("Verified random search record for contains filter.");
        }
        
        public void VerifyRandomSearchedRecordForStartsWith(int randomNumber, string filterValue)
        {
            string recordText = (GetAttribute(_pageInstance.SelectRandomPivotRecord(randomNumber), "Name"));
            bool isRecordStartsWithFilteredValue = recordText.ToLower().StartsWith(filterValue);
            Assert.IsTrue(isRecordStartsWithFilteredValue);
            LogInfo("Verified random search record for starts with filter.");
        }

        public void VerifyRandomSearchedRecordForEndsWith(int randomNumber, string filterValue)
        {
            string recordText = (GetAttribute(_pageInstance.SelectRandomPivotRecord(randomNumber), "Name"));
            bool isRecordEndsWithFilteredValue = recordText.ToLower().EndsWith(filterValue);
            Assert.IsTrue(isRecordEndsWithFilteredValue);
            LogInfo("Verified random search record for ends with filter.");
        }

        public int GetSearchRangeMaximumNumber()
        {
            string searchRangeText = (GetAttribute(_pageInstance.NoOfSearches, "Name"));
            char maxNumberChar = searchRangeText[searchRangeText.Length - 1];
            int maxNumber = maxNumberChar - '0';

            if (maxNumber == 0 || maxNumber == 1)
                return 1;

            return maxNumberChar - '0';
        }

        public int GenerateRandomNumber(int maxNumber)
        {
            Random random = new Random();
            return random.Next(1, maxNumber);
        }

        public void ClearSearchBox()
        {
            _pageInstance.CrossIcon.Click();
        }

        public void ClickOnSearchPicker()
        {
            _pageInstance.SearchPicker.Click();
        }

        public void ValidatePivotMandatoryFields(string pivotTitle, string measure)
        {
            WaitForMoment(1);
            ClickOnPivotSaveButton();
            string actualErrorMessage1 = (GetAttribute(_pageInstance.DialogMessage, "Name"));
            string expectedErrorMessage1 = "Please enter Pivot name";
            Assert.AreEqual(expectedErrorMessage1, actualErrorMessage1);
            _pageInstance.OkButton.Click();

            WaitForMoment(1);
            _pageInstance.PivotTitleTextBox.SendKeys(pivotTitle);
            ClickOnPivotSaveButton();
            string actualErrorMessage2 = (GetAttribute(_pageInstance.DialogMessage, "Name"));
            string expectedErrorMessage2 = "Please select Measure";
            Assert.AreEqual(expectedErrorMessage2, actualErrorMessage2);
            _pageInstance.OkButton.Click();

            WaitForMoment(1);
            SelectPivotMeasures(measure);
            ClickOnPivotSaveButton();
            string actualErrorMessage3 = (GetAttribute(_pageInstance.DialogMessage, "Name"));
            string expectedErrorMessage3 = "Please select Dimension";
            Assert.AreEqual(expectedErrorMessage3, actualErrorMessage3);
            _pageInstance.OkButton.Click();
        }

        public void ValidateAggregateTypeButton()
        {
            string expectedOptions = "Count, Sum, Average, Max, Min";
            _pageInstance.AggregateTypePicker.Click();
            string[] aggregateTypeOptions = GetAggregateTypeOptions();
            bool areAllAggregateOptionsPresent = false;

            foreach (string aggregateTypeOption in aggregateTypeOptions)
            {
                if (expectedOptions.Contains(aggregateTypeOption.Trim()))
                    areAllAggregateOptionsPresent = true;
                else
                {
                    areAllAggregateOptionsPresent = false;
                    break;
                }
            }

            Assert.IsTrue(areAllAggregateOptionsPresent);
        }

        public string[] GetAggregateTypeOptions()
        {
            IList<WindowsElement> aggregateOptionList = _pageInstance.AggregateTypeOptions;
            string[] aggregateOptionArray = new string[aggregateOptionList.Count];
            int index = 0;

            foreach (WindowsElement aggregateOption in aggregateOptionList)
            {
                aggregateOptionArray[index++] = GetAttribute(aggregateOption, "Name");
            }

            return aggregateOptionArray;
        }
    }
}
