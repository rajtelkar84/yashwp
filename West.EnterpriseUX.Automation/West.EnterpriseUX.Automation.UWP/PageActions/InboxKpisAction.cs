using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class InboxKpisAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly InboxKpisPage _pageInstance;
        private object _inboxKpisAction;
        private InboxChartsAction _inboxChartsAction;
        private InboxAction _inboxAction;

        public InboxKpisAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new InboxKpisPage(_session);
            _inboxChartsAction = new InboxChartsAction(_session);
            _inboxAction = new InboxAction(_session);
        }
        public void SelectKPIToZoom(string kPIName)
        {
            ScrollToElement(kPIName);
            IList<WindowsElement> kPI = _pageInstance.GetKPIToZoom(kPIName);
            if (kPI != null & kPI.Count > 0)
            {
                MouseClickOnWindowsElement(kPI[0]);
            }
            else
            {
                LogInfo($"{kPIName} KPI is not available/configured to Zoom");
                Assert.Fail($"{kPIName} KPI is not available/configured to Zoom");
            }
        }
        public void NavigateToDetailsFromKPI(string kPIName)
        {
            IList<WindowsElement> allKPIs = _pageInstance.GetKPIByLabelName(kPIName);
            if (allKPIs.Count > 0)
            {
                allKPIs[0].Click();
                WaitForLoadingToDisappear();
            }
            else
            {
                LogInfo($"KPI Name:{kPIName} is not found in the KPI Page.");
            }
        }
        public string SelectKPIToFavorite(string kPIName)
        {
            string favoritedKPIName = string.Empty;
            WaitForLoadingToDisappear();
            if (String.IsNullOrEmpty(kPIName))
            {
                favoritedKPIName = SelectKPIToFavorite();
            }
            else
            {
                IList<WindowsElement> kPI = _pageInstance.GetKPIToFavorite(kPIName);
                WaitForMoment(2);
                if (kPI != null)
                {
                    MouseClickOnWindowsElement(kPI[0]);
                    favoritedKPIName = kPIName;
                }
                else
                {
                    LogInfo($"{kPIName} KPI is not available/configured to Favorite");
                    Assert.Fail($"{kPIName} KPI is not available/configured to Favorite");
                }
            }
            WaitForLoadingToDisappear(LoadingText.Adding.ToString());
            return favoritedKPIName;
        }
        public string SelectKPIToFavorite()
        {
            string favoritedKPIName = string.Empty;
            IList<WindowsElement> allKPIs = _pageInstance.GetAllChartsKPIsByFavoriteIcon;
            if (allKPIs.Count > 0)
            {
                MouseClickOnWindowsElement(allKPIs[0]);
                WaitForLoadingToDisappear(LoadingText.Adding.ToString());
                var allKPITitles = _pageInstance.GetAllChartsKPIsTitles;
                favoritedKPIName = allKPITitles[0]?.Text;
            }
            else
            {
                LogInfo($"No KPIs found in the KPIs Page to favorite.");
            }
            return favoritedKPIName;
        }
        public void VerifyKPIName(string kPIName)
        {
            WindowsElement kPITitle = _pageInstance.GetKPIHeaderName(kPIName);
            Assert.AreEqual(kPIName, kPITitle.Text, $"KPI Name after zoom {kPITitle.Text} is not as expected value {kPIName}");
        }
        public void ClickOnMoreOption(string option= "More")
        {
            IList<WindowsElement> moreOption = _pageInstance.GetElementByText(option);
            if (moreOption.Count > 0)
            {
                MouseClickOnWindowsElement(moreOption[0]);
            }
        }
        public void ClickOnAdvanceFilterByKPI(string kPIName)
        {
            IList<WindowsElement> advanceFilterImage = _pageInstance.GetAdvanceFilterByKPIName(kPIName);
            if (advanceFilterImage != null)
            {
                MouseClickOnWindowsElement(advanceFilterImage[0]);
            }
            else
            {
                LogInfo($"{kPIName} KPI is not available/configured to Micro filter");
                Assert.Fail($"{kPIName} KPI is not available/configured to Micro filter");
            }
        }
        public void ClickOnEditImageByKPIName(string kPIName)
        {
            WindowsElement kpiEditImage = _pageInstance.GetEditImageByKPIName(kPIName);
            MouseClickOnWindowsElement(kpiEditImage);
            WaitForMoment(1);
            IList<WindowsElement> editOption = _pageInstance.GetElementByText(KPIChartsContextOptions.Edit.ToString());
            if (editOption.Count > 0)
            {
                MouseClickOnWindowsElement(editOption[0]);
            }
        }
        public void ClickOnSaveButton()
        {
            //MouseClickOnWindowsElement(_pageInstance.KPIConfigSaveButton);
            _pageInstance.KPIConfigSaveButton.Click();
            LogInfo("Clicked on Save KPI Button");
            WaitForMoment(2);
            WaitForLoadingToDisappear();
        }
        public void EnterKPIValueTitle(string kpiTitle)
        {
            WindowsElement kpiTitleTextField = _pageInstance.KPIValueTextField;
            kpiTitleTextField.Clear();
            kpiTitleTextField.SendKeys(kpiTitle);
        }
        public void SelectAggregationType(string aggregationType)
        {
            WindowsElement aggregateType = _pageInstance.SelectAggregationTypeForKPIValues(aggregationType);
            MouseClickOnWindowsElement(aggregateType);
        }
        public void SelectMeasureValue(string measureValue)
        {
            WindowsElement measureFieldCombox = _pageInstance.MeasureFieldCombobox();
            MouseClickOnWindowsElement(measureFieldCombox);
            measureFieldCombox.SendKeys(measureValue);
            measureFieldCombox.SendKeys("{Enter}");
            WindowsElement fieldValueListItem = _pageInstance.SelectPropertyValue(measureValue);
            MouseClickOnWindowsElement(fieldValueListItem);
        }
        public void SelectDimensionValue(string dimensionValue)
        {
            WindowsElement dimensionFieldCombox = _pageInstance.DimensionFieldCombobox();
            MouseClickOnWindowsElement(dimensionFieldCombox);
            dimensionFieldCombox.SendKeys(dimensionValue);
            dimensionFieldCombox.SendKeys("{Enter}");
            WindowsElement fieldValueListItem = _pageInstance.SelectPropertyValue(dimensionValue);
            MouseClickOnWindowsElement(fieldValueListItem);
        }
        public void SelectPropertyValue(string propertyValue)
        {
            WindowsElement propertyFieldCombox = _pageInstance.PropertyFieldCombobox();
            MouseClickOnWindowsElement(propertyFieldCombox);
            IList<WindowsElement> clearButton = _pageInstance.InputClearButton;
            if (clearButton.Count > 0)
            {
                MouseClickOnWindowsElement(clearButton[0]);
                propertyFieldCombox = _pageInstance.PropertyFieldCombobox();
            }
            propertyFieldCombox.SendKeys(propertyValue);
            WindowsElement fieldValueListItem = _pageInstance.SelectPropertyValue(propertyValue);
            MouseClickOnWindowsElement(fieldValueListItem);
        }
        public void SelectKPIToFavorites(string kpiName)
        {
            SelectUserCreatedTab();
            ScrollToElement(kpiName);
            WaitForMoment(1);
            WindowsElement kpi = _pageInstance.SelectFavoriteByKPIName(kpiName);
            MouseClickOnWindowsElement(kpi);
            WaitForLoadingToDisappear(LoadingText.Adding.ToString());
        }
        public void ConfigureKPI(string titleValue, string aggregationType, string propertyValue, int quadrant = 1)
        {
            EnterKPIValueTitle(titleValue);
            SelectPropertyValue(propertyValue);
        }

        public void ClickOnAddKPITemplate()
        {
            WindowsElement kpi = _pageInstance.AddKPITemplate;
            MouseClickOnWindowsElement(kpi);
        }
        public void UpdateKPIProperties(string kPIName, string titleValue, string aggregationType, string propertyValue)
        {
            ScrollToElement(kPIName);
            WaitForMoment(1);
            WindowsElement kpi = _pageInstance.SelectFavoriteByKPIName(kPIName);
            MouseClickOnWindowsElement(kpi);
            WaitForLoadingToDisappear(LoadingText.Adding.ToString());
            ClickOnEditImageByKPIName(kPIName);
            ConfigureKPI(titleValue, aggregationType, propertyValue);
            ClickOnSaveButton();
            LogInfo($"Updated the KPI successfully");
        }
        public void ClickOnRefreshKPI()
        {
            IList<WindowsElement> moreContextOption = _pageInstance.MoreImage;
            MouseClickOnWindowsElement(moreContextOption[0]);
            IList<WindowsElement> refreshOption = _pageInstance.GetElementByText(KPIChartsContextOptions.Refresh.ToString());
            if (refreshOption.Count > 0)
            {
                MouseClickOnWindowsElement(refreshOption[0]);
            }
            WaitForLoadingToDisappear();
        }
        public void SelectValueFromMicroFilter()
        {
            IList<WindowsElement> kpiMicroFilterOptions = _pageInstance.KPIMicroFilterOptions.Where(a => a.Text.ToLower() != "more" && a.Text.ToLower() != "clear all").ToList();
            if (kpiMicroFilterOptions.Count > 0)
            {
                MouseClickOnWindowsElement(kpiMicroFilterOptions[0]);
            }
        }
        public bool IskpiMicroFilterPresent()
        {
            int count = _pageInstance.MicroFilter.Count;
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void VerifyKPITitle(string fieldValue)
        {
            IList<WindowsElement> kpiTitle = _pageInstance.SearchingText(fieldValue);
            if (kpiTitle.Count > 0)
            {
                Assert.IsTrue(kpiTitle[0].Text.Contains(fieldValue), $"KPI Title {kpiTitle[0].Text} is not as expected value {fieldValue}");
            }
            else
            {
                LogInfo($"KPI by Name :{fieldValue} is not present in the KPIs page");
                Assert.Fail($"KPI by Name :{fieldValue} is not present in the KPIs page");
            }
        }
        public void SelectKPIToDelete(string kPIName)
        {
            ScrollToElement(kPIName);

            IList<WindowsElement> kPIMoreOption = _pageInstance.GetKPIMoreOption(kPIName);
            if (kPIMoreOption != null & kPIMoreOption.Count > 0)
            {
                MouseClickOnWindowsElement(kPIMoreOption[0]);
                IList<WindowsElement> DeleteOption = _pageInstance.GetElementByText("Delete");
                if (DeleteOption.Count > 0)
                {
                    MouseClickOnWindowsElement(DeleteOption[0]);
                    _pageInstance.ConfirmationOkButton.Click();
                    WaitForLoadingToDisappear(LoadingText.Removing.ToString());
                }
            }
            else
            {
                LogInfo($"{kPIName} KPI is not available/configured for delete operation");
                Assert.Fail($"{kPIName} KPI is not available/configured for delete operation");
            }
        }
        public void VerifyKPIIsPresent(string kPIName, bool isExpextedPresent = false)
        {
            IList<WindowsElement> kPILabel = _pageInstance.GetElementByText(kPIName);
            bool isActualKPIPresent = kPILabel.Count > 0;

            if (isExpextedPresent)
            {
                Assert.AreEqual(isExpextedPresent, isActualKPIPresent, $"KPI Label :{kPIName} is not present in the current page");
            }
            else
            {
                Assert.AreEqual(isExpextedPresent, isActualKPIPresent, $"KPI Label :{kPIName} is present in the current page even after delete/remove operation");
            }
        }
        public bool IsKPIsChartsFavorited()
        {
            bool isKPIsChartsFavorited = false;
            IList<WindowsElement> allKPIs = _pageInstance.GetAllChartsKPIsByFavoriteIcon;
            if (allKPIs.Count > 0)
            {
                isKPIsChartsFavorited = true;
            }
            else
            {
                isKPIsChartsFavorited = false;
            }
            return isKPIsChartsFavorited;
        }
        public void SelectUserCreatedTab()
        {
            IList<WindowsElement> userCreatedTab = _pageInstance.UserCreatedTab;
            if (userCreatedTab.Count > 0)
            {
                userCreatedTab[0].Click();
            }
            WaitForLoadingToDisappear();
        }
        public void CheckVisibilityOfMicroFilterByKPI(string kPIName)
        {
            ScrollToElement(kPIName);
            ScrollToElement(kPIName);
            
            IList<WindowsElement> advanceFilterImage = _pageInstance.GetAdvanceFilterByKPIName(kPIName);
            
            if (advanceFilterImage != null)
            {
                MouseClickOnWindowsElement(advanceFilterImage[0]);
                if (_pageInstance.KPIMicroFilterOptions.Count > 0)
                {
                    LogInfo($"KPI Micro filter options are displayed");
                }
                else
                {
                    Assert.Fail($"KPI Micro filter options are not displayed");
                }
            }
            else
            {
                LogInfo($"{kPIName} KPI is not available/configured to Micro filter");
                Assert.Fail($"{kPIName} KPI is not available/configured to Micro filter");
            }
            IList<WindowsElement> moreOption = _pageInstance.GetElementByText("More");
            if (moreOption.Count > 0)
            {
                MouseClickOnWindowsElement(moreOption[0]);
            }
        }
        public void SelectGlobalKPIToFavorites(string kpiName)
        {
            ScrollToElement(kpiName);

            IList<WindowsElement> kPILabel = _pageInstance.GetElementByText(kpiName);

            if (kPILabel.Count == 0)
            {
                _pageInstance.ManageKPIs.Click();
                _pageInstance.ShowHideKPIByName(kpiName).Click();
                _pageInstance.KPIConfigSaveButton.Click();
                WaitForLoadingToDisappear();
            }

            ScrollToElement(kpiName);
            WaitForMoment(1);
            WindowsElement kpi = _pageInstance.SelectFavoriteByKPIName(kpiName);
            MouseClickOnWindowsElement(kpi);
            WaitForLoadingToDisappear(LoadingText.Adding.ToString());
        }
        public void VerifyHideAndShowKPIFunctionality(string kpiName)
        {
            ScrollToElement(kpiName);
            IList<WindowsElement> kPILabel = _pageInstance.GetElementByText(kpiName);

            if (kPILabel.Count > 0)
            {
                LogInfo($"KPI: {kpiName} is visible on page. " +
                    $"Hiding the KPI");

                _pageInstance.ManageKPIs.Click();
                _pageInstance.ShowHideKPIByName(kpiName).Click();
                _pageInstance.KPIConfigSaveButton.Click();
                WaitForLoadingToDisappear();
                ScrollToElement(kpiName);

                IList<WindowsElement> kPILabelHidden = _pageInstance.GetElementByText(kpiName);
                if (kPILabelHidden.Count == 0)
                {
                    LogInfo($"KPI: {kpiName} is hidden from page after hiding the KPI");
                }
                else
                {
                    Assert.Fail($"KPI: {kpiName} is visible on page even after hiding the KPI");
                }
            }
            else if (kPILabel.Count == 0)
            {
                LogInfo($"KPI: {kpiName} is hidden. " +
                    $"Un-hiding the KPI");

                _pageInstance.ManageKPIs.Click();
                _pageInstance.ShowHideKPIByName(kpiName).Click();
                _pageInstance.KPIConfigSaveButton.Click();
                WaitForLoadingToDisappear();
                ScrollToElement(kpiName);

                IList<WindowsElement> kPILabelUnHidden = _pageInstance.GetElementByText(kpiName);
                if (kPILabelUnHidden.Count > 0)
                {
                    LogInfo($"KPI: {kpiName} is visible on page after unhiding hidden KPI");
                }
                else
                {
                    Assert.Fail($"KPI: {kpiName} is not visible on page after unhiding hidden KPI");
                }
            }

        }
        public void ClickOnShareByKPIName(string kPIName)
        {
            IList<WindowsElement> kPIMoreOption = _pageInstance.KPIMoreOption(kPIName);
            if (kPIMoreOption.Count > 0)
            {
                MouseClickOnWindowsElement(kPIMoreOption[0]);
            }
            WaitForMoment(1);
            IList<WindowsElement> shareOption = _pageInstance.GetElementByText(KPIChartsContextOptions.Share.ToString());
            if (shareOption.Count > 0)
            {
                MouseClickOnWindowsElement(shareOption[0]);
            }
        }
        public void VerifySharedKPIsDislayedInSharedbyMePage(string labelName)
        {
            _pageInstance.KPIsComboBox.Click();
            _pageInstance.KPIsComboBoxList[1].Click();
            WaitForMoment(2);

            IList<WindowsElement> availableKPI = _pageInstance.GetElementByText(labelName);
            if (availableKPI.Count > 0)
            {
                LogInfo($"The KPI shared is present in 'Shared by me' page");
            }
            else
            {
                Assert.Fail($"The KPI shared is not present in 'Shared by me' page");
            }
        }
        public void SelectKPICreateTab(string kpiTabText)
        {
            IList<WindowsElement> kpiTab = _pageInstance.KPICreateTab(kpiTabText);
            if (kpiTab.Count > 0)
            {
                kpiTab[0].Click();
            }
            else
            {
                LogInfo($"More Option value : {kpiTabText} not able to identify in the current page.");
                Assert.Fail($"More Option value : {kpiTabText} not able to identify in the current page.");
            }
        }
        public void EnterKPIName(string kpiName)
        {
            WaitForMoment(2);
            _pageInstance.KPINameTextfield.Clear();
            _pageInstance.KPINameTextfield.SendKeys(kpiName);
        }
        public void EnterKPIFieldName(string kpiTextField)
        {
            _pageInstance.FieldKpiTemplateName.Clear();
            _pageInstance.FieldKpiTemplateName.SendKeys(kpiTextField);
        }
        public void ClickOnAddKPI()
        {
            var createKPIs = _pageInstance.AddKPIImage;
            _mouseActions.Click(createKPIs[0]).Build().Perform();
        }
        public void CreateKPIWithValue(string labelName, string fieldKpiTemplateName = "TestValue", string propertyValue = "Count")
        {
            EnterKPIName(labelName);
            SelectAggregationType("Field");
            WaitForMoment(2);
            EnterKPIFieldName(fieldKpiTemplateName);
            SelectPropertyValue(propertyValue);
        }
        public void CreateKPIWithChart(string labelName, string chartkpiTemplateName = "TestChart", string chartType = "Column", string measureValue = "Count", string dimensionValue = "Global Customer ID")
        {
            ClickOnAddKPITemplate();
            SelectAggregationType("Chart");
            _inboxChartsAction.EnterChartName(chartkpiTemplateName);
            _inboxChartsAction.SelectChartType(chartType);
            _inboxChartsAction.SelectMeasueField(measureValue);
            _inboxChartsAction.SelectDimensionField(dimensionValue);
        }
        public void CreateKPIWithValueAndChart(string labelName, string fieldKpiTemplateName = "TestValue", string propertyValue = "Count", string chartkpiTemplateName = "TestChart", string chartType = "Column", string measureValue = "Count", string dimensionValue = "Global Customer ID")
        {
            //Create the KPI
            //Create the KPI with value
            CreateKPIWithValue(labelName, fieldKpiTemplateName, propertyValue);

            //Create the KPI with chart
            CreateKPIWithChart(labelName, chartkpiTemplateName, chartType, measureValue, dimensionValue);
        }

        public void VerifyKPIIsPresentOnCretedByMeTab(string kPIName)
        {
            if (_pageInstance.CreatedByMeTab.Displayed && _pageInstance.CreatedByMeTab.Enabled)
            {
                _pageInstance.CreatedByMeTab.Click();
            }
            else
            {
                LogInfo($"Created by me tab is not present ");
            }
            IList<WindowsElement> kPILabel = _pageInstance.GetElementByText(kPIName);
            //bool isActualKPIPresent = kPILabel.Count > 0;
            if (kPILabel.Count > 0)
            {
                LogInfo($"KPI Label :{kPIName} is present in the Created by me page");
            }
            else
            {
                LogInfo($"KPI Label :{kPIName} is not present in the Created by me page");
            }
            SelectKPIToDelete(kPIName);
        }
    }
}
