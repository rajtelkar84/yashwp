using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestCategory("KPIs")]
    [TestClass]
    public class KPIsTest:BaseTest
    {
        #region TestMethods

        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the zoom functionality of the KPI;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_84010.csv", "KPIs_84010#csv", DataAccessMethod.Sequential)]
        public void TC_84010_ZoomKPITest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string kPI = this.TestContext.DataRow["kPI"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.SelectKPIToZoom(kPI);
                _inboxAction.WaitForLoadingToDisappear();
                _homeAction.ClickOnHomeActionsButton();
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
                    _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                    _inboxKpisAction.SelectUserCreatedTab();
                    _inboxChartsAction.DeleteAllUserCharts();
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                }
            }
        }

        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the favoriting functionality of the KPI;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_84010.csv", "KPIs_84010#csv", DataAccessMethod.Sequential)]
        public void TC_84032_FavoritingKPITest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string kPI = string.Empty;

                _homeAction.ClickOnFunction("Home");
                _homeAction.SelectMyAppsOption(MyAppsOptions.Favorites.ToString());
                _homeAction.ClickOnKPIsAndCharts();
                _homeAction.UnFavoriteInInsightsTab();
                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());

                kPI = _inboxKpisAction.SelectKPIToFavorite();
                NavigateToMyAppsInboxes(MyAppsOptions.Favorites.ToString());
                _homeAction.ClickOnKPIsAndCharts();
                _homeAction.VerifyInsightsKPI(kPI);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the navigation from KPI to details page functionality;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_84010.csv", "KPIs_84010#csv", DataAccessMethod.Sequential)]
        public void TC_84037_NavigationFromKPIToDetailsPageThroughKPIsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string kPI = this.TestContext.DataRow["kPI"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.NavigateToDetailsFromKPI(kPI);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the KPI advance microfilter functionality;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_95348.csv", "KPIs_95348#csv", DataAccessMethod.Sequential)]
        public void TC_95348_CheckingKPIAdvanceMicroFilterFunctionlaityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string kPI = this.TestContext.DataRow["kPI"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.ClickOnAdvanceFilterByKPI(kPI);
                _inboxKpisAction.ClickOnMoreOption();
                _inboxFilterAction.ApplyFilterUpdated(filterField, operatorValue, filterValue);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the Edit functionality of the KPI;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_84010.csv", "KPIs_84010#csv", DataAccessMethod.Sequential)]
        public void TC_179208_EditKPITest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();
                string propertyValueOne = this.TestContext.DataRow["propertyValueOne"].ToString();
                string propertyValueTwo = this.TestContext.DataRow["propertyValueTwo"].ToString();

                string labelName = string.Empty;
                string kpiTemplateName = string.Empty;
                string uniqueIdentifier = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueIdentifier;
                kpiTemplateName = $"TestValue" + uniqueIdentifier;

                NavigateToInboxByGlobalSearch(function, inbox);
                ClearAbstractionData(WDAbstractions.KPIs.ToString());
                CreateDashboardLabel(labelName, filterField, operatorValue, filterValue);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                ConfigureKPIWithValue(labelName, kpiTemplateName, propertyValueOne,true);
                _inboxKpisAction.ClickOnSaveButton();
                LogInfo($"Configuring the KPI: {labelName} is successfull");
                _inboxKpisAction.UpdateKPIProperties(labelName,$"Updated_"+ kpiTemplateName, "Field", propertyValueTwo);
                _homeAction.ClickOnFunction("Home");
                _homeAction.SelectMyAppsOption(MyAppsOptions.Favorites.ToString());
                _homeAction.ClickOnKPIsAndCharts();
                _inboxKpisAction.SelectKPIToZoom(labelName);
                _inboxKpisAction.VerifyKPIName($"Updated_" + kpiTemplateName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the Refresh functionality of the KPI;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_84010.csv", "KPIs_84010#csv", DataAccessMethod.Sequential)]
        public void TC_179206_RefreshKPITest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.ClickOnRefreshKPI();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the KPI microfilter functionality;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_275610.csv", "KPIs_275610#csv", DataAccessMethod.Sequential)]
        public void TC_275610_VerifyingKPIMicroFilterTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string kPI = this.TestContext.DataRow["kPI"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.ClickOnAdvanceFilterByKPI(kPI);
                _inboxKpisAction.SelectValueFromMicroFilter();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the Delete functionality of the KPI;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_84010.csv", "KPIs_84010#csv", DataAccessMethod.Sequential)]
        public void TC_251610_VerifyingKPIDeleteTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                string labelName = string.Empty;
                string uniqueIdentifier = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueIdentifier;

                NavigateToInboxByGlobalSearch(function, inbox);
                CreateDashboardLabel(labelName, filterField, operatorValue, filterValue);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.SelectUserCreatedTab();
                _inboxAction.ScrollToElement(labelName);
                _inboxKpisAction.SelectKPIToDelete(labelName);
                _inboxAction.SelectAbstraction(WDAbstractions.Details.ToString());
                _inboxAction.SelectDetailsMoreOption("Manage Labels");
                _inboxKpisAction.VerifyKPIIsPresent(labelName, false);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the Unfavoriting functionality of the KPI and Charts;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_84010.csv", "KPIs_84010#csv", DataAccessMethod.Sequential)]
        public void TC_261400_VerifyingUnfavoritingKPIChartsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                bool isKPIsChartsFavorited = false;

                _homeAction.ClickOnFunction("Home");
                _homeAction.SelectMyAppsOption(MyAppsOptions.Favorites.ToString());
                _homeAction.ClickOnKPIsAndCharts();
                isKPIsChartsFavorited = _inboxKpisAction.IsKPIsChartsFavorited();
                if(isKPIsChartsFavorited)
                {
                    _homeAction.UnFavoriteInInsightsTab();
                }
                else
                {
                    NavigateToInboxByGlobalSearch(function, inbox);
                    _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                    _inboxKpisAction.SelectKPIToFavorite();
                    _inboxAction.SelectAbstraction(WDAbstractions.Charts.ToString());
                    _inboxChartsAction.SelectChartToFavorite();
                    NavigateToMyAppsInboxes(MyAppsOptions.Favorites.ToString());
                    _homeAction.ClickOnKPIsAndCharts();
                    _homeAction.UnFavoriteInInsightsTab();
                }
                _homeAction.VerifyInsightsKPIsCharts(false);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Verifying View Load More/Load All options in KPI Page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_84010.csv", "KPIs_84010#csv", DataAccessMethod.Sequential)]
        public void TC_254008_VerifyLoadMoreAndAllOptionsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxAction.VerifyLoadMoreFunctionality();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the KPI microfilter on favorites page;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_285095.csv", "KPIs_285095#csv", DataAccessMethod.Sequential)]
        public void TC_285095_CheckingKPIMicroFilterOnFavoritesPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string kpi = this.TestContext.DataRow["kPI"].ToString();
                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.SelectGlobalKPIToFavorites(kpi);
                NavigateToMyAppsInboxes(MyAppsOptions.Favorites.ToString());
                _homeAction.ClickOnKPIsAndCharts();
                _inboxKpisAction.CheckVisibilityOfMicroFilterByKPI(kpi);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests HIde and Show KPI Functionality on KPI Abstraction Page;;")]
        [Owner("gaurav.waniEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_285095.csv", "KPIs_285095#csv", DataAccessMethod.Sequential)]
        public void TC_306504_VerifyHideAndShowKPIFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string kpi = this.TestContext.DataRow["kPI"].ToString();

                //1. Navigates to inbox (Customers).
                NavigateToInboxByGlobalSearch(function, inbox);

                //2. Navigates to KPI abstraction.
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());

                //3. Verify Hide/Show functionality for KPI. 
                _inboxKpisAction.VerifyHideAndShowKPIFunctionality(kpi);

                //4. Verify Hide/Show functionality for KPI. (Checks in case KPI is Un-hidden)
                _inboxKpisAction.VerifyHideAndShowKPIFunctionality(kpi);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Verify shared KPI are displayed in 'Shared by me' page. ;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_377948.csv", "KPIs_377948#csv", DataAccessMethod.Sequential)]
        public void TC_377948_VerifySharedKPIsDislayedInSharedbyMePageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();
                string propertyValueOne = this.TestContext.DataRow["propertyValueOne"].ToString();
                string recipientName = this.TestContext.DataRow["recipientName"].ToString();

                string labelName = string.Empty;
                string kpiTemplateName = string.Empty;
                string uniqueIdentifier = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueIdentifier;
                kpiTemplateName = $"TestValue" + uniqueIdentifier;

                NavigateToInboxByGlobalSearch(function, inbox);
                ClearAbstractionData(WDAbstractions.KPIs.ToString());
                CreateDashboardLabel(labelName, filterField, operatorValue, filterValue);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                ConfigureKPIWithValue(labelName, kpiTemplateName, propertyValueOne, true);
                _inboxKpisAction.ClickOnSaveButton();
                LogInfo($"Configuring the KPI: {labelName} is successfull");
                _inboxKpisAction.ClickOnShareByKPIName(labelName);
                _inboxAction.Share(recipientName);
                _inboxKpisAction.VerifySharedKPIsDislayedInSharedbyMePage(labelName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Verify Manage Access popup contents for shared KPI.;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_377948.csv", "KPIs_377948#csv", DataAccessMethod.Sequential)]
        public void TC_380322_VerifyManageAccessPopupContentsForSharedKPITest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();
                string propertyValueOne = this.TestContext.DataRow["propertyValueOne"].ToString();
                string recipientName = this.TestContext.DataRow["recipientName"].ToString();

                string labelName = string.Empty;
                string kpiTemplateName = string.Empty;
                string uniqueIdentifier = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueIdentifier;
                kpiTemplateName = $"TestValue" + uniqueIdentifier;

                NavigateToInboxByGlobalSearch(function, inbox);
                ClearAbstractionData(WDAbstractions.KPIs.ToString());
                CreateDashboardLabel(labelName, filterField, operatorValue, filterValue);
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                ConfigureKPIWithValue(labelName, kpiTemplateName, propertyValueOne, true);
                _inboxKpisAction.ClickOnSaveButton();
                LogInfo($"Configuring the KPI: {labelName} is successfull");
                _inboxKpisAction.ClickOnShareByKPIName(labelName);
                _inboxAction.Share(recipientName);
                _inboxKpisAction.VerifySharedKPIsDislayedInSharedbyMePage(labelName);
                _inboxAction.VerifyContentsOnManageAccessPage(labelName, recipientName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the Create functionality of the KPI From Global Section;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_482002.csv", "KPIs_482002#csv", DataAccessMethod.Sequential)]
        public void TC_482002_VerifyCreateKPIFromGlobalSection()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string propertyValue = this.TestContext.DataRow["propertyValue"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measureValue = this.TestContext.DataRow["measureValue"].ToString();
                string dimensionValue = this.TestContext.DataRow["dimensionValue"].ToString();

                string labelName = string.Empty;
                string fieldKpiTemplateName = string.Empty;
                string chartKpiTemplateName = string.Empty;
                string uniqueIdentifier = _helper.GenerateUniqueRandomNumber();

                labelName = $"KPI" + uniqueIdentifier;
                fieldKpiTemplateName = $"TestField" + uniqueIdentifier;
                chartKpiTemplateName = $"TestChart" + uniqueIdentifier;

                NavigateToInboxByGlobalSearch(function, inbox);
                ClearAbstractionData(WDAbstractions.KPIs.ToString());
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.SelectKPICreateTab("Global");
                _inboxKpisAction.ClickOnAddKPI();
                _inboxKpisAction.CreateKPIWithValueAndChart(labelName, fieldKpiTemplateName, propertyValue, chartKpiTemplateName, chartType, measureValue, dimensionValue);
                _inboxKpisAction.ClickOnSaveButton();
                _inboxKpisAction.VerifyKPIIsPresentOnCretedByMeTab(labelName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("KPIsTest")]
        [Description("Tests the Create functionality of the KPI From Created By Me Section;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"KPIs_482002.csv", "KPIs_482002#csv", DataAccessMethod.Sequential)]
        public void TC_482004_VerifyCreateKPIFromFromCreatedByMeSection()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string propertyValue = this.TestContext.DataRow["propertyValue"].ToString();
                string chartType = this.TestContext.DataRow["chartType"].ToString();
                string measureValue = this.TestContext.DataRow["measureValue"].ToString();
                string dimensionValue = this.TestContext.DataRow["dimensionValue"].ToString();

                string labelName = string.Empty;
                string fieldKpiTemplateName = string.Empty;
                string chartKpiTemplateName = string.Empty;
                string uniqueIdentifier = _helper.GenerateUniqueRandomNumber();

                labelName = $"KPI" + uniqueIdentifier;
                fieldKpiTemplateName = $"TestField" + uniqueIdentifier;
                chartKpiTemplateName = $"TestChart" + uniqueIdentifier;

                NavigateToInboxByGlobalSearch(function, inbox);
                ClearAbstractionData(WDAbstractions.KPIs.ToString());
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.SelectKPICreateTab("Created by me");
                _inboxKpisAction.ClickOnAddKPI();
                _inboxKpisAction.CreateKPIWithValueAndChart(labelName, fieldKpiTemplateName, propertyValue, chartKpiTemplateName, chartType, measureValue, dimensionValue);
                _inboxKpisAction.ClickOnSaveButton();
                _inboxKpisAction.VerifyKPIIsPresentOnCretedByMeTab(labelName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #endregion
    }
}