using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.Tests
{
    [TestClass]
    public class SmokeTest : BaseTest
    {
        #region TestMethods

        [TestMethod]
        [TestCategory("SanityTest")]
        [Description("Tests the following scenarios of application; 1)Navigate to inbox;2)Abstractions navigation;3)Apply Filter/Clear data in details tab;4)Search for the record;5)Navigating to Semantic Level of the Inbox;6)Navigate in Child abstractions tabs;7)Navigating to Home page;8)Logging out of application;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_78591.csv", "Smoke_78591#csv", DataAccessMethod.Sequential)]
        public void TC_78591_QuickApplicationTest()
        {
            string function = this.TestContext.DataRow["function"].ToString();
            string inbox = this.TestContext.DataRow["inbox"].ToString();
            try
            {
                
                string persona = this.TestContext.DataRow["persona"].ToString();
                string filterField = this.TestContext.DataRow["filterField"].ToString();
                string operatorValue = this.TestContext.DataRow["operatorValue"].ToString();
                string filterValue = this.TestContext.DataRow["filterValue"].ToString();
                string searchValue = this.TestContext.DataRow["searchValue"].ToString();
                string firstLevelChildInbox = this.TestContext.DataRow["firstLevelChildInbox"].ToString();

                //Step-1: Navigate to inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                LogInfo($"Step-1: Navigation to Function:{function}, Persona:{persona}, Inbox:{inbox} is successfull");

                //Step-2: Inbox level Abstraction Tabs navigation
                _inboxAction.NavigateToTabs();
                _inboxAction.SelectAbstraction(WDAbstractions.Details.ToString());
                LogInfo($"Step-2: Inbox level Abstraction Tabs navigation is successfull");

                //Step-3: Filter in the Details tab
                _inboxAction.SelectLabel("All");
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterField, operatorValue, filterValue);
                LogInfo($"Step-3: Filtering the data for Filter Field:{filterField}, Operator Value:{operatorValue}, Filter Value:{filterValue} is successfull");

                //Step-4: Tab navigation for filtered data
                _inboxAction.NavigateToTabs();
                _inboxAction.SelectAbstraction(WDAbstractions.Details.ToString());
                LogInfo($"Step-4: Tabs navigation for the filtered data is successfull");

                //Step-5: Clear the Applied filter
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ClickOnClearAllButton();
                _inboxFilterAction.ClickOnYes();
                LogInfo($"Step-5: Clearing the Applied filter is successfull");

                //Step-6: Search for the record
                _inboxAction.EnterSearchValueInGrid(searchValue);
                _inboxAction.ClickOnSearchButton();
                LogInfo($"Step-6: Search for the record is successfull");

                //Step-7: Clear Searched record
                _inboxAction.ClickOnSearchDeleteButton();
                LogInfo($"Step-7: Clearing the Searched record is successfull");

                //Step-8: Navigating to Semantic Level of the Inbox
                _inboxAction.SelectFirstInboxRecord();
                _childInboxAction.ClickOnChildInboxeItem(inbox,firstLevelChildInbox);
                LogInfo($"Step-8: Navigation to Semantic Level of the Inbox is successfull");

                //Step-9: Navigate in Child tabs
                _inboxAction.NavigateToTabs();
                LogInfo($"Step-9: Navigation in Child tabs is successfull");

                //Step-10: Navigating to Home page 
                _homeAction.ClickOnHomeButton();
                LogInfo($"Step-10: Navigation to home page is successfull");

                //Step-11: Logout
                LogoutWD();
                LogInfo($"Step-11: Logout is successfull");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the home option functionality of the application;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_58784.csv", "Smoke_58784#csv", DataAccessMethod.Sequential)]
        public void TC_58784_CheckingFunctionalityOfHomeButtonTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _homeAction.ClickOnHomeActionsButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [TestCategory("RegressionTest")]
        [Description("Tests the inbox abstractions tab switching in the application;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_58784.csv", "Smoke_58784#csv", DataAccessMethod.Sequential)]
        public void TC_63204_NavigateToTabOptionsInInboxPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.NavigateToTabs();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the submitting feedback functionlaity from the application;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        public void TC_95347_SubmittingFeedbackTest()
        {
            try
            {
                string feedbackDetails = string.Empty;
                feedbackDetails = $"Test Feedback details submitting on " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");

                _feedbackAction.ClickOnFeedbackIcon();
                _feedbackAction.SelectRating(4);
                _feedbackAction.EnterFeedbackTitle("Testing Feedback from Automation");
                _feedbackAction.EnterFeedbackDetails(feedbackDetails);
                _feedbackAction.SelectUserConsent();
                _feedbackAction.ClickOnSubmitButton();
                _feedbackAction.ClickOnOkButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #region ShowAndFeedback Scenarios

        /// <summary>
        /// Overall Testing of the application, following steps are covered
        /// 1) Details      -  a) Applying filter and saving the label
        /// 2) KPI          -  a) Configure with 2-Q(Chart and Value)
        ///                    b) Favorite and verify it
        /// 3) Charts       -  a) Create the chart and verify it
        /// 4) Story board  -  a) Create a Storyboard with all possible options(Import & create KPI's and charts)
        /// </summary>
        /// <param name="function"></param>
        /// <param name="persona"></param>
        /// <param name="inbox"></param>
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the following scenarios of application; 1)Navigate to inbox;2)Applying 1st Filter condition;3)Applying 2nd Filter condition;4)Saving the dashboard label;5)Configuring the KPI;6)Favoriting the KPI and verifying it in insights;7)Creating the Chart;8)Creating the Storyboard;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_113019.csv", "Smoke_113019#csv", DataAccessMethod.Sequential)]
        public void TC_113019_OverAllTest()
        {
            string function = this.TestContext.DataRow["function"].ToString();
            string inbox = this.TestContext.DataRow["inbox"].ToString();

            try
            {
               
                string persona = this.TestContext.DataRow["persona"].ToString();
                string filterValueOne = this.TestContext.DataRow["filterValueOne"].ToString();
                string kPIValue = this.TestContext.DataRow["kPIValue"].ToString();
                string chartMesaure = this.TestContext.DataRow["chartMesaure"].ToString();
                string chartDimension = this.TestContext.DataRow["chartDimension"].ToString();

                string labelName = string.Empty;
                string chartName = string.Empty;
                string chartType = _inboxChartsAction.GetChartType();
                string storyboardTitle = string.Empty;
                string uniqueIdentifier = _helper.GenerateUniqueRandomNumber();

                labelName = $"Label" + uniqueIdentifier;
                chartName = "Chart" + uniqueIdentifier;
                storyboardTitle = "Storyboard" + uniqueIdentifier;

                //Step-1: Navigate to inbox
                NavigateToInboxByGlobalSearch(function, inbox);
                LogInfo($"Step-1: Navigation to Function:{function}, Persona:{persona}, Inbox:{inbox} is successfull");

                //Step-2a: Applying 1st Filter condition in the Details tab
                _inboxAction.SelectLabel("All");
                _inboxAction.ClickOnFilterActionsButton();
                _inboxFilterAction.ApplyFilter(filterValueOne, "Equal", "All", 1);
                LogInfo($"Step-2a: Filtering the data for 1st Filter condition is successfull");

                //Step-3: Saving the dashboard label
                _inboxAction.ClickOnSaveLabel();
                _inboxAction.EnterLabelName(labelName);
                _inboxAction.ClickOnSaveLabelButton();
                LogInfo($"Step-3: Saving the dashboard label: {labelName} is successfull");

                //Step-4: Configuring the KPI and Step-5: Favoriting the KPI and verifying it in insights
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                _inboxKpisAction.SelectKPIToFavorites(labelName);
                LogInfo($"Step-5: Favoriting the KPI: {labelName} is successfull");
                ConfigureKPIWithValueAndChart(labelName, $"TV"+ uniqueIdentifier, kPIValue, chartName, chartType, chartMesaure, chartDimension);
                _inboxKpisAction.ClickOnSaveButton();
                LogInfo($"Step-4: Configuring the KPI: {labelName} is successfull");

                chartType = _inboxChartsAction.GetChartType();

                //Step-6: Creating the Chart
                CreateChart(chartName, function, inbox, chartMesaure, chartDimension, chartType);
                _inboxChartsAction.SelectChartToFavorite(chartName);
                LogInfo($"Step-6: Creating the Chart: {chartName} is successfull");

                //Step-7: Creating the Storyboard [(Create: Chart,KPI),(Import: Chart,KPI)]
                CreateStoryboard(storyboardTitle, function, inbox, chartName, labelName, chartMesaure, chartDimension);
                LogInfo($"Step-7: Creating the Storyboard: {storyboardTitle} is successfull");

                //Verifying the Favorite KPI and Chart
                NavigateToMyAppsInboxes(MyAppsOptions.Favorites.ToString());
                _homeAction.ClickOnKPIsAndCharts();
                _homeAction.VerifyInsightsKPI(labelName);
                _homeAction.VerifyInsightsChart(chartName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Clears the data from all the abstractions of the inbox;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_ClearData.csv", "Smoke_ClearData#csv", DataAccessMethod.Sequential)]
        public void TC_ClearAbstractionDataTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                ClearAllAbstractionData(function, inbox);
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the favoriting of inboxes in the personal landing page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_121262.csv", "Smoke_121262#csv", DataAccessMethod.Sequential)]
        public void TC_121262_FavoritingInboxesTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inboxNames = this.TestContext.DataRow["inboxNames"].ToString();

                _homeAction.ClickOnMyAppsTab(MyAppsOptions.Favorites.ToString());
                _homeAction.UnFavoriteInFavoritesTab();
                _homeAction.ClickOnFunction(function);
                _inboxAction.FavoriteInboxes(inboxNames);
                _homeAction.ClickOnFunction("Home");
                _homeAction.ClickOnMyAppsTab(MyAppsOptions.Favorites.ToString());
                _homeAction.VerifyFavorites(inboxNames);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the favoriting of inboxes in the personal landing page;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_261445.csv", "Smoke_261445#csv", DataAccessMethod.Sequential)]
        public void TC_261445_FunctionSpecificKPIChartsFavoritingTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                ClearAbstractionData(MyAppsOptions.Favorites.ToString());
                NavigateToInboxByGlobalSearch(function, inbox);

                //KPI Favoriting
                _inboxAction.SelectAbstraction(WDAbstractions.KPIs.ToString());
                string favoritedKPIName = _inboxKpisAction.SelectKPIToFavorite();

                //Chart Favoriting
                _inboxAction.SelectAbstraction(WDAbstractions.Charts.ToString());
                string favoritedChartName = _inboxChartsAction.SelectChartToFavorite();

                _homeAction.ClickOnFunction(function);

                //Verifying the KPIs and Charts favoriting
                _homeAction.VerifyInsightsKPI(favoritedKPIName);
                _homeAction.VerifyInsightsChart(favoritedChartName);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the navigation to specific abstraction via context menu option;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_261432_NavigationToSpecificAbstractionViaContextMenuOptionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string abstractions = this.TestContext.DataRow["abstractions"].ToString();

                _homeAction.ClickOnFunction(function);
                _inboxAction.SearchInbox(inbox);
                _inboxAction.NavigateToAbstractionsViaContextMenu(inbox, abstractions);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the suggest a feature functionlaity from the application;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        public void TC_251504_SuggestAFeatureTest()
        {
            try
            {
                _homeAction.ClickOnProfileImage();
                _homeAction.ClickOnHelp();
                _homeAction.ClickOnSuggestAFeature();
                _homeAction.EnterSuggestFeatureTitle("Testing Suggest a feature from Automation please ignore");
                _homeAction.EnterSuggestFeatureDescription(" Testing Suggest a feature from Automation please ignore");
                _homeAction.SelectCategoryValue();
                _homeAction.ClickOnSubmit();
                _homeAction.ClickOnOkButton();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the Clear Cache functionality In Profile Section;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        public void TC_251493_ClearCacheTest()
        {
            try
            {
                _homeAction.ClearCache();
                _homeAction.IsCacheClearedSuccessMsgPresent();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the Reload modules functionality In Profile Section;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        public void TC_251487_ReloadModulesTest()
        {
            try
            {
                _homeAction.ClickReloadModules();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests Verifying Connectivity in the Profile Section;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        public void TC_251503_VerifyingConnectivityInTheProfileSection()
        {
            try
            {
                //Clicking on profile image
                _homeAction.ClickOnProfileImage();

                //Clicking on connectivity tab
                _homeAction.ClickOnConnectivity();

                //Verifying Connectivity in the Profile Section
                _homeAction.VerifyConnectivityEnvironment(applicationEnvironment);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the Reload modules functionality;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_139188.csv", "Details_139188#csv", DataAccessMethod.Sequential)]
        public void TC_252379_ClearSearchedDataOnReloadTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                _inboxAction.SelectLabel("All");
                _inboxAction.EnterSearchValueInGrid("West");
                _inboxAction.ClickOnSearchButton();
                _inboxAction.ClickOnGlobalReload();
                _inboxAction.VerifySearchValueInGridIsEmpty();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Verify Inbox Name Search Functionality In Persona Search Box;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_261405_SearchInboxNameInPersonaSearchBoxTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();

                _homeAction.ClickOnFunction(function);
                _inboxAction.VerifySearchInboxResults("Sales");
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests Performing the actions from the Favorites inbox;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_261927.csv", "Smoke_261927#csv", DataAccessMethod.Sequential)]
        public void TC_261927_PerformingTheActionsFromTheFavoritesInbox()
        {
            try
            {
                string expectedActionPageTitle = this.TestContext.DataRow["expectedActionPageTitle"].ToString();

                //Navigation to Favorite Inbox page from Dashboard page
                _homeAction.ClickOnMyAppsTab(MyAppsOptions.Favorites.ToString());

                //Clicking action button in Favorite Inbox page
                _homeAction.ClickOnActionButton();

                //Entering text in action search field
                _homeAction.EnterTextForActionSearch(expectedActionPageTitle);
              
                //Selecting action name from the search list
                _homeAction.ClickOnSearchForActionName(expectedActionPageTitle);
              
                //Verify Confirmation popup or Action page title after user perform any action from action window. Confirmation pop up in Semantic view and Action window are same
                // Reusing existing method 
                _inboxAction.VerifyMasterActionConfirmationPopUpTextInSemanticView("This" +
                    " action is available only in West Digital - ShopFloor", expectedActionPageTitle);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the navigation to specific abstraction via child inbox's context menu option;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_261451_NavigationToSpecificAbstractionViaChildInboxContextMenuOptionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string childinbox = this.TestContext.DataRow["childinbox"].ToString();
                string abstractions = this.TestContext.DataRow["abstractions"].ToString();

                //1. Navigate to 'Sales Orders' inbox.
                NavigateToInboxByGlobalSearch(function, inbox);

                //2. Navigate to Semantic view page of first record.
                _inboxAction.SelectFirstInboxRecord();

                //3. Select first child inbox.
                _childInboxAction.ClickOnFirstChildInboxeItem(inbox, childinbox);

                //4. Navigate to all abstractions via context menu of selected child inbox.
                _inboxAction.NavigateToAbstractionsViaContextMenu(childinbox, abstractions);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the Inboxes And Functions Visibility;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_276610.csv", "Smoke_276610#csv", DataAccessMethod.Sequential)]
        public void TC_269851_InboxesAndFunctionsVisibilityTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();

                //1. Click on function (Sales)
                _homeAction.ClickOnFunction(function);

                //2. Verify visiblity of personas
                _homeAction.VerifyPersonasVisibility();

                //3. Click on first persona.
                //_homeAction.ClickOnFirstPersona("Sales");

                //4. Verify visibility of inboxes
                _homeAction.VerifyInboxesVisibility();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests Consistency in 360º View page;;")]
        [Owner("gaurav.waniexternal@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_113397.csv", "Smoke_113397#csv", DataAccessMethod.Sequential)]
        public void TC_286921_VerifyConsistencyIn360ºViewPageTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();

                //1. Navigate to 'Customers' inbox.
                NavigateToInboxByGlobalSearch(function, inbox);

                //2. Navigate to Semantic view page of first record.
                _inboxAction.SelectFirstInboxRecord();

                //3. Navigate to 360 view page.
                _inboxAction.NavigateTo360View();

                //4. Verify KPIs Visibility on 360 View Page.
                _inboxAction.VerifyKPIsVisibilityOnPage();

                //5. Verify KPIs Count on 360 View Page.
                _inboxAction.VerifyKPIsCountIn360ViewPage();

                //6. Navigate to 'Customers' inbox again.
                NavigateToInboxByGlobalSearch(function, inbox);

                //7. Navigate to Semantic view page of first record.
                _inboxAction.SelectFirstInboxRecord();

                //8.  Navigate again to 360 view page.
                _inboxAction.NavigateTo360View();

                //9. Verifying KPIs Visibility on 360 View Page.
                _inboxAction.VerifyKPIsVisibilityOnPage();

                //10. Verifying KPIs Count on 360 View Page should be correct.
                _inboxAction.VerifyKPIsCountIn360ViewPage();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests Toggling the context menu Functionality;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        public void TC_261329_TogglingTheContextMenu()
        {
            try
            {
                //Verifying Toggling functionality
                _homeAction.VerifyingTogglingFunctionality();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #region HR Tests

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Tests the creation of personal address in personal profile;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_78834.csv", "Smoke_78834#csv", DataAccessMethod.Sequential)]
        public void TC_73834_CreatingOfPersonalAddressTest()
        {
            try
            {
                string testUser = this.TestContext.DataRow["testUser"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string region = this.TestContext.DataRow["region"].ToString();
                string pincode = this.TestContext.DataRow["pincode"].ToString();

                string testUserPassword = string.Empty;
                string careOf = string.Empty;
                string addressFirstLine = string.Empty;
                string addressSecondLine = string.Empty;
                string TelephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                careOf = $"Careof{country}" + uniqueNumber;
                addressFirstLine = "AddressFirstline";
                addressSecondLine = "AddressSecondline";
                TelephoneNo = _helper.GenerateRandomDigits(10);

                LogInfo($"Country: {country},TestUserEmailID: {testUser},CareOf: {careOf},AddressFirstLine: {addressFirstLine},AddressSecondLine: {addressSecondLine}");

                if (testUser.ToLower().Contains("testuser"))
                {
                    testUserPassword = TestContext.Properties["TestUser1Password"].ToString();
                }
                else
                {
                    testUserPassword = TestContext.Properties["HRTestUsersPassword"].ToString();
                }

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile", "Address");
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateMasterActionImage();
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(3);
                _hrAddressAction.CreateAddress(careOf, addressFirstLine, addressSecondLine, region, pincode, TelephoneNo, country);
                WaitForMoment(1);
                _hrAddressAction.FilterDataBySearch(careOf);
                WaitForMoment(4);
                _hrAddressAction.VerifyPersonalAddressField(careOf);
                screenshotFileName = string.Empty;
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Logout from the current app instance
                LogoutWD();
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Description("Tests the creation of bank details in personal profile;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_78834.csv", "Smoke_78834#csv", DataAccessMethod.Sequential)]
        public void TC_73914_CreatingOfBankDetailsTest()
        {
            try
            {
                string testUser = this.TestContext.DataRow["testUser"].ToString();
                string country = this.TestContext.DataRow["country"].ToString();
                string iBAN = this.TestContext.DataRow["iBAN"].ToString();

                string testUserPassword = string.Empty;
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string amount = _helper.GenerateRandomDigits(2);
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                payeeName = $"Payeeof{country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(7);

                LogInfo($"Country: {country},TestUserEmailID: {testUser},PayeeName: {payeeName},IBAN: {iBAN},AccountNumber: {accountNumber}");

                if (testUser.ToLower().Contains("testuser"))
                {
                    testUserPassword = TestContext.Properties["TestUser1Password"].ToString();
                }
                else
                {
                    testUserPassword = TestContext.Properties["HRTestUsersPassword"].ToString();
                }

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                NavigateToInboxByGlobalSearch("Human Resources", "Personal Profile");
                WaitForMoment(2);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile","Banking");
                WaitForMoment(2);
                _childInboxAction.ClickOnCreateMasterActionImage();
                WaitForMoment(3);
                _childInboxAction.ClickOnCreateButton();
                WaitForMoment(8);
                _hrBankAction.CreateBankDetails(payeeName, iBAN, accountNumber, amount, country);
                WaitForMoment(2);
                _hrBankAction.VerifyBankField(payeeName);
                screenshotFileName = string.Empty;
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Logout from the current app instance
                LogoutWD();
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the login functionality of the application;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        public void TC_58773_CheckingLoginFunctionalityWithValidCredentialsTest()
        {
            try
            {
                LoginToWD(userName, password);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the logout functionality of the application;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        public void TC_251511_LogoutFunctionalityTest()
        {
            try
            {
                LogoutWD();
                //Once user logs out of application, it will take some time to relaunch
                WaitForMoment(5);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the visibility of User Confirmation message on every launch;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        public void TC_306501_VerifyUserConfirmationMessageTest()
        {
            try
            {
                // Logout from the application if user is already signed in
                LogoutWD();

                // Launching the App Instance
                LaunchApp();

                //Try to login again
                _loginAction.EnterUserName(userName);
                WaitForMoment(1);
                _loginAction.ClickOnNextButton();
                WaitForMoment(1);
                _loginAction.EnterPassword(password);
                WaitForMoment(1);
                _loginAction.ClickOnSignInButton();
                WaitForMoment(2);
                _loginAction.ClickOnYesButton();
                _session.Manage().Window.Maximize();
                LogInfo("Logging In to the application successfull.");
                WaitForMoment(2);
                _baseAction.WaitForLoadingToDisappear(LoadingText.Please.ToString());
                _baseAction.WaitForLoadingToDisappear(LoadingText.Authenticating.ToString());
                WaitForMoment(10);

                string appEnvironment = GetApplicationEnvironment(applicationEnvironment);
                //Verifying the User confirmation message in UAT since its diabled in Dev and Dvv
                if (appEnvironment.ToLower().Equals("uat"))
                {
                    _loginAction.VerifyingUserConfirmationMessage(true);
                }
                else
                {
                    _loginAction.VerifyingUserConfirmationMessage(false);
                }
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        #endregion

        #region Skipped Tests
        [TestMethod]
        [TestCategory("HRTest")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataRow("TEST_UX1@westpharma.com", "Germany")]             // Germany
        [DataRow("TEST_UX04@westpharma.com", "United Kingdom")]     // UK
        [DataRow("TEST_UX06@westpharma.com", "US Pennsylvania")]    // US
        [DataRow("TEST_UX08@westpharma.com", "India")]              // India
        [Ignore("HR Update Bank Details functionality is removed")]
        public void TC_118749_UpdateBankDetailsTest(string testUser, string country)
        {
            try
            {
                string testUserPassword = string.Empty;
                string payeeName = string.Empty;
                string accountNumber = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                payeeName = $"Payee of {country}" + uniqueNumber.ToString();
                accountNumber = _helper.GenerateRandomDigits(10);

                LogInfo($"TestUserEmailID: {testUser}");

                if (testUser.ToLower().Contains("testuser"))
                {
                    testUserPassword = TestContext.Properties["TestUser1Password"].ToString();
                }
                else
                {
                    testUserPassword = TestContext.Properties["HRTestUsersPassword"].ToString();
                }

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                _homeAction.ClickOnFunction("Human Resources");
                WaitForMoment(1);
                _homeAction.ClickOnPersona("Employee");
                WaitForMoment(1);
                _homeAction.ClickOnInboxesItem("Personal Profile");
                WaitForMoment(2);
                _homeAction.ClickOnRefresh();
                WaitForMoment(6);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxLabelButton("Related Items");
                WaitForMoment(3);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile","Banking");
                WaitForMoment(3);
                _hrBankAction.NavigateToUpdateBankDetailsPage(country);
                WaitForMoment(3);
                _hrBankAction.UpdateBankDetails(payeeName, accountNumber, country);
                WaitForMoment(3);
                _hrBankAction.FilterDataBySearch(payeeName);
                WaitForMoment(1);
                _hrBankAction.VerifyBankField(payeeName);
                _hrBankAction.VerifyBankField(accountNumber);
            }
            catch (Exception ex)
            {
                CaptureScreenShot(_session, TestContext.TestName);
                LogError($"{ex.Message} : {ex.StackTrace}");
                this.TestContext.AddResultFile(screenshotFileName);
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Logout from the current app instance
                LogoutWD();
            }
        }

        [TestMethod]
        [TestCategory("HRTest")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataRow("TEST_UX1@westpharma.com", "Germany")]             // Germany
        [DataRow("TEST_UX04@westpharma.com", "United Kingdom")]     // UK
        [DataRow("TEST_UX06@westpharma.com", "US Pennsylvania")]    // US
        [DataRow("TEST_UX08@westpharma.com", "India")]              // India
        [Ignore("HR Update PersonalAddress functionality is removed")]
        public void TC_77172_UpdatePersonalAddressTest(string testUser, string country)
        {
            try
            {
                string testUserPassword = string.Empty;
                string careOf = string.Empty;
                string telephoneNo = string.Empty;
                string uniqueNumber = _helper.GenerateUniqueRandomNumber();

                careOf = $"Care of {country}" + uniqueNumber.ToString();
                telephoneNo = _helper.GenerateRandomDigits(10);

                LogInfo($"TestUserEmailID: {testUser}");

                if (testUser.ToLower().Contains("testuser"))
                {
                    testUserPassword = TestContext.Properties["TestUser1Password"].ToString();
                }
                else
                {
                    testUserPassword = TestContext.Properties["HRTestUsersPassword"].ToString();
                }

                // Login with the test user account of that specific country
                LoginToWD(testUser, testUserPassword);

                _homeAction.ClickOnFunction("Human Resources");
                WaitForMoment(1);
                _homeAction.ClickOnPersona("Employee");
                WaitForMoment(1);
                _homeAction.ClickOnInboxesItem("Personal Profile");
                WaitForMoment(2);
                _homeAction.ClickOnRefresh();
                WaitForMoment(6);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxLabelButton("Related Items");
                WaitForMoment(3);
                _childInboxAction.ClickOnChildInboxeItem("Personal Profile","Address");
                WaitForMoment(3);
                _hrAddressAction.NavigateToUpdateAddressPage(country);
                WaitForMoment(3);
                _hrAddressAction.UpdateAddress(careOf, telephoneNo, country);
                WaitForMoment(3);
                _hrAddressAction.FilterDataBySearch(careOf);
                WaitForMoment(1);
                _hrAddressAction.VerifyPersonalAddressField(careOf);
                _hrAddressAction.VerifyPersonalAddressField(telephoneNo);
            }
            catch (Exception ex)
            {
                CaptureScreenShot(_session, TestContext.TestName);
                LogError($"{ex.Message} : {ex.StackTrace}");
                this.TestContext.AddResultFile(screenshotFileName);
                Assert.Fail(ex.Message);
            }
            finally
            {
                // Logout from the current app instance
                LogoutWD();
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the 2-level child inbox navigation;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_113397.csv", "Smoke_113397#csv", DataAccessMethod.Sequential)]
        [Ignore("Currently 2-level child inbox is not configured")]
        public void TC_113397_NavigatingToTwoLevelChildInboxesTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                string firstLevelChildInbox = this.TestContext.DataRow["firstLevelChildInbox"].ToString();
                string secondLevelChildInbox = this.TestContext.DataRow["secondLevelChildInbox"].ToString();

                NavigateToInboxByGlobalSearch(function, inbox);
                WaitForMoment(5);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(3);
                _childInboxAction.ClickOnChildInboxLabelButton("Related Items");
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem(inbox, firstLevelChildInbox);
                WaitForMoment(1);
                _childInboxAction.VerifyChildLevelNavigation(firstLevelChildInbox);
                WaitForMoment(5);
                _inboxAction.SelectFirstInboxRecord();
                WaitForMoment(3);
                _childInboxAction.ClickOnChildInboxLabelButton("Related Items");
                WaitForMoment(2);
                _childInboxAction.ClickOnChildInboxeItem(inbox, secondLevelChildInbox);
                WaitForMoment(1);
                _childInboxAction.VerifyChildLevelNavigation(secondLevelChildInbox);
                WaitForMoment(1);
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests the Verifying Last Sync time in Detail abstraction;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Details_91857.csv", "Details_91857#csv", DataAccessMethod.Sequential)]
        public void TC_255447_VerifyingLastSyncTimeInDetailAbstractionTest()
        {
            try
            {
                string function = this.TestContext.DataRow["function"].ToString();
                string inbox = this.TestContext.DataRow["inbox"].ToString();
                
                NavigateToInboxByGlobalSearch(function, inbox);
                //Click on Refresh 
                _homeAction.ClickOnRefresh();
                //verifying Last sync time in Detail abstraction
                _inboxAction.VerifyLastSyncedTime();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Verify Add Category Tag For Actions;;")]
        [Owner("gaurav.waniEXTERNAL@westpharma.com")]
        public void TC_291698_VerifyAddCategoryTagForActions()
        {
            try
            {
                //1. Click on Action Button.
                _homeAction.ClickOnActionButton();

                //2. Verify Action Tags functionality on Actions pop-up.
                _homeAction.VerifyActionTagsOperations();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }
     
        [TestMethod]
        [TestCategory("AppsTest")]
        [Description("Tests the navigation to all apps in Apps function;;")]
        [Owner("vishnuprakash.muniswamy@westpharma.com")]
        public void TC_286838_VerifyingMyAppsTest()
        {
            try
            {
                string function = "Apps";

                _myAppsAction.SelectFunction(function);
                _myAppsAction.NavigateToEachApp();
            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests Verify navigation to Terms of Use page;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"Smoke_306487.csv", "Smoke_306487#csv", DataAccessMethod.Sequential)]
        public void TC_306487_VerifyNavigationToTermsOfUsePage()
        {
            try
            {
                string expectedTermsOfUsePageTitle = this.TestContext.DataRow["expectedTermsOfUsePageTitle"].ToString();
                //Clicking on profile image
                _homeAction.ClickOnProfileImage();

                //Clicking on Terms of Use link
                _homeAction.ClickOnTermsOfLink();

                //Verify Terms of Use Title
                _homeAction.VerifyTermsOfUsePageTitle(expectedTermsOfUsePageTitle);

            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        [Description("Tests Verify Submit Suggestion Loader;;")]
        [Owner("Kruthi.MadapurVasudevaReddyEXTERNAL@westpharma.com")]        
        public void TC_270783_VerifySubmitSuggestionLoader()
        {
            try
            {
                //Click on Help and click on Submit Suggestion
                _homeAction.ClickOnProfileImage();
                _homeAction.ClickOnHelp();
                _homeAction.ClickOnSuggestAFeature();

                //Submit the suggestion without entering Title and description
                _homeAction.ClickOnSubmit();
                _homeAction.ClickOnOkButton();

                //Verify Submit Suggestion Loader should not be displayed after Submit the suggestion without entering Title and description
                _homeAction.IsSuggestionLoaderPresent();


            }
            catch (Exception ex)
            {
                CaptureLogs(ex);
                Assert.Fail(ex.Message);
            }
        }

        #endregion

        #endregion
    }
}
