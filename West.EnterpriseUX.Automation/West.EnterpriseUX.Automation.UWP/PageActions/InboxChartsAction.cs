using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class InboxChartsAction : BaseAction
    {

        private readonly WindowsDriver<WindowsElement> _session;
        private readonly InboxChartsPage _pageInstance;

        public InboxChartsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new InboxChartsPage(_session);
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
        public void ClickOnAddChart()
        {
            var createCharts = _pageInstance.AddChartImage;
            _mouseActions.Click(createCharts[0]).Build().Perform();
        }
        public void EnterChartName(string chartName)
        {
            _pageInstance.ChartNameTextfield.Clear();
            _pageInstance.ChartNameTextfield.SendKeys(chartName);
        }
        public void SelectMeasueField(string fieldValue)
        {
            _pageInstance.MeasureFieldComboBox.Click();
            _pageInstance.MeasureFieldComboBox.Clear();
            char[] filterFieldValue = fieldValue.ToCharArray();
            foreach (var eachValue in filterFieldValue)
            {
                _pageInstance.MeasureFieldComboBox.SendKeys(eachValue.ToString());
            }
            WindowsElement expectedValue = _pageInstance.SelectDropdownValue(fieldValue);
            MouseClickOnWindowsElement(expectedValue);
        }
        public void SelectDimensionField(string fieldValue)
        {
            _pageInstance.DimensionFieldComboBox.Click();
            _pageInstance.DimensionFieldComboBox.Clear();
            char[] filterFieldValue = fieldValue.ToCharArray();
            foreach (var eachValue in filterFieldValue)
            {
                _pageInstance.DimensionFieldComboBox.SendKeys(eachValue.ToString());
            }
            WindowsElement expectedValue = _pageInstance.SelectDropdownValue(fieldValue);
            MouseClickOnWindowsElement(expectedValue);
        }
        public void ClickOnCreateChart()
        {
            IList<WindowsElement> chartCloseOption;
            int attempt = 0;
            do
            {
                WindowsElement createText = _pageInstance.CreateChartButton;
                _touchScreen.SingleTap(createText.Coordinates);
                WaitForLoadingToDisappear(LoadingText.Saving.ToString());
                chartCloseOption = _pageInstance.ClosePopup;
                attempt++;
            } while (chartCloseOption.Count > 0 && attempt <= 3);
            WaitForLoadingToDisappear();
        }
        public void VerifyChartTitle(string fieldValue)
        {
            IList<WindowsElement> chartTitle = _pageInstance.SearchingText(fieldValue);
            if (chartTitle.Count > 0)
            {
                Assert.IsTrue(chartTitle[0].Text.Contains(fieldValue), $"Chart Title created {chartTitle[0].Text} is not as expected value {fieldValue}");
            }
            else
            {
                LogInfo($"Chart by Name :{fieldValue} is not present in the mycharts page after creating");
                Assert.Fail($"Chart by Name :{fieldValue} is not present in the mycharts page after creating");
            }
        }
        public void SelectChartToZoom(string chartName)
        {
            WaitForLoadingToDisappear();
            IList<WindowsElement> charts = _pageInstance.GetChartToZoom(chartName);
            if (charts.Count > 0)
            {
                MouseClickOnWindowsElement(charts[0]);
            }
            else
            {
                LogInfo($"Chart Name:{charts} is not found in the Charts Page.");
            }
        }
        public string SelectChartToFavorite(string chartName)
        {
            string favoritedChartName = string.Empty;
            WaitForLoadingToDisappear();
            if (String.IsNullOrEmpty(chartName))
            {
                favoritedChartName = SelectChartToFavorite();
            }
            else
            {
                IList<WindowsElement> chart = _pageInstance.GetChartToFavorite(chartName);
                MouseClickOnWindowsElement(chart[0]);
                favoritedChartName = chartName;
            }
            WaitForLoadingToDisappear(LoadingText.Adding.ToString());
            return favoritedChartName;
        }
        public string SelectChartToFavorite()
        {
            string favoritedChartName = string.Empty;
            IList<WindowsElement> allCharts = _pageInstance.GetAllChartsKPIsByFavoriteIcon;
            if (allCharts.Count > 0)
            {
                MouseClickOnWindowsElement(allCharts[0]);
                WaitForLoadingToDisappear(LoadingText.Adding.ToString());

                var allChartTitles = _pageInstance.GetAllChartsKPIsTitles;
                favoritedChartName = allChartTitles[0]?.Text;
            }
            else
            {
                LogInfo($"No Chart found in the Charts Page to favorite.");
            }
            return favoritedChartName;
        }
        public void SelectChartToDelete(string chartName)
        {
            IList<WindowsElement> chart = _pageInstance.GetChartToDelete(chartName);
            MouseClickOnWindowsElement(chart[0]);
            WaitForMoment(1);
            IList<WindowsElement> deleteOption = _pageInstance.GetElementByText(KPIChartsContextOptions.Delete.ToString());
            if (deleteOption.Count > 0)
            {
                MouseClickOnWindowsElement(deleteOption[0]);
            }
        }
        public void SelectChartToEdit(string chartName)
        {
            ScrollToElement(chartName);
            IList<WindowsElement> chart = _pageInstance.GetChartToEdit(chartName);
            MouseClickOnWindowsElement(chart[0]);
            WaitForMoment(1);
            IList<WindowsElement> editOption = _pageInstance.GetElementByText(KPIChartsContextOptions.Edit.ToString());
            if (editOption.Count > 0)
            {
                MouseClickOnWindowsElement(editOption[0]);
            }
        }
        public void SelectChartToRefresh(string chartName = "Sales")
        {
            IList<WindowsElement> chart = null;
            IList<WindowsElement> refreshOption = null;

            chart = _pageInstance.GetChartToRefresh(chartName);
            if (chart.Count > 0)
            {
                MouseClickOnWindowsElement(chart[0]);
                WaitForMoment(1);
                refreshOption = _pageInstance.GetElementByText(KPIChartsContextOptions.Refresh.ToString());
                if (refreshOption.Count > 0)
                {
                    MouseClickOnWindowsElement(refreshOption[0]);
                }
            }
            else
            {
                LogInfo($"No Charts by Name: {chartName} is available for Refresh Action");

                chart = GetFirstChartMoreOption();
                if (chart.Count > 0)
                {
                    MouseClickOnWindowsElement(chart[0]);
                    WaitForMoment(1);
                    refreshOption = _pageInstance.GetElementByText(KPIChartsContextOptions.Refresh.ToString());
                    if (refreshOption.Count > 0)
                    {
                        MouseClickOnWindowsElement(refreshOption[0]);
                    }
                }
                else
                {
                    LogInfo("No Charts are available for Refresh Action");
                }
            }
        }
        public void SelectChartToShare(string chartName)
        {
            IList<WindowsElement> chart = _pageInstance.GetChartToEdit(chartName);
            MouseClickOnWindowsElement(chart[0]);
            WaitForMoment(1);
            IList<WindowsElement> shareOption = _pageInstance.GetElementByText(KPIChartsContextOptions.Share.ToString());
            if (shareOption.Count > 0)
            {
                MouseClickOnWindowsElement(shareOption[0]);
            }
        }
        public void ClickOnYes()
        {
            _pageInstance.ConfirmationYesButton.Click();
            WaitForLoadingToDisappear(LoadingText.Removing.ToString());
        }
        public void VerifyChartPresent(string chartName, bool isPresent = false)
        {
            IList<WindowsElement> charts = _pageInstance.GetChartToDelete(chartName);
            if (isPresent)
            {
                Assert.AreEqual(isPresent, charts.Count > 0, $"Chart Name:{chartName} is not found in the Charts Page after Delete Chart Operation.");
            }
            else
            {
                Assert.AreEqual(isPresent, charts.Count > 0, $"Chart Name:{chartName} is found in the Charts Page after Delete Chart Operation.");
            }
        }
        public void DeleteAllUserCharts()
        {
            DeleteDataFromAbstractions();
        }
        public void ClickOnChartDetails()
        {
            WaitForMoment(2);
            IList<WindowsElement> chartDetails = _pageInstance.GetChartDetailsValues;
            if (chartDetails.Count > 0)
            {
                MouseClickOnWindowsElement(chartDetails[0]);
                WaitForLoadingToDisappear(LoadingText.Fetching.ToString());
            }
        }
        public void ClickOnViewInDetails()
        {
            _pageInstance.ViewInDetails.Click();
            WaitForLoadingToDisappear();
        }
        public void ScrollToChart(string chartName)
        {
            int attempt = 0;
            IList<WindowsElement> chart = _pageInstance.GetChartByTitle(chartName);
            bool isScroll;
            do
            {
                if (chart.Count > 0)
                {
                    if (!chart[0].Displayed)
                    {
                        IList<WindowsElement> mainWindow = _pageInstance.MainWindow;
                        WaitForMoment(0.5);
                        _touchScreen.SingleTap(mainWindow[0].Coordinates);
                        ScrollVertically();

                        chart = _pageInstance.GetChartByTitle(chartName);
                        isScroll = chart[0].Displayed;
                    }
                    else
                    {
                        LogInfo($"Chart by Name: {chartName} found without scrolling in 1st attempt");
                        isScroll = true;
                    }
                }
                else
                {
                    LogInfo($"Chart by Name: {chartName} is not found under the MyCharts");
                    isScroll = true;
                }
                attempt++;
            } while (!isScroll && attempt < 5);
        }
        public void ChangeChartType()
        {
            WindowsElement chartType;
            for (int count = 0; count < 2; count++)
            {
                string defaultChartType = _pageInstance.ChartTypeList.Text;
                chartType = _pageInstance.ChartTypeDropdown;
                chartType.SendKeys(Keys.ArrowDown);
                string changedChartType = _pageInstance.ChartTypeList.Text;
                Assert.AreNotEqual(defaultChartType, changedChartType, "On Chart Type action, still default chart type is not changing to alternative chart");
            }
        }
        public void SelectChartType(string chartType = "Pie")
        {
            WaitForLoadingToDisappear();
            IList<WindowsElement> chartTypes = _pageInstance.GetChartTypes;

            WindowsElement chartTypeElement = chartTypes?.FirstOrDefault(x => x.Text.Contains(chartType));
            if (chartTypeElement != null)
            {
                _touchScreen.SingleTap(chartTypeElement.Coordinates);
            }
            else
            {
                LogInfo($"Chart Type by Name: {chartType} is not found in the current page");
            }
        }
        public string GetChartType()
        {
            string chartType = string.Empty;

            Random random = new Random();
            int chartTypeNo = random.Next(1, 7);

            switch (chartTypeNo)
            {
                case 1:
                    chartType = "Pie";
                    break;
                case 2:
                    chartType = "Doughnut";
                    break;
                case 3:
                    chartType = "Bar";
                    break;
                case 4:
                    chartType = "Column";
                    break;
                case 5:
                    chartType = "Funnel";
                    break;
                case 6:
                    chartType = "Histogram";
                    break;
                case 7:
                    chartType = "Line";
                    break;
                default:
                    break;
            }
            return chartType;
        }
        public void UpdateChartDetails(string chartName, string measure, string dimension, string chartType = "Pie")
        {
            EnterChartName(chartName);
            SelectChartType(chartType);
            SelectMeasueField(measure);
            SelectDimensionField(dimension);
            ClickOnCreateChart();
        }
        public void VerifyUpdatedChartDetails(string expectedChartName, string expectedMeasure, string expectedDimension)
        {
            string actualChartName = _pageInstance.ChartNameTextfield.Text;
            string actualMeasure = _pageInstance.MeasureFieldComboBox.Text;
            string actualDimension = _pageInstance.DimensionFieldComboBox.Text;

            Assert.AreEqual(expectedChartName, actualChartName, "Updating of the Chart name is not successfull.");
            Assert.IsTrue(actualMeasure.Contains(expectedMeasure), "Updating of the Chart Measure value is not successfull.");
            Assert.IsTrue(actualDimension.Contains(expectedDimension), "Updating of the Chart Dimension value is not successfull.");
        }
        public void SelectAlternativeChartTypes()
        {
            ToggleAdvanceConfiguration();
            IList<WindowsElement> alternativeChartTypes = _pageInstance.AlternativeChartTypes?.Take(5).ToList();
            alternativeChartTypes[4].Click();
            foreach (var chartCheckbox in alternativeChartTypes)
            {
                _touchScreen.SingleTap(chartCheckbox.Coordinates);
            }
        }
        public bool IsMyChartTabPresent()
        {
            int count = _pageInstance.ConfiguredLabel.Count;
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ToggleAdvanceConfiguration()
        {
            IList<WindowsElement> advanceConfiguration = _pageInstance.ChartAdvanceConfiguration;
            if (advanceConfiguration.Count > 0)
            {
                MouseClickOnWindowsElement(_pageInstance.ChartAdvanceConfiguration[0]);
            }
        }
        public IList<WindowsElement> GetFirstChartMoreOption()
        {
            return _pageInstance.ChartMoreOption;
        }
        public void Share(string pageTitle)
        {
            if(_pageInstance.GetPageTitle.Text.Contains(pageTitle))
            {
                LogInfo($"Page title {_pageInstance.GetPageTitle.Text} verified successfully");
            }
            else
            {
                Assert.Fail($"Page title: {_pageInstance.GetPageTitle.Text} not matched");
            }
        }
        public void VerifySharedChartsDislayedInSharedbyMePage(string chartName)
        {
            _pageInstance.ChartsComboBox.Click();
            _pageInstance.ChartsComboBoxList[1].Click();
            WaitForMoment(2);

            IList<WindowsElement> chart = _pageInstance.GetChartByTitle(chartName);
            if (chart.Count > 0)
            {
                LogInfo($"The chart shared is present in 'Shared by me' page");
            }
            else
            {
                Assert.Fail($"The chart shared is not present in 'Shared by me' page");
            }
        }
    }
}
