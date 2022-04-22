using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestCategory("Storyboards")]
    [TestClass]
    public class StoryboardsTest:BaseTest
    {
        #region TestMethods

        [TestMethod]
        [TestCategory("StoryboardsTest")]
        [Description("Tests the creating of the storyboard (Create chart/kpi and import chart/kpi);;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Storyboards_261447.csv", "Storyboards_261447#csv", DataAccessMethod.Sequential)]
        public void TC_80154_CreatingStoryboardUsingChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string storyboardTitle = string.Empty;
                string chartTitle = string.Empty;
                string labelName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                storyboardTitle = "Storyboard" + uniqueNumber;
                chartTitle = "Chart" + uniqueNumber;
                labelName = "Label" + uniqueNumber;

                CreateStoryboard(storyboardTitle, function, inbox, chartTitle, labelName, measure, dimension);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            finally
            {
                try
                {
                    _storyboardsAction.DeleteAllStoryboards();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("StoryboardsTest")]
        [Description("Verifying the Edit functionality of the storyboard;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Storyboards_179216.csv", "Storyboards_179216#csv", DataAccessMethod.Sequential)]
        public void TC_179216_EditStoryboardTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string storyboardTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                storyboardTitle = "Storyboard" + uniqueNumber;

                NavigateToInboxByGlobalSearch(function, inbox);

                //1. Creating the chart for the storyboard
                _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
                _storyboardsAction.ClickOnCreateStoryBoard();
                _storyboardsAction.EnterStoryboardTitle(storyboardTitle);

                //1. Import Chart
                _storyboardsAction.SelectStoryboardType("Import Chart");
                _storyboardsAction.ImportCharts();
                LogInfo($"Importing the Chart for the storyboard is completed");

                //2. Import KPI
                _storyboardsAction.SelectStoryboardType("Import KPI");
                _storyboardsAction.ImportKPIs();
                LogInfo($"Importing the KPI for the storyboard is completed");

                //3. Save the Storyboard
                _storyboardsAction.SaveStoryboard();
                _storyboardsAction.VerifyStoryboardCreation(storyboardTitle,true);

                //4. Open the Storyboard
                _storyboardsAction.SelectStoryboardByName(storyboardTitle);
                _storyboardsAction.EditStoryboard();

                //5. Deleting one chart/KPI and Save the Storyboard
                _storyboardsAction.DeleteStoryboardByCount(1);
                _storyboardsAction.ClickOnYes();
                _storyboardsAction.SaveStoryboard();

                //6. Open and verify the storyboard after edit operation
                _storyboardsAction.SelectStoryboardByName(storyboardTitle);
                _storyboardsAction.EditStoryboard();
                _storyboardsAction.VerifyStoryboardItemsCount(1);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("StoryboardsTest")]
        [Description("Verifying the Delete functionality of the storyboard;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Storyboards_179216.csv", "Storyboards_179216#csv", DataAccessMethod.Sequential)]
        public void TC_179219_DeleteStoryboardTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string storyboardTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                storyboardTitle = "Storyboard" + uniqueNumber;

                NavigateToInboxByGlobalSearch(function, inbox);

                //1. Creating the storyboard
                _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
                _storyboardsAction.ClickOnCreateStoryBoard();
                _storyboardsAction.EnterStoryboardTitle(storyboardTitle);

                //2. Import Chart
                _storyboardsAction.SelectStoryboardType("Import Chart");
                _storyboardsAction.ImportCharts();
                LogInfo($"Importing the Chart for the storyboard is completed");

                //3. Save the Storyboard
                _storyboardsAction.SaveStoryboard();
                _storyboardsAction.VerifyStoryboardCreation(storyboardTitle,true);

                //4. Deleting the Storyboard and verifying
                _storyboardsAction.SelectStoryboardByName(storyboardTitle);
                _storyboardsAction.ClickOnDeleteStoryboard();
                _storyboardsAction.ClickOnYes();
                _storyboardsAction.VerifyStoryboardCreation(storyboardTitle, false);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("StoryboardsTest")]
        [Description("Tests the creating of the storyboard by creating chart;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Storyboards_261447.csv", "Storyboards_261447#csv", DataAccessMethod.Sequential)]
        public void TC_261447_CreatingStoryboardByCreatingChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string storyboardTitle = string.Empty;
                string chartTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                storyboardTitle = "Storyboard" + uniqueNumber;
                chartTitle = "Chart" + uniqueNumber;

                NavigateToInboxByGlobalSearch(function, inbox);

                //1. Creating the chart for the storyboard
                _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
                _storyboardsAction.ClickOnCreateStoryBoard();
                _storyboardsAction.EnterStoryboardTitle(storyboardTitle);
                _storyboardsAction.SelectStoryboardType("Chart");
                _inboxChartsAction.EnterChartName(chartTitle);
                _inboxChartsAction.SelectMeasueField(measure);
                _inboxChartsAction.SelectDimensionField(dimension);
                _inboxChartsAction.ClickOnCreateChart();
                LogInfo($"Creating the chart for the storyboard is completed");

                //2. Save the Storyboard
                _storyboardsAction.SaveStoryboard();
                _storyboardsAction.VerifyStoryboardCreation(storyboardTitle, true);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            finally
            {
                try
                {
                    _storyboardsAction.DeleteAllStoryboards();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("StoryboardsTest")]
        [Description("Verifying the functionality of creating storyboard by importing chart;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Storyboards_179216.csv", "Storyboards_179216#csv", DataAccessMethod.Sequential)]
        public void TC_261878_CreatingStoryboardByImportingChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string storyboardTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                storyboardTitle = "Storyboard" + uniqueNumber;

                NavigateToInboxByGlobalSearch(function, inbox);

                //1. Creating the storyboard
                _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
                _storyboardsAction.ClickOnCreateStoryBoard();
                _storyboardsAction.EnterStoryboardTitle(storyboardTitle);

                //2. Import Chart
                _storyboardsAction.SelectStoryboardType("Import Chart");
                _storyboardsAction.ImportCharts();
                LogInfo($"Importing the Chart for the storyboard is completed");

                //3. Save the Storyboard
                _storyboardsAction.SaveStoryboard();
                _storyboardsAction.VerifyStoryboardCreation(storyboardTitle, true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            finally
            {
                try
                {
                    _storyboardsAction.DeleteAllStoryboards();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("StoryboardsTest")]
        [Description("Verifying the functionality of creating storyboard by creating KPI;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Storyboards_179216.csv", "Storyboards_179216#csv", DataAccessMethod.Sequential)]
        public void TC_261905_CreatingStoryboardByCreaingKPITest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string propertyValue = this.TestContext.DataRow["chartMesaure"].ToString();

                string labelName = string.Empty;
                string storyboardTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueNumber;
                storyboardTitle = "Storyboard" + uniqueNumber;

                NavigateToInboxByGlobalSearch(function, inbox);

                //1. Creating the storyboard
                _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
                _storyboardsAction.ClickOnCreateStoryBoard();
                _storyboardsAction.EnterStoryboardTitle(storyboardTitle);
                _storyboardsAction.SelectStoryboardType(WDAbstractions.KPIs.ToString());

                //2. Creating KPI for creating storyboard.
                _inboxKpisAction.ConfigureKPI(labelName, "Field", propertyValue);
                _inboxKpisAction.SelectAggregationType("Field");
                _inboxKpisAction.ClickOnSaveButton();

                //3. Save the Storyboard
                _storyboardsAction.SaveStoryboard();
                _storyboardsAction.VerifyStoryboardCreation(storyboardTitle, true);
                LogInfo($"Creating the KPI for the storyboard is completed");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            finally
            {
                try
                {
                    _storyboardsAction.DeleteAllStoryboards();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("StoryboardsTest")]
        [Description("Verifying the functionality of creating storyboard by importing KPIs;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Storyboards_179216.csv", "Storyboards_179216#csv", DataAccessMethod.Sequential)]
        public void TC_261908_CreatingStoryboardByImportingKPIsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string storyboardTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                storyboardTitle = "Storyboard" + uniqueNumber;

                NavigateToInboxByGlobalSearch(function, inbox);

                //1. Creating the storyboard
                _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
                _storyboardsAction.ClickOnCreateStoryBoard();
                _storyboardsAction.EnterStoryboardTitle(storyboardTitle);

                //2. Import KPI
                _storyboardsAction.SelectStoryboardType("Import KPI");
                _storyboardsAction.ImportKPIs();
                LogInfo($"Importing the KPI for the storyboard is completed");

                //3. Save the Storyboard
                _storyboardsAction.SaveStoryboard();
                _storyboardsAction.VerifyStoryboardCreation(storyboardTitle, true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            finally
            {
                try
                {
                    _storyboardsAction.DeleteAllStoryboards();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("StoryboardsTest")]
        [Description("Verifying the functionality of creating storyboard by importing Power BI Reports;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Storyboards_179216.csv", "Storyboards_179216#csv", DataAccessMethod.Sequential)]
        public void TC_262397_CreatingStoryboardByImportingPowerBIReports()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string storyboardTitle = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                storyboardTitle = "Storyboard" + uniqueNumber;

                NavigateToInboxByGlobalSearch(function, inbox);

                //1. Creating the storyboard
                _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
                _storyboardsAction.ClickOnCreateStoryBoard();
                _storyboardsAction.EnterStoryboardTitle(storyboardTitle);

                //2. Import Chart
                _storyboardsAction.SelectStoryboardType("Import Reports");
                _storyboardsAction.ImportReports();
                LogInfo($"Importing the Power BI Reports for the storyboard is completed");

                //3. Save the Storyboard
                _storyboardsAction.SaveStoryboard();
                _storyboardsAction.VerifyStoryboardCreation(storyboardTitle, true);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            finally
            {
                try
                {
                    _storyboardsAction.DeleteAllStoryboards();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }
        #endregion
    }
}
