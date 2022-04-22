using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class HomeAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly HomePage _pageInstance;
        protected WebDriverWait wait;

        public HomeAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new HomePage(_session);
        }
        public void ClickOnProfileImage()
        {
            WindowsElement navigationBar = _pageInstance.NavigationBar;
            int navigationBarHeight = navigationBar.Location.Y;
            int navigationBarWidth = navigationBar.Size.Width;

            IList<WindowsElement> navigationBarIcons = _pageInstance.NavigationBarIcons;
            int navigationBarIconsCount = navigationBarIcons.Count;
            if (navigationBarIconsCount > 0)
            {
                //Get the last Icon position
                WindowsElement lastIcon = navigationBarIcons[navigationBarIconsCount - 1];
                int lastIconXAxisPosition = lastIcon.Location.X;

                //Predicit the profile option position
                int differenceInXLength = (navigationBarWidth - lastIconXAxisPosition) / 2;

                WaitForMoment(2);
                _mouseActions.MoveToElement(navigationBar, lastIconXAxisPosition + differenceInXLength + 20, navigationBarHeight / 2);
                _mouseActions.Click().Build().Perform();
            }
            else
            {
                LogInfo($"No icons found on the Navigation bar, icons count : {navigationBarIconsCount}");
            }
        }
        public void ClickOnLogoutButton()
        {
            WaitForMoment(2);
            _pageInstance.LogoutButton.Click();
            WaitForMoment(1);
            _pageInstance.ConfirmationYesButton.Click();
            WaitForMoment(1);
            WaitForLoadingToDisappear(LoadingText.Logging.ToString());
        }

        public Boolean LoggedinUser(string loggedInUserName)
        {
            int count = _pageInstance.LoggedInUser(loggedInUserName).Count;
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void ClickOnFunction(string function)
        {
            WaitForMoment(2);
            int errorCount = 0;
            do
            {
                try
                {
                    _pageInstance.SelectFunction(function).Click();
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                    errorCount++;
                    if (errorCount == 3)
                    {
                        throw new Exception(ex.Message);
                    }
                    LogInfo($"Selecting the function {function}, attempt: {errorCount}");
                    WaitForMoment(1);
                }
            } while (errorCount != 0 && errorCount < 3);
        }
        public void ClickOnPersona(string persona)
        {
            WaitForMoment(1);

            if (!persona.Equals("Process Order Management"))
            {
                _pageInstance.SelectPersona(persona).Click();
            }
        }
        public void ClickOnMyAppsTab(string tabName)
        {
            _pageInstance.SelectMyAppsTab(tabName).Click();
        }
        public void ClickOnBackButton()
        {
            _pageInstance.BackButton.Click();
        }
        public bool IsIGlobalSearchImagePresent()
        {
            int count = _pageInstance.GlobalSearchImage.Count;
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public WindowsElement GetFunction(string function)
        {
            return _pageInstance.SelectFunction(function);
        }
        public void ClickOnCloseApplication()
        {
            _session.Close();
            HandleApplicationClosePopUp();
        }
        public void ScrollVerticaly(int offsetX, int offsetY)
        {
            WindowsElement verticalScrollBar = _pageInstance.VerticalScrollBar;
            _touchScreen.Scroll(verticalScrollBar.Coordinates, offsetX, offsetY);
        }
        public void ClickOnHomeActionsButton()
        {
            _pageInstance.HomeImage[0].Click();
        }
        public void SelectMyAppsOption(string myAppsInbox)
        {
            MenuActions("open");
            WaitForMoment(1);
            _pageInstance.SelectMyAppsTab(myAppsInbox).Click();
        }
        public void ClickOnKPIsAndCharts()
        {
            _pageInstance.KPIsAndCharts.Click();
        }
        public void VerifyInsightsKPI(string labelName)
        {
            //To Collapse the Menu/Inboxes Tab
            MenuActions();

            WaitForLoadingToDisappear();
            IList<WindowsElement> searchingLabels = _pageInstance.VerifyInsightsKPI(labelName);
            if (searchingLabels.Count == 0)
            {
                LogInfo($"KPI with name: {labelName} is not present in the Insights page");
                Assert.Fail($"KPI with name: {labelName} is not present in the Insights page");
            }
        }
        public void VerifyInsightsChart(string chartName)
        {
            //To Collapse the Menu/Inboxes Tab
            MenuActions();

            WaitForLoadingToDisappear();
            IList<WindowsElement> searchingLabels = _pageInstance.VerifyInsightsKPI(chartName);
            if (searchingLabels.Count == 0)
            {
                LogInfo($"Chart with name: {chartName} is not present in the Insights page");
                Assert.Fail($"Chart with name: {chartName} is not present in the Insights page");
            }
        }
        public void VerifyInsightsKPIsCharts(bool isExpextedPresent = false)
        {
            IList<WindowsElement> kPICharts = _pageInstance.GetAllChartsKPIsByFavoriteIcon;
            bool isActualKPIsCharsPresent = kPICharts.Count > 0;

            if (isExpextedPresent)
            {
                Assert.AreEqual(isExpextedPresent, isActualKPIsCharsPresent, $"KPIs/Charts is not present in the current page");
            }
            else
            {
                Assert.AreEqual(isExpextedPresent, isActualKPIsCharsPresent, $"KPIs/Charts is present in the current page even after unfavoriting operation");
            }
        }
        public void VerifyFavorites(string inboxesName)
        {
            WaitForMoment(2);
            List<string> inboxesList = inboxesName.Split(',').ToList();
            foreach (var inboxName in inboxesList)
            {
                IList<WindowsElement> expectedInbox = _pageInstance.GetInboxesName(inboxName);
                if (expectedInbox.Count == 0)
                {
                    LogInfo($"Inbox with name: {inboxName} is not present in the MyApps Favorite's page");
                    Assert.Fail($"Inbox with name: {inboxName} is not present in the MyApps Favorite's page");
                }
            }
        }
        public void SelectInboxesForFavoriting(string inboxesName)
        {
            IList<WindowsElement> inboxToFavorites;
            List<string> inboxesList = inboxesName.Split(',').ToList();
            foreach (var inboxName in inboxesList)
            {
                WaitForMoment(2);
                inboxToFavorites = _pageInstance.GetInboxToFavorite(inboxName);
                if (inboxToFavorites.Count > 0)
                {
                    WaitForMoment(2);
                    MouseClickOnWindowsElement(inboxToFavorites[0]);
                }
                else
                {
                    LogInfo($"Inbox with name: {inboxName} is not present in the persona page");
                }
            }
        }
        public void UnFavoriteInInsightsTab()
        {
            //To Collapse the Menu/Inboxes Tab
            MenuActions();

            int errorCount = 0;
            int kpiChartsCount = 0;
            do
            {
                try
                {
                    WaitForLoadingToDisappear();
                    IList<WindowsElement> insightsFavourites = _pageInstance.InsightsFavourites;
                    kpiChartsCount = insightsFavourites.Count;
                    do
                    {
                        if (insightsFavourites.Count > 0)
                        {
                            WaitForMoment(1);
                            MouseClickOnWindowsElement(insightsFavourites[0]);
                            WaitForLoadingToDisappear(LoadingText.Removing.ToString());
                            insightsFavourites = _pageInstance.InsightsFavourites;
                            kpiChartsCount--;
                        }
                    } while (kpiChartsCount != 0 && insightsFavourites.Count != 0);
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    errorCount++;
                }
            } while (errorCount != 0 && errorCount < 3);
            LogInfo($"Unfavorited Charts/KPI count {kpiChartsCount}");
        }
        public void UnFavoriteInFavoritesTab()
        {
            int errorCount = 0;
            int inboxesCount = 0;
            do
            {
                try
                {
                    IList<WindowsElement> inboxesFavourites = _pageInstance.FavouritesInboxes;
                    inboxesCount = inboxesFavourites.Count;
                    do
                    {
                        if (inboxesFavourites.Count > 0)
                        {
                            WaitForMoment(3);
                            MouseClickOnWindowsElement(inboxesFavourites[0]);
                            WaitForMoment(5);
                            inboxesFavourites = _pageInstance.FavouritesInboxes;
                            inboxesCount--;
                        }
                    } while (inboxesCount != 0 && inboxesFavourites.Count != 0);
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    errorCount++;
                }
            } while (errorCount != 0 && errorCount < 3);
            LogInfo($"Unfavorited inboxes count {inboxesCount}");
        }
        public void GlobalSearchByInboxNameInHomePage(string inboxName, string searchValue)
        {
            IList<WindowsElement> globalSearchInboxTextField = _pageInstance.GlobalSearchInboxInputField;
            char[] inboxNameSplitText = inboxName.ToCharArray();
            foreach (var eachCharacter in inboxNameSplitText)
            {
                globalSearchInboxTextField[0].SendKeys(eachCharacter.ToString());
            }
            WaitForMoment(1);
            IList<WindowsElement> inboxesList = _pageInstance.InboxListFromDropdown(inboxName);
            MouseClickOnWindowsElement(inboxesList[0]);
            WaitForMoment(1);
            if (!string.IsNullOrEmpty(searchValue))
            {
                IList<WindowsElement> globalSearchValueTextField = _pageInstance.GlobalSearchValueInputField;
                globalSearchValueTextField[0].SendKeys(searchValue);
                WaitForMoment(1);
            }
            _pageInstance.GlobalSearchImage[0].Click();
            WaitForMoment(1);
        }
        public void ClickOnHomeButton()
        {
            WindowsElement homeImage = _pageInstance.HomeImage[0];
            MouseClickOnWindowsElement(homeImage);
        }
        public void ClickOnInboxesItem(string inboxName, bool checkErrorEmptyTemplate=true)
        {
            int successCount = 0;
            int errorCount = 0;
            int attemptCount = 0;

            IList<WindowsElement> inboxesRefreshButton = _pageInstance.InboxesSearchButton;
            if (inboxesRefreshButton.Count > 0)
            {
                _pageInstance.InboxesToggleButton.Click();
            }

            do
            {
                try
                {
                    IList<WindowsElement> globalSearchInboxTextField = _pageInstance.GlobalSearchInboxInputField;
                    globalSearchInboxTextField[0].Clear();
                    WaitForMoment(2);
                    SplitAndEnterText(globalSearchInboxTextField[0], inboxName);
                    WaitForMoment(3);

                    IList<WindowsElement> inboxesList = _pageInstance.InboxListFromDropdown(inboxName);
                    if (inboxesList.Count > 0)
                    {
                        MouseClickOnWindowsElement(inboxesList[0]);
                        WaitForMoment(2);
                        _pageInstance.GlobalSearchImage[0].Click();
                        WaitForMoment(1);
                        successCount++;
                    }
                    else
                    {
                        attemptCount++;
                    }
                }
                catch (Exception ex)
                {
                    LogError($"{ex.Message} : {ex.StackTrace}");
                    errorCount++;
                }
            } while (successCount == 0 && errorCount <= 3 && attemptCount <= 3);

            if (errorCount == 3 | attemptCount > 3)
            {
                LogInfo($"Inbox with name : {inboxName} is not found in the current selected persona");
                Assert.Fail($"Inbox with name : {inboxName} is not found in the current selected persona");
            }

            WaitForLoadingToDisappear();
            if(checkErrorEmptyTemplate)
            {
                VerifyInvisibilityOfErrorMessages();
            }
        }
        public void ClickOnRefresh()
        {
            _pageInstance.RefreshImage.Click();
            WaitForLoadingToDisappear();
        }
        public void ClickOnRefreshButton()
        {
            _pageInstance.RefreshButton.Click();
            WaitForMoment(1);
            WaitForLoadingToDisappear();
        }
        public void ClickOnHelp()
        {
            _pageInstance.Help.Click();
        }
        public void ClickOnSuggestAFeature()
        {
            _pageInstance.SuggestAFeature.Click();
        }
        public void EnterSuggestFeatureTitle(string title)
        {
            _pageInstance.SuggestAfeatureTitleTextBox.SendKeys(title);
        }
        public void EnterSuggestFeatureDescription(string description)
        {
            _pageInstance.SuggestAfeatureDescriptionTextBox.SendKeys(description);
        }
        public void ClickOnSubmit()
        {
            _pageInstance.SubmitButton.Click();
        }

        public void SelectCategoryValue()
        {
            _pageInstance.SuggestAfeatureDescriptionTextBox.SendKeys(Keys.Tab);
            _pageInstance.CategoryListDropdown.SendKeys(Keys.ArrowDown);
        }
        public void ClickOnOkButton()
        {
            _pageInstance.ConfirmationOkButton.Click();
        }
        public void ClickClearCache()
        {
            _pageInstance.ClearCache.Click();
        }
        public void ClickClearAllButton()
        {
            _pageInstance.ClearAllCacheButton.Click();
        }
        public bool IsCacheClearedSuccessMsgPresent()
        {
            int count = _pageInstance.CacheClearedSuccessMsg.Count;
            if (count > 0)
            {
                return true;
            }
            else
            {
                Assert.Fail($"Cache cleared success message is not appearing in screen after Clear Cache operation");
                return false;
            }
        }
        public void ClickReloadModules()
        {
            ClickOnProfileImage();
            _pageInstance.SyncModule.Click();
            _pageInstance.ReloadModules.Click();
            WaitForLoadingToDisappear();
        }
        public void IsRefreshingLoaderPresent()
        {
            int count = _pageInstance.RefreshingLoader.Count;
            if (count == 0)
            {
                Assert.Fail($"Refreshing loader is not appearing on screen after Reload Modules operation");
            }
        }
        public void VerifyConnectivityEnvironment(string appEnvironmentName)
        {
            string actualEnvironmentName = _pageInstance.ConnectivityEnvironmentName.GetAttribute("Name");
            switch (appEnvironmentName.ToLower())
            {
                case "dev":
                    WaitForMoment(1);
                    Assert.AreEqual("Development", actualEnvironmentName);
                    LogInfo($"Envoronment name displayed in connectivity is : {actualEnvironmentName}");
                    break;

                case "dvv":
                    WaitForMoment(1);
                    Assert.AreEqual("DevVerify - 100", actualEnvironmentName);
                    LogInfo($"Envoronment name displayed in connectivity is : {actualEnvironmentName}");
                    break;

                case "uat":
                    WaitForMoment(1);
                    Assert.AreEqual("UAT - 100", actualEnvironmentName);
                    LogInfo($"Envoronment name displayed in connectivity is : {actualEnvironmentName}");
                    break;
                default:
                    LogInfo($"App environment name: {appEnvironmentName} is incorrect");
                    break;
            }
        }
        public void ClickOnConnectivity()
        {
            WaitForMoment(2);
            _pageInstance.ConnectivityTab.Click();

        }
        public void ClickOnActionButton()
        {
            _pageInstance.ActionButton.Click();
        }
        public void ClickOnSearchForActionName(string expectedActionPageTitle)
        {
            WaitForElementToAppear(expectedActionPageTitle);
            IList<WindowsElement> actionOption = _pageInstance.GetElementByText(expectedActionPageTitle);
            if (actionOption.Count > 0)
            {
                _touchScreen.SingleTap(actionOption[0].Coordinates);
                WaitForMoment(1);
            }           
        }
        public void EnterTextForActionSearch(string searchValue)
        {
            _pageInstance.SearchForActionName.SendKeys(searchValue);
        }
        public void VerifyActionPageTitle(string expectedActionPageTitle)
        {
            WaitForMoment(10);
            string actualActionPageTitle = _pageInstance.ActionPageTitle.Text;

            Assert.AreEqual(expectedActionPageTitle, actualActionPageTitle, $"Title displayed in action page: {actualActionPageTitle} is not as expected value: {expectedActionPageTitle}");
        }
      
        public void VerifyingTogglingFunctionality()
        {
            if (_pageInstance.TogglesText.Count > 0)
            {
                LogInfo($" {_pageInstance.TogglesText.Count}: Toggle is in expanded mode");
            }
            else
            {
                Assert.Fail($"{_pageInstance.TogglesText.Count}: Toggle is failed to expand");
            }
           
            _pageInstance.ToggleIcon.Click();

            if (_pageInstance.TogglesText.Count == 0)
            {
                LogInfo($" {_pageInstance.TogglesText.Count}: after clicking on Toggle icon, Toggle is in Collapsed mode");
            }
            else
            {
                Assert.Fail($"{_pageInstance.TogglesText.Count}: after clicking on Toggle icon, Toggle is failed to Collapse");
            }

        }
        public void VerifyPersonasVisibility()
        {
            if(_pageInstance.Personas.Count > 0)
            {
                LogInfo($"{_pageInstance.Personas.Count} Personas are displaying on screen.");
            }
            else
            {
                Assert.Fail($"Personas are not displaying on screen.");
            }
        }
        public void ClickOnFirstPersona(string persona)
        {
            _pageInstance.SelectPersona(persona).Click();
        }
        public void VerifyInboxesVisibility()
        {
            if (_pageInstance.Inboxes.Count > 0)
            {
                LogInfo($"{_pageInstance.Inboxes.Count} Inboxes are displaying on screen for selected Persona.");
            }
            else
            {
                Assert.Fail($"Inboxes are not displaying on screen.");
            }
        }
        public void MenuActions(string action= "collapse")
        {
            LogInfo($"Menu/Inboxes action is to : {action}");
            IList<WindowsElement> inboxesMenuTab = _pageInstance.ToggleControlText;
            WindowsElement toggleButton = _pageInstance.InboxesToggleButton;

            switch (action.ToLower())
            {
                case "open":
                    if(inboxesMenuTab.Count>0)
                    {
                        LogInfo($"Menu/Inboxes toggle tab is already in expanded state");
                    }
                    else
                    {
                        MouseClickOnWindowsElement(toggleButton);
                    }
                    break;
                case "collapse":
                    if (inboxesMenuTab.Count == 0)
                    {
                        LogInfo($"Menu/Inboxes toggle tab is already in collapse state");
                    }
                    else
                    {
                        MouseClickOnWindowsElement(toggleButton);
                    }
                    break;
                default:
                    LogInfo($"Menu/Inboxes action: {action} is incorrect");
                    break;
            }
        }
        public void FilterDataBySearch(string value)
        {
            EnterSearchValue(value);
            WaitForMoment(1);
            ClickOnSearchButton();
            WaitForLoadingToDisappear();
        }
        public void ClearSearchField()
        {
            _pageInstance.SearchEditInGrid.Clear();
            WaitForMoment(1);
            //ClickOnSearchButton();
            WaitForLoadingToDisappear();
        }
        public void EnterSearchValue(string value)
        {
            _pageInstance.SearchEditInGrid.Clear();
            _pageInstance.SearchEditInGrid.SendKeys(value);
        }
        public void ClickOnSearchButton()
        {
            _pageInstance.SearchButtonInGrid.Click();
            WaitForLoadingToDisappear();
        }

        public void HandleApplicationClosePopUp()
        {
            try
            {
                IList<WindowsElement> exitWindowPopUpOkButton = _pageInstance.ExitWindowOkButton;
                if (exitWindowPopUpOkButton.Count > 0)
                {
                    MouseClickOnWindowsElement(exitWindowPopUpOkButton[0]);
                }
            }
            catch (Exception ex)
            {

                LogError($"{ ex.Message} : { ex.StackTrace}");
            }

            
        }

       

        public void VerifyActionTagsOperations()
        {
            WaitForElementToAppear("Actions you can perform");
            WaitForMoment(2);
            IList<WindowsElement> TagNames = _pageInstance.ActionTagNames;
            LogInfo($"Tagname count: {TagNames.Count} ");
            if(TagNames.Count > 0)
            {
                try
                {
                    TagNames[0].Click();
                    WaitForMoment(2);
                    if (_pageInstance.ActionLabels.Count > 0)
                    {
                        LogInfo($"Action Label(s): {_pageInstance.ActionLabels.Count} available for selected Action Tag");
                        WaitForMoment(1); 
                    }
                    else
                    {
                        Assert.Fail($"Action Label(s): {_pageInstance.ActionLabels.Count} not available for selected Action Tag");
                    }
                }
                finally
                {
                    MouseHoverOnWindowsElement(_pageInstance.ActionLabels[0]);
                    WaitForMoment(1);
                    IList<WindowsElement> TagName = _pageInstance.ActionTagNames;
                    MouseClickOnWindowsElement(TagName[0]);
                }
            }
            else
            {
                Assert.Fail($"Action Tags not available");
            }
        }
        public IList<WindowsElement> GetAllFunctions()
        {
            IList<WindowsElement> functionList = _pageInstance.FunctionLists;
            return functionList;
        }
        public IList<WindowsElement> GetAllPersonas()
        {
            IList<WindowsElement> personasList = _pageInstance.PersonasLists;
            return personasList;
        }
        public IList<WindowsElement> GetAllInboxes()
        {
            IList<WindowsElement> inboxList = _pageInstance.InboxList;
            return inboxList;
        }
        public void NavigateToEachInboxFromEachFunction()
        {
            try
            {
                DateTime start = DateTime.Now;
                IList<WindowsElement> functionList = GetAllFunctions();
                IList<WindowsElement> personaList;
                IList<WindowsElement> inboxList;
                List<WindowsElement> inboxHistoryList = null;

                int inboxCount = 0;
                bool collapsePersona = false;

                MenuActions("open");

                if (functionList.Count > 0)
                {
                    foreach (WindowsElement function in functionList.Where(x => x.Text != "Home").ToList())
                    {
                        LogInfo($"Function Name:{ function?.Text}");
                        function.Click();
                        WaitForMoment(2);

                        personaList = GetAllPersonas();
                        //Handle Favorites
                        if (personaList.Any(x => x.Text == "Favorites"))
                        {
                            personaList[0].Click();
                        }

                        if (personaList.Count > 0)
                        {
                            foreach (WindowsElement persona in personaList.Where(x => x.Text != "Favorites").ToList())
                            {
                                LogInfo($"Persona Name:{ persona?.Text}");
                                inboxList = GetAllInboxes();
                                if (inboxList.Count == 0)
                                {
                                    persona.Click();
                                    WaitForMoment(2);
                                }

                                inboxList = GetAllInboxes().Where(x => x.Displayed).ToList();
                                if (inboxList.Count > 0)
                                {
                                    inboxHistoryList = new List<WindowsElement>();
                                    foreach (var inbox in inboxList)
                                    {
                                        LogInfo($"Inbox Name:{ inbox?.Text}");
                                        inbox.Click();
                                        WaitForMoment(0.5);

                                        inboxHistoryList.Add(inbox);

                                        string inboxIDName = inboxCount.ToString() + inbox?.Text;
                                        string inboxStatus = GetInboxStatusMessage(inbox?.Text);
                                        string inboxOutcome = GetInboxOutCome(inboxStatus);
                                        string inboxScreenshot = inboxIDName.Replace(" ", string.Empty);
                                        if (!inbox.Text.ToLower().Contains("personal"))
                                        {
                                            CaptureScreenShot(_session, inboxScreenshot.Replace(@"/", string.Empty));
                                        }
                                        else
                                        {
                                            screenshotFileName = string.Empty;
                                        }

                                        inboxCount++;
                                        LoggingToCSV(function?.Text, persona?.Text, inbox?.Text, inboxOutcome, inboxStatus, screenshotFileName);
                                    }

                                    collapsePersona = ScrollTillEnd(function?.Text, persona?.Text, inboxCount, inboxHistoryList);
                                }
                                else
                                {
                                    LogInfo($"No Inboxes available for Persona : {persona.Text}");
                                }
                                if (collapsePersona)
                                {
                                    persona.Click();
                                    WaitForMoment(3);
                                }
                            }
                        }
                        else
                        {
                            LogInfo($"No Personas available for Function : {function.Text}");
                        }
                    }
                }
                else
                {
                    LogInfo("No Functions available for UWP West Digital App");
                }

                TimeSpan duration = DateTime.Now - start;
                LogInfo($"Time taken for execution : {duration.ToString()}");
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
            }
        }
        public string GetInboxStatusMessage(string inboxName)
        {
            string inboxStatusMessage = string.Empty;
            string timeForDataToLoad = string.Empty;

            try
            {
                timeForDataToLoad = WaitForLoaderToDisappear();

                IList<WindowsElement> detailsRecords = _pageInstance.RecordsDataRows;
                if(detailsRecords.Count>0)
                {
                    inboxStatusMessage = "Data Loaded successfully";
                }
                else
                {
                    WaitForMoment(2);
                    IList<WindowsElement> emptylabels = _pageInstance.EmptyLabel;
                    if (emptylabels.Count > 0)
                    {
                        LogInfo($"Empty Image is detected in inbox : {inboxName}. Data is not getting displayed in the current page. Empty Label message : {emptylabels[0]?.Text}.");
                        inboxStatusMessage = emptylabels[0]?.Text;
                    }
                    else
                    {
                        IList<WindowsElement> errorlabels = _pageInstance.ErrorLabel;
                        if (errorlabels.Count > 0)
                        {
                            LogInfo($"Error Image is detected in inbox : {inboxName}. Data is not getting displayed in the current page. Error Label message : {errorlabels[0]?.Text}.");
                            inboxStatusMessage = errorlabels[0]?.Text;
                        }
                        else
                        {
                            inboxStatusMessage = "Data Loading unknow";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                inboxStatusMessage = "Data still Loading after 120 seconds";
                timeForDataToLoad = "120";
            }
            return inboxStatusMessage +","+ timeForDataToLoad;
        }
        public string WaitForLoaderToDisappear(string locatorName = "all")
        {
            int timeout = 120;
            Stopwatch stopwatch = new Stopwatch();
            IList<WindowsElement> loadingElement = null;

            WaitForMoment(1);
            stopwatch.Start();
            try
            {
                bool isPresent;
                do
                {
                    if (locatorName.Equals("all"))
                    {
                        loadingElement = _pageInstance.LoadingText;
                    }
                    if (loadingElement.Count > 0)
                    {
                        isPresent = loadingElement.Count > 0;
                    }
                    else
                    {
                        break;
                    }
                    WaitForMoment(0.5);
                } while (isPresent && stopwatch.Elapsed.TotalSeconds < timeout);
            }
            catch (Exception ex)
            {
                LogInfo($"{ex.Message} {ex.StackTrace}");
            }
            finally
            {
                LogInfo($"Loading Pop-Up : [{locatorName}] presence on screen = {stopwatch.Elapsed.TotalSeconds} seconds.");
                stopwatch.Stop();
            }
            if (stopwatch.Elapsed.TotalSeconds >= timeout)
            {
                LogError($"Loading Pop-Up : [{locatorName} : {loadingElement[0]?.Text}] is not getting dissappearing even after {timeout} seconds also.");
                throw new Exception($"Loading Pop-Up : [{locatorName} : {loadingElement[0]?.Text}] is not getting dissappearing even after {timeout} seconds also.");
            }
            return stopwatch.Elapsed.TotalSeconds.ToString("0.00");
        }
        public void LoggingToCSV(string function,string persona,string inboxName,string inboxOutcome,string inboxDataStatus,string screenshorFilePath)
        {
            int memoryUsage = 0;
            try
            {
                memoryUsage = BaseTest.MemoryUsageForProcess();
            }
            catch (Exception ex)
            {
                LogError("Error in getting WD App memory "+ ex.Message);
                memoryUsage = 0;
            }
            
            string inboxDetails = function + " -> " + persona + " -> " + inboxName + "," + inboxOutcome + "," + inboxDataStatus + ","+ memoryUsage + " MB," + screenshorFilePath;
            LogAppMemoryUsage(inboxDetails);
        }
        public string GetInboxOutCome(string inboxDataStatus)
        {
            if(inboxDataStatus.ToLower().Contains("error code") | inboxDataStatus.ToLower().Contains("after 120"))
            {
                return "Failed";
            }
            else
            {
                return "Passed";
            }
        }
        public bool ScrollTillEnd(string functionName, string personaName, int inboxCount, List<WindowsElement> inboxesHistoryList)
        {
            bool collapsePersona = true;
            IList<WindowsElement> inboxAfterScrollList = null;
            IList<WindowsElement> inboxBeforeScrollList = inboxesHistoryList;
            List<string> inboxBeforeScrollStringList = inboxBeforeScrollList.Select(x => x.Text).ToList();

            if (inboxBeforeScrollList.Count >= 7)
            {
                MouseHoverOnWindowsElement(inboxBeforeScrollList[0]);
                try
                {
                    ScrollVertically();
                    ScrollVertically();
                }
                catch (Exception ex)
                {
                    LogError("Error in scrolling " + ex.Message);
                }

                inboxAfterScrollList = GetAllInboxes().Where(x => x.Displayed).ToList();
                List<string> inboxAfterScrollStringList = inboxAfterScrollList.Select(x => x.Text).ToList();

                List<string> inboxTotalStringList = inboxBeforeScrollStringList.Union(inboxAfterScrollStringList).ToList();
                List<string> inboxTotalDistinctStringList = inboxTotalStringList.Distinct().ToList();
                List<string> inboxExpectedStringList = inboxTotalDistinctStringList.Except(inboxBeforeScrollStringList).ToList();

                if (inboxExpectedStringList.Count != 0)
                {
                    foreach (var inbox in inboxExpectedStringList)
                    {
                        WindowsElement inboxElement = _pageInstance.GetInboxName(inbox);
                        inboxElement.Click();
                        WaitForMoment(0.5);

                        string inboxIDName = inboxCount.ToString() + inbox;
                        string inboxStatus = GetInboxStatusMessage(inbox);
                        string inboxOutcome = GetInboxOutCome(inboxStatus);
                        string inboxScreenshot = inboxIDName.Replace(" ", string.Empty);

                        if (!inbox.ToLower().Contains("personal"))
                        {
                            CaptureScreenShot(_session, inboxScreenshot.Replace(@"/", string.Empty));
                        }
                        else
                        {
                            screenshotFileName = string.Empty;
                        }

                        LoggingToCSV(functionName, personaName, inbox, inboxOutcome, inboxStatus, screenshotFileName);
                    }
                    ClickOnFunction(functionName);
                    collapsePersona = false;
                }
                else
                {
                    LogInfo("No new inboxes found after scroll");
                }
            }
            else
            {
                LogInfo("No inboxes found to scroll");
            }
            return collapsePersona;
        }
        public void ClearCache()
        {
            ClickOnProfileImage();
            _pageInstance.SyncModule.Click();
            ClickClearCache();
            ClickClearAllButton();
            ClickOnOkButton();
        }
        public void ClickOnTermsOfLink()
        {
            _pageInstance.TermsOfUseLink.Click();          
        }

        public void VerifyTermsOfUsePageTitle(string expectedTermsOfUsePageTitle)
        {
            WaitForMoment(5);
            string actualTermsOfUsePageTitle = _pageInstance.TermsOfUseLink.Text;

            Assert.AreEqual(expectedTermsOfUsePageTitle, actualTermsOfUsePageTitle, $"Title displayed in Terms of Use page: {actualTermsOfUsePageTitle} is not as expected value: {expectedTermsOfUsePageTitle}");
        }

        public void IsSuggestionLoaderPresent()
        {
            int count = _pageInstance.SuggestionLoader.Count;
            if (count == 0)
            {
                LogInfo("Submitting Suggestion Loader is not appearing on screen after Submiting the suggestion without entering Title and description"); 
            }
            else
            {
                Assert.Fail($"Submitting Suggestion Loader is appearing on screen after Submiting the suggestion without entering Title and description");
            }
        }

        public void ViewLoggedInUserProfile(string loggedInUsername)
        {
            try
            {
                WaitForLoadingToDisappear();
                _pageInstance.ViewProfileButton(loggedInUsername).Click();
            }
            catch (Exception e)
            {
                _pageInstance.ViewProfileButton().Click();
                LogInfo("Exception Occured: " + e);
            }
        }

        public void ViewLoggedInUserProfile()
        {
            WaitForLoaderToDisappear();
                _pageInstance.ViewProfileButton().Click();
            WaitForMoment(3);
        }
    }
}
