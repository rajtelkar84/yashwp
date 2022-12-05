using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace West.EnterpriseUX.Automation.MobileNew
{
    public class ChartsPage : AppiumKeywords
    {
        public static AppiumDriver<IWebElement> _driver;
 
        public ChartsPage(AppiumDriver<IWebElement> driver) : base(driver)
        {
            _driver = driver;
        }

        #region ChartsPage Elements

        public IWebElement ChartsAbstractionTabTitle => WaitAndFindElement(androidLocator: MobileBy.XPath("//*[@text='CHARTS']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetAllChartsByFavoriteIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Favourite']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetAllChartsTitles => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Title']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetChartToZoom(string chartName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + chartName + "') and @content-desc='Title']/parent::*/parent::*/parent::*/descendant::*[@content-desc='zoomIcon']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> ChartPageTitle => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='PageTitleLabel']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetChartToRefresh(string chartName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + chartName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='RefreshBlock']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> UserCreatedTab => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, 'Created')]"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> CreateChartImage => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='PerformAction']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ChartNameTextfield => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='ChartName']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetChartType(string chartType)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@content-desc, '" + chartType + "')]"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> MeasureFieldComboBox => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, 'Measures')]/parent::*/parent::*/parent::*/following-sibling::*[1]/descendant::*[@content-desc=' Input Field']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> MeasuresViewGroup => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Measures']/parent::*"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> SelectValue(string value)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text,'" + value + "')]"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> DimensionFieldComboBox => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, 'Dimensions')]/parent::*/parent::*/parent::*/following-sibling::*[1]/descendant::*[@content-desc=' Input Field']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> DimensionsViewGroup => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Dimensions']/parent::*"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> CreateChartButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Create']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ExpanderIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='expanderIcon']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> DeleteIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Delete']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> EditIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='Edit']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> ConfirmButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='YES']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetExpanderIconOfChart(string chartName)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + chartName + "') and @content-desc='Title']/parent::*/parent::*/following-sibling::*/following-sibling::*/descendant::*[@content-desc='expanderIcon']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> LoadAllButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='LOAD ALL']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> LoadMoreButton => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='LOAD MORE']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> RemoveMeasureIcon => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='removeMeasureIcon']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> RemoveDimensionIcon(string dimension)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@content-desc='SelctedDimensionChip_" + dimension + "_CloseButton']"), iosLocator: MobileBy.XPath(""));
        }
        public IList<IWebElement> AdvancedConfigurationOption => WaitAndFindElements(androidLocator: MobileBy.XPath("//*[@text='Advanced Configuration']"), iosLocator: MobileBy.XPath(""));
        public IList<IWebElement> GetSelectedMeasureOrDimension(string measureOrDimension)
        {
            return WaitAndFindElements(androidLocator: MobileBy.XPath("//*[contains(@text, '" + measureOrDimension + "')]"), iosLocator: MobileBy.XPath(""));
        }


        #endregion ChartsPage Elements

        #region ChartsPage Actions

        public string SelectChartToFavorite()
        {
            string favoritedChartName = string.Empty;
            IList<IWebElement> allCharts = GetAllChartsByFavoriteIcon;
            if (allCharts.Count > 0)
            {
                allCharts[0].Click();
                WaitForMoment(10);

                favoritedChartName = GetAllChartsTitles[0]?.Text;
            }
            else
            {
                Console.WriteLine($"No Chart found in the Charts Page to favorite.");
            }
            return favoritedChartName;
        }

        public void SelectChartToZoom(string chartName)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetChartToZoom(chartName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetChartToZoom(chartName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{chartName} Chart is not available/configured to Zoom");
            }
        }

        public void VerifyChartPageTitle(string chartName)
        {
            try
            {
                WaitForMoment(2);
                Assert.IsTrue(ChartPageTitle.Count > 0);
                Assert.IsTrue(ChartPageTitle[0].Displayed);
                Assert.IsTrue(ChartPageTitle[0].Text.Equals(chartName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{chartName} Chart is not Zoomed in.");
            }
        }

        public void SelectChartToRefresh(string chartName)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetChartToRefresh(chartName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetChartToRefresh(chartName)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{chartName} Chart is not available/configured to Zoom");
            }
        }

        public void CreateChart(string chartName, string measure, string dimension, string chartType)
        {
            try
            {
                SelectUserCreatedTab();
                ClickOnCreateChartImage();
                EnterChartName(chartName);
                SelectChartType(chartType);
                SelectMeasureField(measure);
                SelectDimensionField(dimension);
                ClickOnCreateChart();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{chartName} Chart is not created.");
            }
        }

        public void EditChart(string chartName, string measure, string dimension, string chartType)
        {
            try
            {
                EnterChartName(chartName);
                SelectChartType(chartType);
                SelectMeasureField(measure);
                SelectDimensionField(dimension);
                ClickOnCreateChart();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                Assert.Fail($"{chartName} Chart is not created.");
            }
        }

        public void VerifyUpdatedChartDetails(string expectedChartName, string expectedMeasure, string expectedDimension)
        {
            string actualChartName = ChartNameTextfield[0].Text;
            Assert.AreEqual(expectedChartName, actualChartName, "Updating of the Chart name is not successfull.");

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (AdvancedConfigurationOption.Count == 0)
            {
                ScrollUp();
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            bool actualMeasure = GetSelectedMeasureOrDimension(expectedMeasure)[0].Displayed;
            bool actualDimension = GetSelectedMeasureOrDimension(expectedDimension)[0].Displayed;

            Assert.IsTrue(actualMeasure, "Updating of the Chart Measure value is not successfull.");
            Assert.IsTrue(actualDimension, "Updating of the Chart Dimension value is not successfull.");
        }

        public void DeleteAllUserCreatedCharts()
        {
            IList<IWebElement> chartTitles = GetAllChartsTitles;

            while (chartTitles.Count > 0)
            {
                ExpanderIcon[0].Click();
                WaitForMoment(1);
                DeleteIcon[0].Click();
                WaitForMoment(1);
                ConfirmButton[0].Click();
                WaitForMoment(20);
            }
        }

        public void ClearSelectedMeasures()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (RemoveMeasureIcon.Count == 0)
            {
                ScrollUp();
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            IList<IWebElement> removeIcon = RemoveMeasureIcon;
            while (removeIcon.Count > 0)
            {
                RemoveMeasureIcon[0].Click();
                WaitForMoment(1);
                removeIcon = RemoveMeasureIcon;
            }
        }

        public void ClearSelectedDimensions(string dimension)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (RemoveDimensionIcon(dimension).Count == 0)
            {
                ScrollUp();
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            IList<IWebElement> removeIcon = RemoveDimensionIcon(dimension);
            while (removeIcon.Count > 0)
            {
                RemoveDimensionIcon(dimension)[0].Click();
                WaitForMoment(1);
                removeIcon = RemoveDimensionIcon(dimension);
            }
        }

        public void SelectUserCreatedTab()
        {
            if (UserCreatedTab.Count > 0)
            {
                UserCreatedTab[0].Click();
            }
            WaitForMoment(5);
        }

        public void ClickOnCreateChartImage()
        {
            if (CreateChartImage.Count > 0)
            {
                CreateChartImage[0].Click();
                WaitForMoment(5);
            }
            else
            {
                Console.WriteLine($"For Creating a chart : Create Chart button is not present in the current page.");
                Assert.Fail($"For Creating a chart : Create Chart button is not present in the current page.");
            }
        }

        public void EnterChartName(string chartName)
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
            while (ChartNameTextfield.Count == 0)
            {
                ScrollDown();
            }
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            ChartNameTextfield[0].Click();
            ChartNameTextfield[0].Clear();
            ChartNameTextfield[0].SendKeys(chartName);
            WaitForMoment(2);
        }

        public void SelectChartType(string chartType)
        {
            WaitForMoment(2);

            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetChartType(chartType).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetChartType(chartType)[0].Click();
                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"Chart Type by Name: {chartType} is not found in the current page");
            }
        }

        public void SelectMeasureField(string fieldValue)
        {
            bool isMeasureComboBoxDisplayed = MeasureFieldComboBox[0].Displayed;

            if (!isMeasureComboBoxDisplayed)
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (MeasureFieldComboBox.Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                MeasureFieldComboBox[0].Click();
                MeasureFieldComboBox[0].Clear();
            }
            else
            {
                MeasureFieldComboBox[0].Click();
                MeasureFieldComboBox[0].Clear();
            }
            WaitForMoment(0.5);
            MeasureFieldComboBox[0].SendKeys(fieldValue);
            WaitForMoment(0.5);
            _driver.HideKeyboard();
            WaitForMoment(1);
            MeasuresViewGroup[0].Click();
            /*
            IList<IWebElement> measureElement = SelectValue(fieldValue);
            new TouchAction(_driver).Tap(measureElement[0]).Perform();
            new Actions(_driver).SendKeys(Keys.Enter).Perform();
            */
            WaitForMoment(2);
        }

        public void SelectDimensionField(string fieldValue)
        {
            bool isDimensionComboBoxDisplayed = DimensionFieldComboBox[0].Displayed;

            if (!isDimensionComboBoxDisplayed)
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (DimensionFieldComboBox.Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                DimensionFieldComboBox[0].Click();
                DimensionFieldComboBox[0].Clear();
            }
            else
            {
                DimensionFieldComboBox[0].Click();
                DimensionFieldComboBox[0].Clear();
            }
            WaitForMoment(0.5);
            DimensionFieldComboBox[0].SendKeys(fieldValue);
            WaitForMoment(0.5);
            _driver.HideKeyboard();
            WaitForMoment(1);
            DimensionsViewGroup[0].Click();
            /*
            IList<IWebElement> dimensionElement = SelectValue(fieldValue);
            new TouchAction(_driver).Tap(dimensionElement[0]).Perform();
            new Actions(_driver).SendKeys(Keys.Enter).Perform();
            */
            WaitForMoment(2);
        }

        public void ClickOnCreateChart()
        {
            if (CreateChartButton.Count > 0)
            {
                CreateChartButton[0].Click();
            }
            WaitForMoment(2);
        }

        public void SelectChartToDelete(string chartName)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetExpanderIconOfChart(chartName).Count == 0)
                {
                    ScrollUp();
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetExpanderIconOfChart(chartName)[0].Click();
                WaitForMoment(1);
                DeleteIcon[0].Click();
                WaitForMoment(1);
                ConfirmButton[0].Click();
                WaitForMoment(20);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{chartName} Chart is not available to delete");
            }
        }

        public void SelectChartToEdit(string chartName)
        {
            try
            {
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
                while (GetExpanderIconOfChart(chartName).Count == 0)
                {
                    ScrollUp();

                    if(LoadMoreButton.Count > 0)
                    {
                        LoadMoreButton[0].Click();
                        WaitForMoment(1);
                    }
                }
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

                GetExpanderIconOfChart(chartName)[0].Click();
                WaitForMoment(1);
                EditIcon[0].Click();
                WaitForMoment(5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Assert.Fail($"{chartName} Chart is not available to delete");
            }
        }

        public void VerifyChartPresent(string chartName, bool isPresent = false)
        {
            IList<IWebElement> charts = GetChartToRefresh(chartName);

            if (isPresent)
            {
                Assert.AreEqual(isPresent, charts.Count > 0, $"Chart Name:{chartName} is found in the Charts Page after Delete Chart Operation.");
            }
            else
            {
                Assert.AreEqual(isPresent, charts.Count > 0, $"Chart Name:{chartName} is not found in the Charts Page after Delete Chart Operation.");
            }
        }

       

        #endregion ChartsPage Actions
    }
}
