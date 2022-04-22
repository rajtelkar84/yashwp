using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestCategory("Details")]
    [TestClass]
    public class DetailsTest : BaseTest
    {
        #region TestMethods

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the page navigation from home to inbox page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58781.csv", "Details_58781#csv", DataAccessMethod.Sequential)]
        public void TC_58781_CheckingInboxPageNavigationFromHomePageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _homeAction.ClickOnHomeButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the inbox page navigation from persona landing page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58781.csv", "Details_58781#csv", DataAccessMethod.Sequential)]
        public void TC_58783_CheckingInboxPageNavigationFromInboxesPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the filter conditions in the details page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58785.csv", "Details_58785#csv", DataAccessMethod.Sequential)]
        public void TC_58785_CheckingFilterFunctionality()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterField, operatorValue, filterValue);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the navigation to semantic inbox from parent inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58790.csv", "Details_58790#csv", DataAccessMethod.Sequential)]
        public void TC_58790_CheckingNavigationToSemanticInboxTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectFirstInboxRecord();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the navigation to child inbox from parent inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58790.csv", "Details_58790#csv", DataAccessMethod.Sequential)]
        public void TC_58793_CheckingNavigationToChildInboxTest()
        {
            try
            {
                string function = string.Empty;
                string inbox = string.Empty;
                string childInboxLabel = string.Empty;

                if (applicationName.ToLower().Contains(AppSystem.quality.ToString()))
                {
                    function = TestContext.Properties["BatchFunction"].ToString();
                    inbox = TestContext.Properties["BatchInbox"].ToString();
                    childInboxLabel = TestContext.Properties["ChildInbox"].ToString();
                }
                else
                {
                    function = this.TestContext.DataRow["function"].ToString();
                    inbox = this.TestContext.DataRow["inbox"].ToString();
                    childInboxLabel = this.TestContext.DataRow["childInboxLabel"].ToString();
                }

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectFirstInboxRecord();
                _childInboxAction.ClickOnFirstChildInboxeItem(inbox,childInboxLabel);
                _inboxAction.VerifyInboxName(childInboxLabel);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [TestCategory("RegressionTest")]
        [Description("Tests the switching to different labels in the inbox details page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58790.csv", "Details_58790#csv", DataAccessMethod.Sequential)]
        public void TC_74638_NavigateToEachLabelsInInboxPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.NavigateToLabels();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the creating of new dashboard label in the inbox details page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_91857.csv", "Details_91857#csv", DataAccessMethod.Sequential)]
        public void TC_91857_CreatingNewLabelInInboxDetailsPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                string labelName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterField, operatorValue, filterValue);
                _inboxAction.ClickOnSaveLabel();
                _inboxAction.EnterLabelName(labelName);
                _inboxAction.ClickOnSaveLabelButton();
                _inboxAction.VerifyLabel(labelName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the page navigation options in details page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58781.csv", "Details_58781#csv", DataAccessMethod.Sequential)]
        public void TC_91866_PageNavigationInInboxDetailsPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.NavigateInForwardDirection(3);
                _inboxAction.NavigateInBackwardDirection(2);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the clearing of applied filters in details page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_91857.csv", "Details_91857#csv", DataAccessMethod.Sequential)]
        public void TC_91856_ClearingFilterAppliedInboxDetailsPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterField, operatorValue, filterValue);
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ClickOnClearAllButton();
                _inboxFilterAction.ClickOnYes();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the global search of inbox functionality;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_124011.csv", "Details_124011#csv", DataAccessMethod.Sequential)]
        public void TC_124011_CheckingGlobalSearchFunctionalityTest()
        {
            try
            {
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string searchValue = this.TestContext.DataRow["searchValue"].ToString();

                _homeAction.GlobalSearchByInboxNameInHomePage(inbox, searchValue);
                _inboxAction.VerifyInboxName(inbox);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the sort functionality in the inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_138489.csv", "Details_138489#csv", DataAccessMethod.Sequential)]
        public void TC_138489_SortFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string column = this.TestContext.DataRow["column"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SortDataBy(column, SortOrder.Descending);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the detailed view of the row data using expand record option;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_139188.csv", "Details_139188#csv", DataAccessMethod.Sequential)]
        public void TC_139597_ExpandRecordsOfDataTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                List<string> rowData;

                NavigateToInboxByGlobalSearch(function, inbox);
                rowData=_inboxAction.GetDataByRowInDetails(1);
                _inboxAction.SelectDetailAction("Expand");
                _inboxAction.VerifyHeaderDataFromExpandView(rowData);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Grid Refresh functionality in the inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58781.csv", "Details_58781#csv", DataAccessMethod.Sequential)]
        public void TC_179500_GridRefreshTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.ClickOnGlobalReload();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Global Reload functionality across abstractions;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_91857.csv", "Details_91857#csv", DataAccessMethod.Sequential)]
        public void TC_184506_GlobalReloadTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilterUpdated(filterField, operatorValue, filterValue);
                _homeAction.ClickOnRefresh();
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.VerifyAppliedFilterExists($"{filterField}+{operatorValue}+{filterValue}",false);
                _inboxFilterAction.CloseFilterWindow();
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _homeAction.ClickOnRefresh();
                _inboxAction.SelectAbstraction(WDAbstractions.Charts.ToString());
                _homeAction.ClickOnRefresh();
                _inboxAction.SelectAbstraction(WDAbstractions.Storyboards.ToString());
                _homeAction.ClickOnRefresh();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Grid Search functionality in the inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_188252.csv", "Details_188252#csv", DataAccessMethod.Sequential)]
        public void TC_188252_GridSearchTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string searchOption = this.TestContext.DataRow["searchOption"].ToString();
                string searchValue = this.TestContext.DataRow["searchValue"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                int inboxDataCount = _inboxAction.GetInboxDataCount();
                _inboxAction.SelectSearchOption(searchOption);
                _inboxAction.EnterSearchValueInGrid(searchValue);
                _inboxAction.ClickOnSearchButton();
                _inboxAction.VerifyInboxDataCount(inboxDataCount,false);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Batch Action functionality in the inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_220904.csv", "Details_220904#csv", DataAccessMethod.Sequential)]
        public void TC_220904_BatchActionTest()
        {
            try
            {
                string function = string.Empty;
                string inbox = string.Empty;

                if (applicationName.ToLower().Contains(AppSystem.quality.ToString()))
                {
                    function = TestContext.Properties["BatchFunction"].ToString();
                    inbox = TestContext.Properties["BatchInbox"].ToString();
                }
               else
                {
                    function = this.TestContext.DataRow["function"].ToString();
                    inbox = this.TestContext.DataRow["inbox"].ToString();
                }

                NavigateToInboxByInboxSearchOption(function, inbox);
                _inboxAction.SelectRecords(inbox,2);
                _inboxAction.ClickOnCreateMasterAction();
                _inboxAction.SelectMasterActionOption();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Group Filter functionality in the inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_e.csv", "Details_221099#csv", DataAccessMethod.Sequential)]
        public void TC_221099_GroupFilterTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                string filterFieldOne = this.TestContext.DataRow["filterFieldOne"].ToString();
                string operatorValueOne = this.TestContext.DataRow["operatorValueOne"].ToString();
                string filterValueOne = this.TestContext.DataRow["filterValueOne"].ToString();

                string filterFieldTwo = this.TestContext.DataRow["filterFieldTwo"].ToString();
                string operatorValueTwo = this.TestContext.DataRow["operatorValueTwo"].ToString();
                string filterValueTwo = this.TestContext.DataRow["filterValueTwo"].ToString();

                string filterFieldThree = this.TestContext.DataRow["filterFieldThree"].ToString();
                string operatorValueThree = this.TestContext.DataRow["operatorValueThree"].ToString();
                string filterValueThree = this.TestContext.DataRow["filterValueThree"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
               
                //Applying Filter-1
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterFieldOne, operatorValueOne, filterValueOne);

                //Applying Filter-2
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterFieldTwo, operatorValueTwo, filterValueTwo);

                //Applying Filter-3
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterFieldThree, operatorValueThree, filterValueThree);
                int inboxDataCount = _inboxAction.GetInboxDataCount();

                //Open the Filter window and apply the group filtering
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ClickOnEditFilterButton();
                _inboxFilterAction.FilterConjunction("or");
                _inboxFilterAction.GroupFilterConditions(2);
                _inboxFilterAction.ClickOnGroupFilterButton();
                _inboxFilterAction.ClickOnApplyButton();
                _homeAction.VerifyInvisibilityOfErrorMessages();

                //Verify the data count after group filtering
                _inboxAction.VerifyInboxDataCount(inboxDataCount, false);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Export Data functionality in the inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_188252.csv", "Details_188252#csv", DataAccessMethod.Sequential)]
        public void TC_251531_ExportDataTest()
        {
            try
            {
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string exportedExcelPath = Path.Combine(logsFolderPath, $"SalesData{uniqueNumber}.xlsx");

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Export to Excel");
                _inboxAction.ExportRecords("Visible");
                WaitForMoment(15);
                _inboxAction.HandleSaveDailog(exportedExcelPath);
                _inboxAction.VerifyFileExists(exportedExcelPath);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Multicolumn sort functionality in the inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_274763.csv", "Details_274763#csv", DataAccessMethod.Sequential)]
        public void TC_274763_MultipleColumnSortFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string columns = this.TestContext.DataRow["columns"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SortDataBy(columns, SortOrder.Ascending);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Records per page in the inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_138489.csv", "Details_138489#csv", DataAccessMethod.Sequential)]
        public void TC_251607_VerifyRecordsPerPageFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.VerifyRecordsPerPage();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Manage Labels functionality;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_251584.csv", "Details_251584#csv", DataAccessMethod.Sequential)]
        public void TC_251584_ManageLabelsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectDetailsMoreOption("Manage Labels");
                _inboxAction.VerifyManageLabelsFunctionality();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Page Navigation by entering page number inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_138489.csv", "Details_138489#csv", DataAccessMethod.Sequential)]
        public void TC_251606_VerifyRecordsPerPageFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox, false);
                _inboxAction.EnterPageNumber("5");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the delete functionality in Sort;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_138489.csv", "Details_138489#csv", DataAccessMethod.Sequential)]
        public void TC_279233_VerifyDeleteFunctionalityInSortTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string column = this.TestContext.DataRow["column"].ToString();

                //1. Navigate to "Sales Order" inbox.
                NavigateToInboxByGlobalSearch(function, inbox);

                //2. Apply Sort on column.
                _inboxAction.SortDataBy(column, SortOrder.Descending);

                //3. Verify Delete Functionality In Sort.
                _inboxAction.VerifyDeleteSortFunctionality();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the date filter using Dynamic Between operator in the details page;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_254759.csv", "Details_254759#csv", DataAccessMethod.Sequential)]
        public void TC_254759_VerifyDatefilterFunctionalityUsingDynamicBetweenOperator()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
               
                //1. Navigate to inbox 'Sales Orders'.
                NavigateToInboxByGlobalSearch(function, inbox);

                //2. Select dashboard label 'All'.
                _inboxAction.SelectLabel("All");

                //3. Click On Filter Action Button.
                _inboxAction.ClickOnFilterActionsButton();

                //4. Verify Dynamic Between Date Filter Functionality.
                _inboxFilterAction.VerifyDynamicBetweenDateFilter(filterField, operatorValue);

                //5. Verify filtered data availability in inbox.
                _inboxAction.VerifyInboxDataAvalability();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Manage Grid Columns Functionality;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_138489.csv", "Details_138489#csv", DataAccessMethod.Sequential)]
        public void TC_251582_VerifyManageGridColumnsFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string column = this.TestContext.DataRow["column"].ToString();

                //1. Navigate to "Sales Order" inbox.
                NavigateToInboxByGlobalSearch(function, inbox);

                //2. Select 'Manage Grid Columns' from More option.
                _inboxAction.SelectDetailsMoreOption("Manage Grid Columns");

                //3. Verify the Manage Grid Column functionality.
                _inboxAction.VerifyManageGridColumnsFunctionality("Sales Document ID", "Global Net Value");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Manage Grid Columns Reset Functionality;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_138489.csv", "Details_138489#csv", DataAccessMethod.Sequential)]
        public void TC_275896_VerifyResetFunctionalityInManageGridColumnsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string column = this.TestContext.DataRow["column"].ToString();

                //1. Navigate to "Sales Order" inbox.
                NavigateToInboxByGlobalSearch(function, inbox);

                //2. Select 'Manage Grid Columns' from More option again.
                _inboxAction.SelectDetailsMoreOption("Manage Grid Columns");

                //3. Verify Reset functionality in Manage Grid Column.
                _inboxAction.VerifyResetFunctionalityOfManageGridColumns();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Master Action in Semantic View page;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Manufacturing_276786.csv", "Manufacturing_276786#csv", DataAccessMethod.Sequential)]
        public void TC_260659_VerifyingMasterActionInSemanticViewTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inboxNames"].ToString();
                string action = string.Empty;

                //Navigate to any inbox
                NavigateToInboxByGlobalSearch(function, inbox);

                //Search for a record in grid.
                //_inboxAction.EnterSearchValueInGrid("4500000000");
                //_inboxAction.ClickOnSearchButton();

                //Navigate to Semantic view of first record in Details abstraction.
                _inboxAction.SelectFirstInboxRecord();

                //Click on Master Action button.
                _inboxAction.ClickOnMasterActionInSemanticView();

                //Click on any action option
                _inboxAction.SelectMasterActionOption();

                //Verify Confirmation popup and text after user perform any master action.
                _inboxAction.VerifyMasterActionConfirmationPopUpTextInSemanticView("action" +
                    " is not configured", action);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests visibility of filter count added when filter is applied by user;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58785.csv", "Details_58785#csv", DataAccessMethod.Sequential)]
        public void TC_255005_VerifyFilterCountAddedWhenFilterIsAppliedTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                string labelName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueNumber.ToString();

                //1. Navigate to "Sales Order" inbox.
                NavigateToInboxByGlobalSearch(function, inbox);
                //2. Select 'All' dashboad label.
                _inboxAction.SelectLabel("All");

                //3. Click Filter action button.
                _inboxAction.ClickOnFilterActionsButton();

                //4. Enter filter field, operatorValue and filterValue.
                _inboxFilterAction.ApplyFilter(filterField, operatorValue, filterValue);

                //5. Verify filer count on filter icon.
                _inboxAction.VerifyFilterCount("1");

                //6. Save dashboard label.
                _inboxAction.ClickOnSaveLabel();
                _inboxAction.EnterLabelName(labelName);
                _inboxAction.ClickOnSaveLabelButton();
               
                //7. Verify filter count disappeared after saving dashboard label.
                _inboxAction.VerifyFilterCountDisappearAfterSavingLabel();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the hyperlink functionality in semantic page;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58790.csv", "Details_58790#csv", DataAccessMethod.Sequential)]
        public void TC_261453_VerifyHyperlinkNavigationInSemancticPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                //1. Navigate to "Sales Order" inbox and navigate to 'All' label.
                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");

                //2. Search for a record in grid.
                _inboxAction.EnterSearchValueInGrid("6000008870");
                _inboxAction.ClickOnSearchButton();

                //3. Navigate to semanic page of searched record.
                _inboxAction.SelectFirstInboxRecord();

                //4. Verify Hyperlink functionality in semantic veiw page.
                _inboxAction.VerifyHyperlinkNavigationFunctionality("50010", "Customers");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests Verify Template for no data and broken configuration for Semantic Views;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_91857.csv", "Details_91857#csv", DataAccessMethod.Sequential)]
        public void TC_254086_VerifyTemplateNoDataAndBrokenConfigurationForSemanticViewsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                //Navigate to any inbox
                NavigateToInboxByGlobalSearch(function, inbox);

                //Navigate to Semantic view of first record in Details abstraction.
                _inboxAction.SelectFirstInboxRecord();

                //verifying error message, empty template, errorlabel, messages in semantic view
                _baseAction.VerifyInvisibilityOfErrorMessages();


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests Verify insights in Details abstractions;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_91857.csv", "Details_91857#csv", DataAccessMethod.Sequential)]
        public void TC_293669_VerifyInsightsInDetailsAbstractionsTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);

                //Verify Insight icon displayed
                _inboxAction.InsightIconDisplayed();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }      

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests Verify whether User should be view details button in expand card;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_259431.csv", "Details_259431#csv", DataAccessMethod.Sequential)]
        public void TC_259431_VerifyWhetherUserShouldBeViewDetailsButtonInExpandCardTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                //Navigate to any inbox
                NavigateToInboxByGlobalSearch(function, inbox);

                //Navigate user to semantic view from expand card
                _inboxAction.SelectDetailAction("Expand");

                //Click on Detail view button in expand card
                _inboxAction.ClickOnViewDetailInExpandCard();

                //Click on Master Action button.on top right corner
                _inboxAction.ClickOnMasterActionInSemanticView();

                //Click on Recquisition status option
                _inboxAction.ClickOnActionOptions("Requisition Status");
                WaitForMoment(4);

                //Verifying Application should be navigate to  Requisition status  Page
                _inboxAction.VerifyPageTitle("Requisition Status");
             
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests Verify Clear All is disabled when there is no sort applied;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_138489.csv", "Details_138489#csv", DataAccessMethod.Sequential)]
        public void TC_278876_VerifyClearAllIsDisabledWhenThereIsNoSortAppliedTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string column = this.TestContext.DataRow["column"].ToString();

                //1. Navigate to "Sales Order" inbox.
                //2. Apply Sort on column.
                //3.Verify Delete Functionality In Sort.
                TC_279233_VerifyDeleteFunctionalityInSortTest();

                //Verify ClearAll button Disabled Functionality In Sort.
                _inboxAction.ClearAllButtonDisabled();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests Verifying Insight functionality in detail abstraction;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_91857.csv", "Details_91857#csv", DataAccessMethod.Sequential)]
        public void TC_301650_VerifyInsightFunctionalityInDetailAbstractionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);

                //Verify Insight icon displayed
                _inboxAction.InsightIconDisplayed();

                //On Clicking on Insight Icon, verify KPI detailsshould be displayed Under Insight label with Zoom icon and Close icon. 
                _inboxAction.VerifyInsightsLabelsDisplayed();

                //On Clicking on Zoom icon,KPIs Should be displayed in expanded view
                _inboxAction.VerifyInsightZoomFunctionality();

                //On Clicking on Close icon, Close the Insight 
                _inboxAction.VerifyInsightCloseFunctionality();

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the validation on empty filter condition in the details page;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_276939.csv", "Details_276939#csv", DataAccessMethod.Sequential)]
        public void TC_276939_CheckingValidationOnEmptyFilterCondition()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string expectedPopUpMessage = "Item is empty, please add correct details";

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ClickOnAddFilterButton();
                _inboxFilterAction.ClickOnApplyFilterButton();
                _inboxFilterAction.VerifyEmptyFilterPopUpTextInDetailsAbstraction(expectedPopUpMessage);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Recent Filters Section In Filter Page;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_58785.csv", "Details_58785#csv", DataAccessMethod.Sequential)]
        public void TC_448942_ChekingRecentFiltersSectionInFilterPage()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();

                string labelName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterField, operatorValue, filterValue);
                _inboxAction.ClickOnSaveLabel();
                _inboxAction.EnterLabelName(labelName);
                _inboxAction.ClickOnSaveLabelButton();
                _inboxAction.VerifyLabel(labelName);
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.VerifyRecentFiltersTitle();
                _inboxFilterAction.VerifyRecentFiltersDisplayed();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Tests the Edit Functionality of Recent Filters;;")]
        [Owner("neha.gawandeexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_448965.csv", "Details_448965#csv", DataAccessMethod.Sequential)]
        public void TC_448965_AutomationOnVerifyEditFunctionalityOfRecentFilters()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();
                string updatedFilterValue = this.TestContext.DataRow["updatedFilterValue"].ToString(); 

                string labelName = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueNumber.ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterField, operatorValue, filterValue);
                _inboxAction.ClickOnSaveLabel();
                _inboxAction.EnterLabelName(labelName);
                _inboxAction.ClickOnSaveLabelButton();
                _inboxAction.VerifyLabel(labelName);
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.VerifyRecentFiltersTitle();
                _inboxFilterAction.VerifyRecentFiltersDisplayed();
                _inboxFilterAction.ClickOnRecentFilterIcon();
                _inboxFilterAction.EditRecentFilter(filterField, operatorValue, updatedFilterValue);
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.VerifyActiveFiltersTitleAndActiveFiltersDisplayed();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the Quick Filter functionality;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_454860.csv", "Details_454860#csv", DataAccessMethod.Sequential)]
        public void TC_454860_QuickFilterTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                //Navigation to Inbox page from Dashboard page
                NavigateToInboxByGlobalSearch(function, inbox);

                bool isQuickFilterPresent = _inboxAction.IsQuickFilterOptionPresent();

                int inboxDataCount = _inboxAction.GetInboxDataCount();

                if (isQuickFilterPresent)
                {
                    _inboxAction.ApplyQuickFilters();
                }
               
                _inboxAction.VerifyInboxDataCount(inboxDataCount, false);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Test to verify Filter arrow dropdown after any filters applied;;")]
        [Owner("girishwar.patilexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_475966.csv", "Details_475966#csv", DataAccessMethod.Sequential)]
        public void TC_475966_VerifyFilterArrowDropdownAfterAnyFiltersAppliedTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string filterField = this.TestContext.DataRow["filter field"].ToString();
                string filterOperator = this.TestContext.DataRow["operator"].ToString();
                string filterValue = this.TestContext.DataRow["filter value"].ToString();

                NavigateToInboxByInboxSearchOption(function, inbox);

                _inboxAction.VerifyCommonElementsOnInboxPage(inbox);
                _inboxAction.VerifyAndApplyFilter(filterField, filterOperator, filterValue);
                _inboxAction.VerifyFilterArrowDropdownAndActiveFilter(filterField, filterOperator, filterValue);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Test to verify Filter arrow drop down if no active filters applied;;")]
        [Owner("girishwar.patilexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_475954.csv", "Details_475954#csv", DataAccessMethod.Sequential)]
        public void TC_475954_VerifyFilterArrowDropdownIfNoActiveFiltersAppliedTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByInboxSearchOption(function, inbox);

                _inboxAction.VerifyCommonElementsOnInboxPage(inbox);
                _inboxAction.VerifyFilterArrowDropdownWithoutActiveFilter();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Test to verify Export Visible Records functionality;;")]
        [Owner("girishwar.patilexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_475966.csv", "Details_475966#csv", DataAccessMethod.Sequential)]
        public void TC_290407_VerifyExportVisibleRecordsFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByInboxSearchOption(function, inbox);
                _inboxAction.VerifyExportVisibleRecordsFunctionality();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Test to verify Export All Records functionality;;")]
        [Owner("girishwar.patilexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_475966.csv", "Details_475966#csv", DataAccessMethod.Sequential)]
        public void TC_290433_VerifyExportAllRecordsFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByInboxSearchOption(function, inbox);
                _inboxAction.VerifyExportAllRecordsFunctionality();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Test to verify Export Records functionality;;")]
        [Owner("girishwar.patilexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_475966.csv", "Details_475966#csv", DataAccessMethod.Sequential)]
        public void TC_290437_VerifyExportRecordsFunctionalityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByInboxSearchOption(function, inbox);
                _inboxAction.VerifyExportRecordsFunctionality();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("DetailsTest")]
        [Description("Test to verify Copy in Details View and Semantic View;;")]
        [Owner("girishwar.patilexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_475966.csv", "Details_475966#csv", DataAccessMethod.Sequential)]
        public void TC_293401_VerifyCopyInDetailsAndSemanticViewTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByInboxSearchOption(function, inbox);
                _inboxAction.VerifyCopyInDetailsViewAndSemanticView();
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
