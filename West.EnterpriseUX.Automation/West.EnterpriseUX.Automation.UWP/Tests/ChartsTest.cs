using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestCategory("Charts")]
    [TestClass]
    public class ChartsTest:BaseTest
    {
        #region TestMethods
        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the creating of the charts;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_77310.csv", "Charts_77310#csv", DataAccessMethod.Sequential)]
        public void TC_77310_CreatingChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart"+ chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
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
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the zoom functionality of the charts;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_84043.csv", "Charts_84043#csv", DataAccessMethod.Sequential)]
        public void TC_84043_ZoomChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartName = string.Empty;

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.Charts.ToString());
                chartName = _inboxChartsAction.SelectChartToFavorite();
                _inboxChartsAction.SelectChartToZoom(chartName);
                _inboxChartsAction.VerifyChartTitle(chartName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the favoriting functionality of the charts;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_84043.csv", "Charts_84043#csv", DataAccessMethod.Sequential)]
        public void TC_84046_FavoritingChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartName = string.Empty;

                NavigateToMyAppsInboxes(MyAppsOptions.Favorites.ToString());
                _homeAction.ClickOnKPIsAndCharts();
                _homeAction.UnFavoriteInInsightsTab();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.Charts.ToString());
                chartName = _inboxChartsAction.SelectChartToFavorite();
                NavigateToMyAppsInboxes(MyAppsOptions.Favorites.ToString());
                _homeAction.ClickOnKPIsAndCharts();
                _homeAction.VerifyInsightsChart(chartName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the deleting functionality of the charts;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_84061.csv", "Charts_84061#csv", DataAccessMethod.Sequential)]
        public void TC_84061_DeletingChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string measureOne = this.TestContext.DataRow["measureOne"].ToString();
                string dimensionOne = this.TestContext.DataRow["dimensionOne"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart Name" + uniqueNumber;

                //Creating the Chart under My Charts Tab
                CreateChart(chartName, function, inbox, measureOne, dimensionOne);

                //Selecting the Created Chart and Performing Delete operation
                _inboxChartsAction.ScrollToChart(chartName);
                _inboxChartsAction.SelectChartToDelete(chartName);
                _inboxChartsAction.ClickOnYes();
                _inboxChartsAction.VerifyChartPresent(chartName, false);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the navigation from charts to details Page using the table view of the charts;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_84061.csv", "Charts_84061#csv", DataAccessMethod.Sequential)]
        public void TC_137128_NavigationFromChartsToDetailsPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string measureOne = this.TestContext.DataRow["measureOne"].ToString();
                string dimensionOne = this.TestContext.DataRow["dimensionOne"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart Name" + uniqueNumber;

                //Creating the Chart under My Charts Tab
                CreateChart(chartName, function, inbox, measureOne, dimensionOne);

                _inboxChartsAction.ScrollToChart(chartName);
                _inboxChartsAction.SelectChartToZoom(chartName);
                _inboxChartsAction.ClickOnChartDetails();
                _inboxChartsAction.ClickOnViewInDetails();
                _inboxAction.VerifyNavigationToDetailsPage();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the changing of the chart type in the zoom window;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_84061.csv", "Charts_84061#csv", DataAccessMethod.Sequential)]
        public void TC_138485_ChangingChartTypeTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string measureOne = this.TestContext.DataRow["measureOne"].ToString();
                string dimensionOne = this.TestContext.DataRow["dimensionOne"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart Name" + uniqueNumber;

                //Creating the Chart under My Charts Tab
                CreateChart(chartName, function, inbox, measureOne, dimensionOne);

                _inboxChartsAction.SelectChartToEdit(chartName);
                _inboxChartsAction.VerifyChartTitle(chartName);
                _inboxChartsAction.SelectAlternativeChartTypes();
                _inboxChartsAction.ToggleAdvanceConfiguration();
                _inboxChartsAction.ClickOnCreateChart();
                _inboxChartsAction.SelectChartToZoom(chartName);
                _inboxChartsAction.ChangeChartType();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the Edit functionality of the Chart;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_84061.csv", "Charts_84061#csv", DataAccessMethod.Sequential)]
        public void TC_179213_EditChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string measureOne = this.TestContext.DataRow["measureOne"].ToString();
                string dimensionOne = this.TestContext.DataRow["dimensionOne"].ToString();
                string measureTwo = this.TestContext.DataRow["measureTwo"].ToString();
                string dimensionTwo = this.TestContext.DataRow["dimensionTwo"].ToString();

                string chartName = string.Empty;
                string chartType = _inboxChartsAction.GetChartType();

                chartName = "Chart Name" + _helper.GenerateUniqueRandomNumber();

                //Clearing all the Charts
                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.Charts.ToString());
                _inboxChartsAction.SelectUserCreatedTab();
                _inboxChartsAction.DeleteAllUserCharts();
                _inboxAction.ClickOnHomeActionsButton();
              
                //Creating the Chart under My Charts Tab
                CreateChart(chartName, function, inbox, measureOne, dimensionOne, chartType);

                //Selecting the Created Chart and Performing Delete operation
                _inboxChartsAction.ScrollToChart(chartName);
                _inboxChartsAction.SelectChartToEdit(chartName);
                chartName = "ChartName" + _helper.GenerateUniqueRandomNumber();
                chartType = _inboxChartsAction.GetChartType();
                _inboxChartsAction.UpdateChartDetails(chartName, measureTwo, dimensionTwo, chartType);
                _inboxChartsAction.SelectChartToEdit(chartName);
                _inboxChartsAction.VerifyUpdatedChartDetails(chartName, measureTwo, dimensionTwo);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the Refresh functionality of the KPI;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_84043.csv", "Charts_84043#csv", DataAccessMethod.Sequential)]
        public void TC_179210_RefreshChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartName = this.TestContext.DataRow["chartName"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.Charts.ToString());
                _inboxChartsAction.SelectChartToRefresh(chartName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the creating of the Doughnut charts;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_289763.csv", "Charts_289763#csv", DataAccessMethod.Sequential)]
        public void TC_289763_CreatingDoughnutChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart" + chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
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
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }
        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Verify shared charts are displayed in 'Shared by me' page. ;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_340933.csv", "Charts_340933#csv", DataAccessMethod.Sequential)]
        public void TC_340933_VerifySharedChartsDislayedInSharedbyMePageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();
                string recipientName = this.TestContext.DataRow["recipientName"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart" + chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
                _inboxChartsAction.SelectChartToShare(chartName);
                _inboxAction.Share(recipientName);
                _inboxChartsAction.VerifySharedChartsDislayedInSharedbyMePage(chartName);
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
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }
        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Verify Manage Access popup contents for shared chart.;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_340933.csv", "Charts_340933#csv", DataAccessMethod.Sequential)]
        public void TC_380331_VerifyManageAccessPopupContentsForSharedChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();
                string recipientName = this.TestContext.DataRow["recipientName"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart" + chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
                _inboxChartsAction.SelectChartToShare(chartName);
                _inboxAction.Share(recipientName);
                _inboxChartsAction.VerifySharedChartsDislayedInSharedbyMePage(chartName);
                _inboxAction.VerifyContentsOnManageAccessPage(chartName, recipientName);
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
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the creating of the Funnel charts;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_289765.csv", "Charts_289765#csv", DataAccessMethod.Sequential)]
        public void TC_289765_CreatingFunnelChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart" + chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
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
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the creating of the Pie charts;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_289756.csv", "Charts_289756#csv", DataAccessMethod.Sequential)]
        public void TC_289756_CreatingPieChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart" + chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
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
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the creating of the Bar charts;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_289764.csv", "Charts_289764#csv", DataAccessMethod.Sequential)]
        public void TC_289764_CreatingBarChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart" + chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
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
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the creating of the Column charts;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_289767.csv", "Charts_289767#csv", DataAccessMethod.Sequential)]
        public void TC_289767_CreatingColumnChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart" + chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
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
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the creating of the Line charts;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_289769.csv", "Charts_289769#csv", DataAccessMethod.Sequential)]
        public void TC_289769_CreatingLineChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart" + chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
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
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("ChartsTest")]
        [Description("Tests the creating of the Fast Line charts;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Charts_289770.csv", "Charts_289770#csv", DataAccessMethod.Sequential)]
        public void TC_289770_CreatingFastLineChartTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string persona = this.TestContext.DataRow["persona"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measure = this.TestContext.DataRow["measure"].ToString();
                string dimension = this.TestContext.DataRow["dimension"].ToString();

                string chartName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                chartName = "Chart" + chartType + uniqueNumber;
                LogInfo($"Function : {function} - Persona : {persona} - Inbox : {inbox} -ChartType : {chartType}.");

                CreateChart(chartName, function, inbox, measure, dimension, chartType);
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
                    _inboxChartsAction.DeleteAllUserCharts();
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
