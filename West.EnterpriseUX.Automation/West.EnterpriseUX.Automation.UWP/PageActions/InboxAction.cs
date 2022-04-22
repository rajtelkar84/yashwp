using ClosedXML.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class InboxAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly InboxPage _pageInstance;
        protected WebDriverWait wait;
        public InboxAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new InboxPage(_session);
        }
        public void HandlePopUpWindow()
        {
            WaitForMoment(5);
            IList<WindowsElement> popUpWindow = _pageInstance.PopUpWindow;
            if (popUpWindow.Count > 0)
            {
                _pageInstance.PopUpOkButton.Click();
            }
        }
        public void ClickOnFilterActionsButton()
        {
            int attempt = 0;
            _pageInstance.FilterImage.Click();
            WaitForMoment(2);
            IList<WindowsElement> dailogPopUp = _pageInstance.DialogPopUp;
            if (dailogPopUp.Count > 0)
            {
                do
                {
                    LogInfo($"Attempt :{attempt}, When tried to filter Dailog Pop-up is displaying with message : {dailogPopUp[0].Text}.");
                    _pageInstance.ConfirmationOkButton.Click();
                    WaitForMoment(1);
                    _pageInstance.RefreshImage.Click();
                    WaitForMoment(1);
                    WaitForLoadingToDisappear();
                    _pageInstance.FilterImage.Click();
                    WaitForMoment(2);
                    dailogPopUp = _pageInstance.DialogPopUp;
                    attempt++;
                } while (dailogPopUp.Count > 0 && attempt < 3);
            }
            else
            {
                LogInfo($"No Popup is displayed");
            }
        }
        public void ClickOnHomeActionsButton()
        {
            _pageInstance.HomeImage[0].Click();
        }
        public void ClickOnCreateMasterAction()
        {
            WaitForLoadingToDisappear();
            if (_pageInstance.MasterActionImage.Count > 0)
            {
                ClickElement(_pageInstance.MasterActionImage[0]);
            }
        }
        public void SelectFirstInboxRecord()
        {
            IList<WindowsElement> inboxRecords = _pageInstance.ViewSemantics;
            if (inboxRecords.Count > 0)
            {
                inboxRecords[0].Click();
            }
            else
            {
                LogInfo("No record are available for the Inbox");
                Assert.Fail($"No record are available for the Inbox");
            }
        }
        public void WaitForLabelLoaded(string LabelName)
        {
            WaitForElementToAppear(LabelName);
        }
        public void SelectLabel(string label)
        {
            IList<WindowsElement> allDashboardLabels = _pageInstance.InboxDashboardLabels(label);
            if (allDashboardLabels.Count > 0)
            {
                MouseClickOnWindowsElement(allDashboardLabels[0]);
            }
            WaitForLoadingToDisappear();
        }
        public Boolean CheckLabelExist(string label)
        {
            IList<WindowsElement> allDashboardLabels = _pageInstance.InboxDashboardLabels(label);
            if (allDashboardLabels.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean ClickArrowCheckLabelExist(string label)
        {
            Boolean temp = false;
            for (int i = 0; i < 3; i++)
            {
                IList<WindowsElement> allDashboardLabels = _pageInstance.InboxDashboardLabels(label);
                if (allDashboardLabels[0].GetAttribute("ClickablePoint").Contains("0,0"))
                {
                    IList<WindowsElement> dashboardRightArrow = _pageInstance.dashboardLabelsRightArrow;
                    MouseClickOnWindowsElement(dashboardRightArrow[0]);
                    temp = false;
                }
                else
                {
                    temp = true;
                    break;
                }
            }
            return temp;
        }
        public void ClickFromManageLebel(string label)
        {
            WaitForMoment(2);
            IList<WindowsElement> allDashboardLabels = _pageInstance.EnableDissableIconInManageLebel(label);
            IList<WindowsElement> allDashboardLabelsList = _pageInstance.MangeLablePoupUpList(label);

            if (allDashboardLabels.Count > 0)
            {
                for (int i = 0; i < allDashboardLabels.Count; i++)
                {
                    if (allDashboardLabelsList[i].GetAttribute("Name").Trim().Equals(label))
                    {
                        allDashboardLabels[i].Click();
                        break;
                    }
                }
            }

        }

        public void NavigateToTabs(bool isMemoryLog = false)
        {
            IList<WindowsElement> allTabs = _pageInstance.InboxTabOptions;
            foreach (var eachTab in allTabs)
            {
                eachTab.Click();
                WaitForMoment(10);
                WaitForLoadingToDisappear();

                int memorySize = BaseTest.MemoryUsageForProcess();
                if (isMemoryLog)
                {
                    BaseTest.LogMemoryUsage($"  {eachTab.Text} Abstraction  Memory Usage : ");
                }
                LogInfo($"Abstraction : {eachTab.Text} : {DateTime.Now} : {memorySize} MB ");
                WaitForMoment(1);
            }
        }
        public void NavigateToLabels()
        {
            WaitForMoment(2);
            IList<WindowsElement> allLabels = _pageInstance.InboxLabels.Where(x => x.Displayed).ToList();
            if (allLabels.Count > 0)
            {
                LogInfo($"No of Labels available for this inbox: {allLabels.Count}");

                for (int i = 0; i < allLabels.Count / 2; i++)
                {
                    MouseClickOnWindowsElement(allLabels[i]);
                    WaitForLoadingToDisappear();
                }
            }
            else
            {
                LogInfo("No Labels are available for the Inbox");
            }
        }
        public void SelectAbstraction(string abstractionName)
        {
            _pageInstance.SelectAbstraction(abstractionName).Click();
            WaitForLoadingToDisappear();
            VerifyInvisibilityOfErrorMessages();
        }
        public void EnterSearchValueInGrid(string value)
        {
            _pageInstance.SearchEditInGrid.Clear();
            _pageInstance.SearchEditInGrid.SendKeys(value);
            LogInfo("Entered text, '"+ value + "' on the 'Search' box from inbox page");
        }
        public void ClickOnSearchButton()
        {
            _pageInstance.SearchButtonInGrid.Click();
            LogInfo("Clicked on the 'Search' button from inbox page");
            WaitForLoadingToDisappear();
        }
        public void VerifySearchValueInGridIsEmpty()
        {
            if (String.IsNullOrEmpty(_pageInstance.SearchEditInGrid.Text))
            {
                LogInfo($"Data cleared and No data is available now in Search text box field");
            }
            else
            {
                Assert.Fail($"Data not cleared in Search text box field");
            }
        }
        public void ClickOnSearchDeleteButton()
        {
            int errorCount = 0;
            do
            {
                try
                {
                    WaitForMoment(2);
                    WindowsElement searchEdit = _pageInstance.SearchEditInGrid;
                    MouseClickOnWindowsElement(searchEdit);
                    WaitForMoment(1);
                    _pageInstance.SearchEditInGrid.Clear();
                    WaitForLoadingToDisappear();
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    LogError(ex.Message);
                    errorCount++;
                    if (errorCount == 4)
                    {
                        throw new Exception(ex.Message);
                    }
                    WaitForMoment(1);
                    _pageInstance.RefreshImage.Click();
                    WaitForMoment(5);
                }
            } while (errorCount != 0 && errorCount < 4);
        }
        public void ClickOnSaveLabel()
        {
            WindowsElement saveLabelCustom = _pageInstance.SaveLabelCustom;
            MouseClickOnWindowsElement(saveLabelCustom);
        }
        public void EnterLabelName(string labelName)
        {
            IList<WindowsElement> editLabelName = _pageInstance.LabelNameEdit;
            if (editLabelName.Count > 0)
            {
                MouseClickOnWindowsElement(editLabelName[0]);
                _pageInstance.LabelNameEdit[0].SendKeys(labelName);
                LogInfo($"Entering the LabelName {labelName} by option-1");
            }
            else
            {
                editLabelName = _pageInstance.LabelNameEditOptional;
                WaitForMoment(1);
                MouseClickOnWindowsElement(editLabelName[0]);
                _pageInstance.LabelNameEdit[0].SendKeys(labelName);
                LogInfo($"Entering the LabelName {labelName} by option-2");
            }
        }
        public void ClickOnSaveLabelButton()
        {
            _pageInstance.SaveLabelButton.Click();
            WaitForLoadingToDisappear(LoadingText.Saving.ToString());
        }
        public void VerifyLabel(string labelName)
        {
            //To Navigate to the last Dashboard label
            for (int i = 0; i < 3; i++)
            {
                IList<WindowsElement> dashboardRightArrow = _pageInstance.dashboardLabelsRightArrow;
                MouseClickOnWindowsElement(dashboardRightArrow[0]);
            }

            IList<WindowsElement> searchingLabels = _pageInstance.VerifyLabelName(labelName);
            if (searchingLabels.Count == 0)
            {
                LogInfo($"Label with name: {labelName} is not present in the inbox page");
                Assert.Fail($"Label with name: {labelName} is not present in the inbox page");
            }
        }
        public void NavigateInForwardDirection(int cycle = 1)
        {
            for (int i = 0; i < cycle; i++)
            {
                _pageInstance.PaginationNextPage.Click();
                WaitForMoment(1);
                WaitForLoadingToDisappear();
            }
        }
        public void NavigateInBackwardDirection(int cycle = 1)
        {
            for (int i = 0; i < cycle; i++)
            {
                _pageInstance.PaginationPreviousPage.Click();
                WaitForMoment(1);
                WaitForLoadingToDisappear();
            }
        }
        public List<string> GetInboxDashboarLabels()
        {
            IList<WindowsElement> dashboardLabelsList = _pageInstance.DashboardLabels;
            List<string> dashboardLabelsTextList = new List<string>();
            foreach (WindowsElement label in dashboardLabelsList)
            {
                string labelName = label.Text;
                int startIndex = (labelName.IndexOf('('));
                if (startIndex != -1)
                {
                    dashboardLabelsTextList.Add(labelName.Remove(labelName.IndexOf('(')));
                }
                else
                {
                    dashboardLabelsTextList.Add(labelName);
                }
            }
            return dashboardLabelsTextList;
        }
        public void SwitchBetweenInboxes(int switchingCycle = 1)
        {
            int randomNumber = 0;
            for (int i = 0; i < switchingCycle; i++)
            {
                _pageInstance.InboxesButton.Click();
                WaitForMoment(2);
                IList<WindowsElement> inboxList = GetAllInboxes();
                List<string> inboxNames = GetAllInboxesNames(inboxList);

                string previousInboxName = _pageInstance.InboxesButton.Text;

                Random random = new Random();
                if (inboxNames.Count <= 10)
                {
                    randomNumber = random.Next(0, inboxNames.Count - 1);
                }
                else if (inboxNames.Count >= 10 && inboxNames.Count <= 20)
                {
                    randomNumber = random.Next(1, inboxNames.Count / 2);
                }
                else if (inboxNames.Count >= 20)
                {
                    randomNumber = random.Next(1, inboxNames.Count / 4);
                }
                else
                {
                    randomNumber = 0;
                }

                IList<WindowsElement> CurrentInbox = _pageInstance.GetInbox(inboxNames[randomNumber]);
                WaitForMoment(1);
                MouseClickOnWindowsElement(CurrentInbox[0]);

                WaitForMoment(1);
                string currentInboxName = _pageInstance.InboxesButton.Text;
                LogInfo($"Current Inbox: {currentInboxName}");

                if (!String.IsNullOrEmpty(previousInboxName) && !String.IsNullOrEmpty(currentInboxName))
                {
                    Assert.AreNotEqual(previousInboxName, currentInboxName, $"Inboxes name is matching even after inbox switching");
                }
            }
        }
        public IList<WindowsElement> GetAllInboxes()
        {
            IList<WindowsElement> inboxList = _pageInstance.InboxList;
            return inboxList;
        }
        public List<string> GetAllInboxesNames(IList<WindowsElement> inboxList)
        {
            List<string> inboxNames = new List<string>();
            foreach (var inbox in inboxList)
            {
                if (!String.IsNullOrEmpty(inbox.Text))
                {
                    inboxNames.Add(inbox.Text);
                }
            }
            return inboxNames;
        }
        public void VerifyInboxName(string inboxName)
        {
            IList<WindowsElement> inboxHeader = _pageInstance.GetInboxNameTitle;
            Assert.AreEqual(inboxName, inboxHeader[0].Text, $"Inbox Page title: {inboxHeader[0].Text} is not matching the expected title: {inboxName}");
        }
        public void SortDataBy(string columnName, SortOrder sortingOrder)
        {
            List<string> sortingColumns = columnName.Split(',').ToList();
            int index = 0;
            _pageInstance.SortImage.Click();

            IList<WindowsElement> sortDeleteButtons;
            bool continueDelete = false;

            do
            {
                sortDeleteButtons = _pageInstance.SortDeleteButton.Where(x => x.Displayed).ToList();
                if (sortDeleteButtons.Count > 0)
                {
                    foreach (WindowsElement eachOption in sortDeleteButtons)
                    {
                        WaitForMoment(0.5);
                        MouseClickOnWindowsElement(eachOption);
                        WaitForMoment(1);
                        sortDeleteButtons = _pageInstance.DashboardLabelDelete.Where(x => x.Displayed).ToList();
                        if (sortDeleteButtons.Count > 0)
                        {
                            continueDelete = true;
                        }
                        else
                        {
                            continueDelete = false;
                        }
                    }
                }
                else
                {
                    WaitForMoment(0.5);
                    continueDelete = false;
                }
            } while (sortDeleteButtons.Count > 0 && continueDelete);

            foreach (var column in sortingColumns)
            {
                _pageInstance.AddSortButton.Click();
                _pageInstance.GetSortColumnInputField()[index]?.Clear();
                _pageInstance.GetSortColumnInputField()[index]?.SendKeys(column);
                WindowsElement sortColumnValue = _pageInstance.SelectSortColumn(column);
                MouseClickOnWindowsElement(sortColumnValue);
                _pageInstance.GetSortColumnInputField()[index]?.SendKeys(Keys.Tab);

                WindowsElement sortOrderCombobox = _pageInstance.GetSortOrderCombobox()[index];
                MouseClickOnWindowsElement(sortOrderCombobox);
                IList<WindowsElement> sortOrder = _pageInstance.GetElementByText(sortingOrder.ToString());
                MouseClickOnWindowsElement(sortOrder[0]);

                index++;
            }
            _pageInstance.ApplyButton.Click();
            WaitForLoadingToDisappear();
        }
        public void ClickOnDetailsMoreDropdown()
        {
            IList<WindowsElement> moreOptionDropdown = _pageInstance.DetailsMoreOptionImage;
            if (moreOptionDropdown.Count > 0)
            {
                _pageInstance.DetailsMoreOptionImage[0].Click();
            }
            else
            {
                LogInfo("More Option dropdown not able to identify in the page.");
            }
        }
        public void SelectDetailsMoreOption(string moreOptionsText)
        {
            ClickOnDetailsMoreDropdown();
            IList<WindowsElement> moreOption = _pageInstance.GetDetailsMoreOption(moreOptionsText);
            if (moreOption.Count > 0)
            {
                moreOption[0].Click();
            }
            else
            {
                LogInfo($"More Option value : {moreOptionsText} not able to identify in the current page.");
                Assert.Fail($"More Option value : {moreOptionsText} not able to identify in the current page.");
            }
        }
        public void VerifyInboxDataAvalability()
        {
            IList<WindowsElement> inboxRecords = _pageInstance.InboxGridRecords;
            LogInfo("No.of record are available for the Inbox is '"+ inboxRecords.Count + "'");
            if (inboxRecords.Count == 0)
            {
                LogInfo("No record are available for the Inbox");
                Assert.Fail($"No record are available for the Inbox");
            }
        }
        public List<string> GetDataByRowInDetails(int rowNo = 1)
        {
            List<string> rowData = new List<string>();
            VerifyInboxDataAvalability();
            IList<WindowsElement> rowRecord = _pageInstance.GetRecordByRow(rowNo);
            foreach (var columnData in rowRecord)
            {
                rowData.Add(columnData.Text);
            }
            return rowData;
        }
        public void ClickOnContextMoreOption()
        {
            _pageInstance.ContextMoreImage.Click();
        }
        public void SelectDetailAction(string detailAction)
        {
            ClickOnContextMoreOption();
            WaitForMoment(2);
            IList<WindowsElement> detailsActionOption = _pageInstance.GetDetailOption(detailAction);
            if (detailsActionOption.Count > 0)
            {
                detailsActionOption[0].Click();
            }
            else
            {
                LogInfo($"No Detail Action option is available for the Inbox ");
                Assert.Fail($"No Detail Action  option is available for the Inbox");
            }
        }
        public void VerifyHeaderDataFromExpandView(List<string> rowData)
        {
            WindowsElement expandViewHeader = _pageInstance.GetHeaderInExpandView;
            if (expandViewHeader != null && expandViewHeader.Text != "")
            {
                string[] headers = expandViewHeader.Text.Split(',');
                Assert.IsTrue(rowData.Contains(headers[0].Trim()), $"Value in Header Expand View {headers[0]} is not not matching the record present in the details grid");
            }
            else
            {
                List<string> expandRecordsData = _pageInstance.GetExpandRecordsData.Take(1).Select(x => x.Text).ToList();
                for (int i = 0; i < expandRecordsData.Count; i++)
                {
                    Assert.IsTrue(rowData.Contains(expandRecordsData[i].Trim()), $"Value in Header Expand View {expandRecordsData[i]} is not not matching the record present in the details grid");
                }
            }
        }
        public void VerifyNavigationToDetailsPage()
        {
            IList<WindowsElement> GridRefreshOption = _pageInstance.GridRefresh;
            IList<WindowsElement> moreOption = _pageInstance.DetailsMoreOptionImage;

            if (GridRefreshOption.Count > 0)
            {
                Assert.IsTrue(GridRefreshOption[0].Displayed, $"Reload option in the details grid page is not displaying");
            }
            else
            {
                Assert.Fail($"Reload option in the current page is not present, so its not in details page");
            }

            if (moreOption.Count > 0)
            {
                Assert.IsTrue(moreOption[0].Displayed, $"Details more option in the details grid page is not displaying");
            }
            else
            {
                Assert.Fail($"Details more option in the current page is not present, so its not in details page");
            }
        }
        public void ClickOnGlobalReload()
        {
            IList<WindowsElement> GridRefreshOption = _pageInstance.GridRefresh;
            MouseClickOnWindowsElement(GridRefreshOption[0]);
            WaitForLoadingToDisappear();
        }
        public void SelectSearchOption(string searchOption)
        {
            WindowsElement searchOptionDropdown = _pageInstance.SearchOptionDropdown;
            searchOptionDropdown.SendKeys(searchOption);
        }
        public int GetInboxDataCount()
        {
            IList<WindowsElement> emptylabels = _pageInstance.EmptyLabel;
            int recordsCount = 0;
            if (emptylabels.Count == 0)
            {
                IList<WindowsElement> inboxLabelCount = _pageInstance.GetInboxLabelCount;
                //string labelsCount = inboxLabelCount[0]?.Text.Split('(', ')')[1];
                string labelsCount = string.Empty;
                string firstLabel = inboxLabelCount[0]?.Text;
                labelsCount = firstLabel.Substring(firstLabel.LastIndexOf("(") + 1, (firstLabel.LastIndexOf(")") - firstLabel.LastIndexOf("(")) - 1);
                recordsCount = int.Parse(labelsCount);
            }
            LogInfo($"Inbox Label Count: {recordsCount}");
            return recordsCount;
        }
        public void VerifyInboxDataCount(int expectedLabelCount, bool countMatch = false)
        {
            int actualLabelCount = GetInboxDataCount();
            if (countMatch)
            {
                Assert.AreEqual(expectedLabelCount, actualLabelCount, $"Inbox actual data count:{actualLabelCount} is not matching as expected data count:{expectedLabelCount}");
            }
            else
            {
                if (actualLabelCount != 0 && expectedLabelCount != 0)
                {
                    Assert.AreNotEqual(expectedLabelCount, actualLabelCount, $"Inbox filtered data count:{actualLabelCount} is matching to unfiltered data count:{expectedLabelCount}");
                }
            }
        }
        public void ClickOnDetailActionForFirstRecord()
        {
            IList<WindowsElement> DetailActions = _pageInstance.DetailAction;
            if (DetailActions.Count > 0)
            {
                DetailActions[0].Click();
                LogInfo("Detail action for the 1st inbox record is clicked");
                WaitForMoment(2);
            }
            else
            {
                LogInfo("No record are available for the Inbox");
                Assert.Fail($"No record are available for the Inbox");
            }
        }

        public List<String> GetFirstRowValues()
        {
            List<String> values = new List<String>();
            IList<WindowsElement> rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            if (rowValues.Equals(null))
            {
                rowValues = _pageInstance.ValuebyRowAndColumnInGrid();
            }
            for (int i = 0; i < rowValues.Count; i++)
            {
                values.Add(rowValues[i].Text);
            }

            return values;
        }


        public void ClickOnDetailActionSpecificRow(int rowNumber)
        {
            IList<WindowsElement> DetailActions = _pageInstance.DetailActionAllRow(rowNumber);
            if (DetailActions.Count > 0)
            {
                WaitForMoment(2);
                DetailActions[0].Click();
                LogInfo("Detail action for the 1st inbox record is clicked");
                WaitForMoment(2);
            }
            else
            {
                LogInfo("No record are available for the Inbox");
                Assert.Fail($"No record are available for the Inbox");
            }
        }
        public Boolean CheckActionForFirstRecord()
        {
            try
            {
                IList<WindowsElement> DetailActions = _pageInstance.DetailAction;
                if (DetailActions.Count > 0)
                {

                    LogInfo("Detail action for the 1st inbox record is clicked");
                    return true;
                }
                else
                {
                    LogInfo("No record are available for the Inbox");
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public Boolean CheckDataNotAvailable()
        {
            try
            {
                return Exists(_pageInstance.DataNotAvailable);

            }
            catch (Exception)
            {
                return false;
            }

        }

        public Boolean CheckServerResponceAvailable()
        {
            try
            {
                return Exists(_pageInstance.ServerResponceAvailable);

            }
            catch (Exception)
            {
                return false;
            }

        }
        public void SelectRecords(string inbox, int rowCount = 1)
        {
            IList<WindowsElement> GridDataCheckBoxes = _pageInstance.GridRecordsCheckBoxes;
            if (GridDataCheckBoxes.Count > 0)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    MouseClickOnWindowsElement(GridDataCheckBoxes[i]);
                    WaitForMoment(1);
                }
            }
            else
            {
                LogInfo($"No Batch Action configured for this Inbox : {inbox}");
                Assert.Fail($"No Batch Action configured for this Inbox : {inbox}");
            }
        }
        public void SelectMasterActionOption(string masterActionText = null, string option = "first")
        {
            IList<WindowsElement> masterActionOption;
            WaitForMoment(1);
            if (!string.IsNullOrEmpty(masterActionText))
            {
                masterActionOption = _pageInstance.GetElementByText(masterActionText);
                MouseClickOnWindowsElement(masterActionOption[0]);
            }
            else
            {
                masterActionOption = _pageInstance.GetMasterActionOptions;
                if (masterActionOption.Count > 0)
                {
                    if (option.ToLower().Equals("first"))
                    {
                        MouseClickOnWindowsElement(masterActionOption[0]);
                    }
                    else
                    {
                        MouseClickOnWindowsElement(masterActionOption[masterActionOption.Count - 1]);
                    }
                }

            }
            WaitForMoment(1);
        }
        public void DeleteAllUserKPIs()
        {
            IList<WindowsElement> dashboardLabelsDelete = null;
            int deletedCount = 0;
            bool continueDelete = false;

            SelectDetailsMoreOption("Manage Labels");
            do
            {
                try
                {
                    dashboardLabelsDelete = _pageInstance.DashboardLabelDelete.Where(x => x.Displayed).ToList();
                    if (dashboardLabelsDelete.Count > 0)
                    {
                        WaitForMoment(0.5);
                        MouseClickOnWindowsElement(dashboardLabelsDelete[0]);
                        WaitForMoment(1);
                        _pageInstance.ConfirmationOkButton.Click();
                        WaitForLoadingToDisappear(LoadingText.Removing.ToString());
                        WaitForMoment(1);
                        _pageInstance.ConfirmationOkButton.Click();
                        WaitForMoment(1);
                        deletedCount++;
                        SelectDetailsMoreOption("Manage Labels");
                        dashboardLabelsDelete = _pageInstance.DashboardLabelDelete.Where(x => x.Displayed).ToList();
                        if (dashboardLabelsDelete.Count > 0)
                        {
                            continueDelete = true;
                        }
                        else
                        {
                            continueDelete = false;
                        }
                    }
                    else
                    {
                        WaitForMoment(0.5);
                        continueDelete = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (dashboardLabelsDelete.Count > 0 && continueDelete);
            LogInfo($"No of Dashboard labels deleted count : {deletedCount}");
            IList<WindowsElement> closePopup = _pageInstance.ClosePopup;
            if (closePopup.Count > 0)
            {
                closePopup[0].Click();
            }
        }
        public void SearchInbox(string inboxName)
        {
            IList<WindowsElement> inboxesRefreshButton = _pageInstance.InboxesSearchButton;
            if (inboxesRefreshButton?.Count == 0)
            {
                _pageInstance.InboxesToggleButton.Click();
            }

            IList<WindowsElement> searchInboxTextField = _pageInstance.InboxesSearchTextField;
            searchInboxTextField[0].Clear();
            WaitForMoment(1);
            searchInboxTextField[0].SendKeys(inboxName);
            WaitForMoment(1);
        }
        public void FavoriteInboxes(string inboxesNames)
        {
            string[] inboxes = inboxesNames.Split(',');
            WaitForMoment(1);
            foreach (var inbox in inboxes)
            {
                SearchInbox(inbox);
                WaitForMoment(1);
                WindowsElement inboxElement = _pageInstance.GetInboxName(inbox);
                MouseHoverOnWindowsElement(inboxElement);
                WaitForMoment(1);
                IList<WindowsElement> inboxContextMenu = _pageInstance.InboxesContextMenus;
                inboxContextMenu[0].Click();
                WaitForMoment(1);
                IList<WindowsElement> inboxContextMenuOptions = _pageInstance.GetElementByText("Favorite");
                if (inboxContextMenuOptions.Count > 0)
                {
                    inboxContextMenuOptions[0].Click();
                }
                else
                {
                    _pageInstance.HomeImage[0].Click();
                }
                WaitForMoment(1);
            }
        }

        public void ClickInbox(string inboxName)
        {
            IList<WindowsElement> inboxesList = _pageInstance.IndexSearchSideFrame(inboxName);
            _touchScreen.SingleTap(inboxesList[0].Coordinates);
            WaitForLoadingToDisappear();
        }

        public void ExportRecords(string option, string dataCount = "10")
        {
            IList<WindowsElement> exportDataOptions;

            switch (option.ToLower())
            {
                case "visible":
                    exportDataOptions = _pageInstance.GetExportDataCheckBox(" visible ");
                    exportDataOptions[0].Click();
                    break;
                case "all":
                    exportDataOptions = _pageInstance.GetExportDataCheckBox(" all ");
                    exportDataOptions[0].Click();
                    break;
                case "number":
                    exportDataOptions = _pageInstance.GetExportDataCheckBox("Export Records");
                    exportDataOptions[0].Click();
                    _pageInstance.ExportCountEdit.Clear();
                    _pageInstance.ExportCountEdit.SendKeys(dataCount);
                    break;
                default:
                    LogInfo($"Export Option : {option} is incorrect.");
                    break;
            }
            _pageInstance.ExportButton.Click();
        }
        public void HandleSaveDailog(string filePath)
        {
            WaitForElementToAppear("Save As");

            WindowsElement saveDialogFileNameEdit = _pageInstance.DialogSaveFileName;
            saveDialogFileNameEdit.Clear();
            saveDialogFileNameEdit.SendKeys(filePath);
            saveDialogFileNameEdit.Click();

            int saveButtonCount = _pageInstance.DialogSaveButton.Count;

            do
            {
                if (saveButtonCount > 0)
                {
                    _pageInstance.DialogSaveButton[0].Click();
                    saveButtonCount = _pageInstance.DialogSaveButton.Count;
                    IList<WindowsElement> confirmSave = _pageInstance.ConfirmSave;
                    if (confirmSave.Count > 0)
                    {
                        confirmSave[0].Click();
                    }
                }
                else
                {
                    LogInfo("Save Button is not present in the Save Dailog");
                    Assert.Fail("Save Button is not present in the Save Dailog");
                }
            } while (saveButtonCount > 0);
        }
        public void VerifyFileExists(string filepath)
        {
            if (File.Exists(filepath))
            {
                LogInfo($"Data Exported file exists in the location {filepath} after export operation");
            }
            else
            {
                LogError($"Data Exported file doesnt exist in the location : {filepath} after export operation");
                Assert.Fail($"Data Exported file doesnt exist in the location : {filepath} after export operation");
            }
        }
        public void NavigateToAbstractionsViaContextMenu(string inboxesName, string abstractionsNames)
        {
            string[] abstractions = abstractionsNames.Split(',');

            foreach (var abstraction in abstractions)
            {
                WindowsElement inboxElement = _pageInstance.GetInboxName(inboxesName);
                MouseHoverOnWindowsElement(inboxElement);
                IList<WindowsElement> inboxContextMenu = _pageInstance.InboxesContextMenus;
                inboxContextMenu[0].Click();
                IList<WindowsElement> inboxContextMenuOptions = _pageInstance.GetElementByText(abstraction);
                if (inboxContextMenuOptions.Count > 0)
                {
                    inboxContextMenuOptions[0].Click();
                }
                else
                {
                    _pageInstance.HomeImage[0].Click();
                }
                WaitForLoadingToDisappear();
                BaseTest.NavigateToAbstractionsPage(abstraction);
            }
        }
        public void VerifyRecordsPerPage()
        {
            int detailsDataCount = GetInboxDataCount();
            if (detailsDataCount > 1)
            {
                WindowsElement recordsPerPageDropDown = _pageInstance.RecordsPerPageDropdown;
                recordsPerPageDropDown.Click();

                IList<WindowsElement> pageNumber = _pageInstance.GetPageNumber("5");
                if (pageNumber.Count > 0)
                {
                    MouseClickOnWindowsElement(pageNumber[0]);
                }
                WaitForLoadingToDisappear();
                detailsDataCount = _pageInstance.RecordsDataRows.Count;
                Assert.AreEqual(5, detailsDataCount - 1, $"The actual data records : {detailsDataCount - 1} are not matching after updating the records per page as {5}");
            }
            else
            {
                LogInfo($"Since data in the inbox is {detailsDataCount}, so Records per page cannot be tested further.");
            }
        }
        public void ClickOnActionOptions(string Option)
        {
            IList<WindowsElement> actionOption = _pageInstance.GetElementByText(Option);
            if (actionOption.Count > 0)
            {
                _touchScreen.SingleTap(actionOption[0].Coordinates);
                WaitForMoment(1);
            }
        }
        public void ClickContextMenuOfRespectedIndox(string inboxName, string Text)
        {
            SearchInbox(inboxName);
            WaitForMoment(3);
            IList<WindowsElement> inboxContextMenu = _pageInstance.InboxContextMenu;
            inboxContextMenu[10].Click();
            WaitForMoment(2);
            _pageInstance.SearchForAction.SendKeys(Text);
        }
        public void VerifyManageLabelsFunctionality()
        {
            WindowsElement labelOne = _pageInstance.ManageLabels[1];
            String ManageLabelOne = _pageInstance.ManageLabels[1].Text;
            LogInfo($"First label on Manage Label window is: " + ManageLabelOne);

            WindowsElement labelTwo = _pageInstance.ManageLabels[2];

            var actions = new Actions(_session);
            actions.ClickAndHold(labelOne).Perform();
            WaitForMoment(1);
            actions.MoveByOffset(0, 5)
                .MoveToElement(labelTwo)
                .Release()
                .Perform();

            _pageInstance.ManageLabelsSaveButton.Click();
            WaitForLoadingToDisappear();

            if (_pageInstance.DashboardLabels.Count > 0)
            {
                String DashboardLabelOne = _pageInstance.DashboardLabels[0].Text;
                if (DashboardLabelOne.Contains(ManageLabelOne))
                {
                    Assert.Fail("Labels failed to swapp successfully. Now first label on dashboard is: " + DashboardLabelOne);
                }
                else
                {
                    LogInfo($"Labels swapped successfully. Now first label on dashboard is: " + DashboardLabelOne);
                }
            }
            else
            {
                LogInfo($"************** FAIL: NO DASHBOARD LABELS PRESENT ***************");
            }
        }
        public void VerifySearchInboxResults(String SearchedInbox)
        {
            SearchInbox(SearchedInbox);
            if (_pageInstance.SearchedInboxNames.Count > 0)
            {
                foreach (WindowsElement SingleInboxName in _pageInstance.SearchedInboxNames)
                {
                    if (SingleInboxName.Text.Contains(SearchedInbox))
                    {
                        LogInfo($"Search Input text: '{SearchedInbox}' contains in search result: '{SingleInboxName.Text}'");
                    }
                    else
                    {
                        Assert.Fail($"Search Input text: '{SearchedInbox}' not contains in search result: '{SingleInboxName.Text}'");
                    }
                }
            }
            else
            {
                Assert.Fail($"Inbox '{SearchedInbox}' not present in this function");
            }

        }
        public void EnterSearchValue(string value)
        {
            NavigateInxonSearch("right");
            WaitForMoment(1);
            NavigateInxonSearch("right");
            WaitForMoment(1);
            ClickAll();
            WaitForMoment(1);
            //Upper Code is Updated
            ClearElement(_pageInstance.SearchEditInGrid);
            EnterText(_pageInstance.SearchEditInGrid, value);
            ClickElement(_pageInstance.SearchButtonInGrid);
            WaitForMoment(3);
        }
        public void NavigateTo360View()
        {
            if (_pageInstance.Tab360View.Displayed)
            {
                LogInfo($"360º View Tab is displayed");
                _pageInstance.Tab360View.Click();
                WaitForLoadingToDisappear();
                VerifyInvisibilityOfErrorMessages();
            }
            else
            {
                Assert.Fail($"360º View Tab is displayed");
            }
        }
        public void VerifyKPIsVisibilityOnPage()
        {
            // Check KPIs displaying on page.
            if (_pageInstance.KPIsOnPage.Count > 0)
            {
                LogInfo($"No. of KPIs on this page: {_pageInstance.KPIsOnPage.Count}");
                LogInfo($"KPIs are visible on this page");
            }
            else
            {
                Assert.Fail($"KPIs are not visible on this page");
            }
        }
        public void VerifyKPIsCountIn360ViewPage()
        {
            //Getting the text of total count of KPIs displayed on 360 view page.
            string DisplayedKPIsText = _pageInstance.KPICount.Text;
            LogInfo($"KPI Count Text:- {DisplayedKPIsText}"); //E.g.- Displayed 6 of 30 Items

            //Splitting required text from string.
            string kpiCountText = DisplayedKPIsText.Substring(15);
            LogInfo($"First half text:- {kpiCountText}"); //E.g.- 30 Items

            //Extracting only digits from text.
            string temp = string.Empty;
            int AllKPICount = 0;
            LogInfo($"String with number: {kpiCountText}");
            for (int i = 0; i < kpiCountText.Length; i++)
            {
                if (Char.IsDigit(kpiCountText[i]))
                    temp += kpiCountText[i];
            }
            if (temp.Length > 0)
                AllKPICount = int.Parse(temp);
            LogInfo($"Extracted Number: {AllKPICount}"); //E.g.- 30

            if (AllKPICount > 0)
            {
                LogInfo($"KPIs are displayed in 360 view page");
            }
            else
            {
                Assert.Fail($"KPIs are Not displayed in 360 view page");
            }
        }
        public void EnterPageNumber(string pageNumber)
        {
            //Verifying Empty Image
            IList<WindowsElement> emptyImages = _pageInstance.EmptyImage;
            if (emptyImages.Count > 0)
            {
                IList<WindowsElement> dashboardLabelsList = _pageInstance.DashboardLabels;
                MouseClickOnWindowsElement(dashboardLabelsList[1]);
                WaitForLoadingToDisappear();
            }

            IList<WindowsElement> pageNumberTextField = _pageInstance.PageNumberTextField;
            pageNumberTextField[0].Clear();
            pageNumberTextField[0].SendKeys(pageNumber);
            WaitForLoadingToDisappear();
        }
        public void VerifyDeleteSortFunctionality()
        {
            //Opens Sort pop-up
            _pageInstance.SortImage.Click();

            //Delete Sorts one bu one available on sort pop-up.
            IList<WindowsElement> sortDeleteButtons;
            bool continueDelete = false;

            do
            {
                sortDeleteButtons = _pageInstance.SortDeleteButton.Where(x => x.Displayed).ToList();
                if (sortDeleteButtons.Count > 0)
                {
                    foreach (WindowsElement eachOption in sortDeleteButtons)
                    {
                        WaitForMoment(0.5);
                        MouseClickOnWindowsElement(eachOption);
                        WaitForMoment(1);
                        sortDeleteButtons = _pageInstance.DashboardLabelDelete.Where(x => x.Displayed).ToList();
                        if (sortDeleteButtons.Count > 0)
                        {
                            continueDelete = true;
                        }
                        else
                        {
                            continueDelete = false;
                        }
                    }
                }
                else
                {
                    WaitForMoment(0.5);
                    continueDelete = false;
                }
            } while (sortDeleteButtons.Count > 0 && continueDelete);

            //Checking still sorts are present after it has been deleted.
            if (sortDeleteButtons.Count == 0)
            {
                LogInfo($"All Sorts deleted successfully.");
            }
            else
            {
                Assert.Fail($"Sorts not deleted. {sortDeleteButtons.Count} sorts displayed after delete operation.");
            }
        }
        public void VerifyLoadMoreFunctionality()
        {
            int kpiTemplateCountBeforeLoadMore = 0;
            int kpiTemplateCountAfterLoadMore = 0;
            IList<WindowsElement> kpiTemplates;

            ScrollByOffSet();
            IList<WindowsElement> loadMoreOption = _pageInstance.LoadMoreButton;
            if (loadMoreOption.Count > 0)
            {
                kpiTemplates = _pageInstance.ZoomImage;
                kpiTemplateCountBeforeLoadMore = kpiTemplates.Count;
                MouseClickOnWindowsElement(loadMoreOption[0]);
                WaitForLoadingToDisappear();
                kpiTemplates = _pageInstance.ZoomImage;
                kpiTemplateCountAfterLoadMore = kpiTemplates.Count;

                Assert.IsTrue(kpiTemplateCountAfterLoadMore > kpiTemplateCountBeforeLoadMore, "KPI/Charts count after Load more option is not loading the remaining KPI's");
            }
            else
            {
                LogInfo("No of KPIs/Charts count is less than 6 in the inbox");
            }
        }
        public void VerifyManageGridColumnsFunctionality(String ColumnNameOne, String ColumnNameTwo)
        {
            //Clicking all cross icons one by one available on Manage Grid Columns pop-up.
            IList<WindowsElement> crossIcons;
            bool continueDelete = false;

            do
            {
                crossIcons = _pageInstance.CrossIcons.Where(x => x.Displayed).ToList();
                if (crossIcons.Count > 0)
                {
                    foreach (WindowsElement eachOption in crossIcons)
                    {
                        MouseClickOnWindowsElement(eachOption);
                        crossIcons = _pageInstance.CrossIcons.Where(x => x.Displayed).ToList();
                        if (crossIcons.Count > 0)
                        {
                            continueDelete = true;
                        }
                        else
                        {
                            continueDelete = false;
                        }
                    }
                }
                else
                {
                    continueDelete = false;
                }
            } while (crossIcons.Count > 0 && continueDelete);

            //Seleting fisrt Grid coloumn
            _pageInstance.ManageGridColumnSearchBox.Clear();
            _pageInstance.ManageGridColumnSearchBox.SendKeys(ColumnNameOne);
            _pageInstance.GridColumnCheckBox.Click();

            //Seleting second Grid coloumn
            _pageInstance.ManageGridColumnSearchBox.Clear();
            _pageInstance.ManageGridColumnSearchBox.SendKeys(ColumnNameTwo);
            _pageInstance.GridColumnCheckBox.Click();

            //Clicking Save button on Manage Grid Columns pop-up
            _pageInstance.ManageGridColumnSaveButton.Click();

            WaitForLoadingToDisappear();

            //Validating Manage Grid Columns functionality
            if (_pageInstance.GridColumnNames.Count - 1 == 2)
            {
                LogInfo($"Manage Grid Columns functionality working as expected. " +
                    $"Column Count: {_pageInstance.GridColumnNames.Count - 1}");
            }
            else
            {
                Assert.Fail($"Manage Grid Columns functionality not working as expected. " +
                    $"Column Count: {_pageInstance.GridColumnNames.Count - 1}");
            }

            //Comparing First Grid column name on Grid screen.
            String FirstGridColumnName = _pageInstance.GridColumnNameFirst.Text;
            if (ColumnNameOne.Equals(FirstGridColumnName))
            {
                LogInfo($"Selected column: {ColumnNameOne} from Manage Grid Columns pop-up matches with Column: {FirstGridColumnName} on result grid.");
            }
            else
            {
                Assert.Fail($"Selected column: {ColumnNameOne} from Manage Grid Columns pop-up Not matches with Column: {FirstGridColumnName} on result grid.");
            }

            //Comparing Second Grid column name on Grid screen.
            String SecondGridColumnName = _pageInstance.GridColumnNameSecond.Text;
            if (ColumnNameTwo.Equals(SecondGridColumnName))
            {
                LogInfo($"Selected column: {ColumnNameTwo} from Manage Grid Columns pop-up matches with Column: {SecondGridColumnName} on result grid.");
            }
            else
            {
                Assert.Fail($"Selected column: {ColumnNameTwo} from Manage Grid Columns pop-up Not matches with Column: {SecondGridColumnName} on result grid.");
            }
        }
        public void VerifyResetFunctionalityOfManageGridColumns()
        {
            //Click Reset button.
            _pageInstance.ManageGridColumnResetButton.Click();
            _pageInstance.ConfirmationOkButton.Click();
            WaitForLoadingToDisappear();

            //Validating Grid Columns after Reset functionality performed.
            if (_pageInstance.GridColumnNames.Count - 1 > 2)
            {
                LogInfo($"Reset functioality in Manage Grid Columns working as expected. " +
                    $"Column Count: {_pageInstance.GridColumnNames.Count - 1}");
            }
            else
            {
                Assert.Fail($"Reset functioality in Manage Grid Columns not working as expected. " +
                    $"Column Count: {_pageInstance.GridColumnNames.Count - 1}");
            }
        }
        public void VerifyFilterCount(String ExpectedCountValue)
        {
            if (_pageInstance.FilterCountValue.Count > 0)
            {
                LogInfo($"Filter count value is displayed on filter icon");
                String FilterCountValue = _pageInstance.FilterCountValue[0].Text;
                if (FilterCountValue.Equals(ExpectedCountValue))
                {
                    LogInfo($"Filter count {FilterCountValue} value matches with expected value {ExpectedCountValue}");
                }
                else
                {
                    Assert.Fail($"Filter count value {FilterCountValue} does not match with expected value {ExpectedCountValue}");
                }
            }
            else
            {
                Assert.Fail($"Filter count value not displayed on filter icon");
            }
        }
        public void VerifyFilterCountDisappearAfterSavingLabel()
        {
            if (_pageInstance.FilterCountValue.Count > 0)
            {
                Assert.Fail($"Filter count value is still displayed on filter icon after saving dashboard label");
            }
            else
            {
                LogInfo($"Filter count value not displayed on filter icon after saving dashboard label");
            }
        }
        public void ClickOnMasterActionInSemanticView()
        {
            ClickElement(_pageInstance.ActionsButtonInSemantic);
        }

        public void VerifyCommonElementsOnInboxPage(string inbox)
        {
            WaitForMoment(3);

            String ExpectedInboxTitle = inbox;
            Assert.IsTrue(_pageInstance.InboxTitle.Displayed);

            String ActualInboxTitle = _pageInstance.InboxTitle.Text;

            Assert.AreEqual(ExpectedInboxTitle, ActualInboxTitle);

            String ExpectedAbstractions = "Details, KPIs, Charts, Storyboards";
            string[] AbstractionTabs = GetAbstractionTabs();
            bool areAllAbstractionTabsPresent = false;

            foreach (string tab in AbstractionTabs)
            {
                if (ExpectedAbstractions.Contains(tab.Trim()))
                    areAllAbstractionTabsPresent = true;
                else
                {
                    areAllAbstractionTabsPresent = false;
                    break;
                }
            }
            Assert.IsTrue(areAllAbstractionTabsPresent);
            
            Assert.IsTrue(_pageInstance.SearchBox.Displayed);
            Assert.IsTrue(_pageInstance.SearchBox.Enabled);

            Assert.IsTrue(_pageInstance.SearchImage.Displayed);
            Assert.IsTrue(_pageInstance.SearchImage.Enabled);

            Assert.IsTrue(_pageInstance.FilterButton.Displayed);
            Assert.IsTrue(_pageInstance.FilterButton.Enabled);

            Assert.IsTrue(_pageInstance.FilterDropdownButton.Displayed);
            Assert.IsTrue(_pageInstance.FilterDropdownButton.Enabled);

            Assert.IsTrue(_pageInstance.RefreshImage.Displayed);
            Assert.IsTrue(_pageInstance.RefreshImage.Enabled);

            Assert.IsTrue(_pageInstance.RefreshButton.Displayed);
            Assert.IsTrue(_pageInstance.RefreshButton.Enabled);

            Assert.IsTrue(_pageInstance.SortImage.Displayed);
            Assert.IsTrue(_pageInstance.SortImage.Enabled);

            Assert.IsTrue(_pageInstance.SortButton.Displayed);
            Assert.IsTrue(_pageInstance.SortButton.Enabled);

            Assert.IsTrue(_pageInstance.MoreButton.Displayed);
            Assert.IsTrue(_pageInstance.MoreButton.Enabled);

            Assert.IsTrue(_pageInstance.ReloadButton.Displayed);
            Assert.IsTrue(_pageInstance.ReloadButton.Enabled);
        }

        public string[] GetAbstractionTabs()
        {
            IList<WindowsElement> AbstractionTabs = _pageInstance.AbstractionTabs;
            string[] AbstractionTabsArray = new string[AbstractionTabs.Count];
            int index = 0;

            foreach (WindowsElement tab in AbstractionTabs)
            {
                if (tab.Enabled && tab.Displayed)
                {
                    AbstractionTabsArray[index++] = GetAttribute(tab, "Name");
                }
            }
            return AbstractionTabsArray;
        }

        public void VerifyAndApplyFilter(string filterField, string filterOperator, string filterValue)
        {
            _pageInstance.FilterButton.Click();
            _pageInstance.AddNewFilterButton.Click();

            WaitForMoment(5);
            string actualFilterFieldText = _pageInstance.FilterFieldText.Text;
            string actualOperatorText = _pageInstance.FilterOperatorText.Text;

            Assert.AreEqual("Filter Field", actualFilterFieldText);
            Assert.AreEqual("Operator", actualOperatorText);

            SelectFilterField(filterField);
            SelectOperatorValue(filterOperator);

            Assert.AreEqual("Filter Value", _pageInstance.FilterValueText.Text);
            _pageInstance.FilterValueTextBox.SendKeys(filterValue);

            _pageInstance.FilterCheckBox.Click();
            _pageInstance.ApplyFilterButton.Click();
        }

        public void SelectFilterField(string filterField)
        {
            _pageInstance.FilterFieldTextBox.Click();
            _pageInstance.FilterFieldTextBox.Clear();
            char[] filterFieldValue = filterField.ToCharArray();

            foreach (var eachValue in filterFieldValue)
            {
                _pageInstance.FilterFieldTextBox.SendKeys(eachValue.ToString());
            }
            _pageInstance.SelectFilterField(filterField).Click();
        }

        public void SelectOperatorValue(string filterOperator)
        {
            _pageInstance.FilterOperatorTextBox.Click();
            _pageInstance.FilterOperatorTextBox.Clear();
            char[] filterOperatorValue = filterOperator.ToCharArray();

            foreach (var eachValue in filterOperatorValue)
            {
                _pageInstance.FilterOperatorTextBox.SendKeys(eachValue.ToString());
            }
            _pageInstance.SelectOperator(filterOperator).Click();
        }

        public void VerifyFilterArrowDropdownAndActiveFilter(string filterField, string filterOperator, string filterValue)
        {
            Assert.AreEqual("1", _pageInstance.Digit_1_LabelText.Text);

            _pageInstance.FilterDropdownButton.Click();

            WaitForMoment(2);

            Assert.IsTrue(_pageInstance.EditableFilterLabel.Displayed);
            Assert.AreEqual(filterField, _pageInstance.EditableFilterLabel.Text);

            Assert.IsTrue(_pageInstance.EditableFilterOperator.Displayed);
            Assert.AreEqual(filterOperator, _pageInstance.EditableFilterOperator.Text);

            Assert.IsTrue(_pageInstance.EditableFilterValue.Displayed);
            Assert.AreEqual(filterValue, _pageInstance.EditableFilterValue.Text);

            Assert.IsTrue(_pageInstance.EditableFilterImageEdit.Displayed);
            Assert.IsTrue(_pageInstance.EditableFilterImageEdit.Enabled);

            Assert.IsTrue(_pageInstance.EditableFilterRemove.Displayed);
            Assert.IsTrue(_pageInstance.EditableFilterRemove.Enabled);
        }

        public void VerifyFilterArrowDropdownWithoutActiveFilter()
        {
            _pageInstance.FilterDropdownButton.Click();

            WaitForMoment(2);

            Assert.IsTrue(_pageInstance.NoActiveFiltersMsg.Displayed);

            string expectedMessage = "No Active Filters to show";
            string actualMessage = _pageInstance.NoActiveFiltersMsg.Text;

            Assert.AreEqual(expectedMessage, actualMessage);
        }

        public void VerifyExportVisibleRecordsFunctionality()
        {
            string testExcelfileName = "VisibleRecordsTestFile_" + new Random().Next(1, 1000) + ".xlsx";

            try
            {
                _pageInstance.MoreButton.Click();
                _pageInstance.GetDetailsMoreOption("Export to Excel")[0].Click();

                WaitForMoment(2);

                Assert.IsTrue(_pageInstance.ExportToExcelPopupTitle.Displayed);
                Assert.AreEqual("Export to Excel", _pageInstance.ExportToExcelPopupTitle.Text);

                bool isDefaultOptionSelected = _pageInstance.GetExportDataCheckBox("Export visible Records")[0].Selected;
                Assert.IsTrue(isDefaultOptionSelected);

                if (_pageInstance.ExportButton.Displayed && _pageInstance.ExportButton.Enabled)
                    _pageInstance.ExportButton.Click();

                WaitForMoment(2);
                
                _pageInstance.FileNameTextBox.Clear();
                _pageInstance.FileNameTextBox.SendKeys(testExcelfileName);

                if (_pageInstance.DialogSaveButton[0].Displayed && _pageInstance.DialogSaveButton[0].Enabled)
                    _pageInstance.DialogSaveButton[0].Click();

                WaitForMoment(2);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                LogInfo(testExcelfileName + " file is not exported.");
            }
            finally
            {
                DeleteExportedExcelFileFromDocumentsDir(testExcelfileName);
                LogInfo(testExcelfileName + " file has been deleted.");
            }
        }

        public void DeleteExportedExcelFileFromDocumentsDir(string excelFileName)
        {
            string docummentsFolderPath = "OneDrive - West Pharmaceutical Services, Inc\\Documents";
            string documentsDirectory = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), docummentsFolderPath);

            WaitForMoment(5);
            KillExcelProcess();
            WaitForMoment(5);

            // to delete the file from Documents folder
            string[] filesInDocumentsDir = Directory.GetFiles(documentsDirectory, "*.xlsx");

            foreach (string fileName in filesInDocumentsDir)
            {
                string fileToBeDeleted = documentsDirectory + "\\" + excelFileName;

                if (fileName.Equals(fileToBeDeleted))
                {
                    File.Delete(fileToBeDeleted);
                    break;
                }
                else
                {
                    LogInfo(fileToBeDeleted + " file is not present in Documents directory.");
                    break;
                }
            }
        }

        public void KillExcelProcess()
        {
            foreach (System.Diagnostics.Process myProc in System.Diagnostics.Process.GetProcesses())
            {
                if (myProc.ProcessName == "EXCEL")
                {
                    myProc.Kill();
                    break;
                }
            }
        }

        public void VerifyExportAllRecordsFunctionality()
        {
            string testExcelfileName = "AllRecordsTestFile_" + new Random().Next(1, 1000) + ".xlsx";

            try
            {
                _pageInstance.MoreButton.Click();
                _pageInstance.GetDetailsMoreOption("Export to Excel")[0].Click();

                WaitForMoment(2);

                Assert.IsTrue(_pageInstance.ExportToExcelPopupTitle.Displayed);
                Assert.AreEqual("Export to Excel", _pageInstance.ExportToExcelPopupTitle.Text);

                bool isDefaultOptionSelected = _pageInstance.GetExportDataCheckBox("Export visible Records")[0].Selected;
                Assert.IsTrue(isDefaultOptionSelected);

                bool isExportAllRecordsSelected = _pageInstance.GetExportDataCheckBox("Export All Records")[0].Selected;
                Assert.IsFalse(isExportAllRecordsSelected);

                bool isExportAllRecordsDisplayed = _pageInstance.GetExportDataCheckBox("Export All Records")[0].Displayed;
                Assert.IsTrue(isExportAllRecordsDisplayed);

                bool isExportAllRecordsEnabled = _pageInstance.GetExportDataCheckBox("Export All Records")[0].Enabled;
                Assert.IsTrue(isExportAllRecordsEnabled);

                _pageInstance.GetExportDataCheckBox("Export All Records")[0].Click();

                if (_pageInstance.ExportButton.Displayed && _pageInstance.ExportButton.Enabled)
                    _pageInstance.ExportButton.Click();

                WaitForMoment(60);

                LaunchExportToExcelSessionAndExportExcelReport(testExcelfileName);

                WaitForMoment(5);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                LogInfo(testExcelfileName + " file is not exported.");
            }
            finally
            {
                DeleteExportedExcelFileFromDocumentsDir(testExcelfileName);
                LogInfo(testExcelfileName + " file has been deleted.");
            }
        }

        public void VerifyExportRecordsFunctionality()
        {
            string testExcelfileName = "NoOfRecordsTestFile_" + new Random().Next(1, 1000) + ".xlsx";
            int noOfRecords = 200;
            try
            {
                _pageInstance.MoreButton.Click();
                _pageInstance.GetDetailsMoreOption("Export to Excel")[0].Click();

                WaitForMoment(2);

                Assert.IsTrue(_pageInstance.ExportToExcelPopupTitle.Displayed);
                Assert.AreEqual("Export to Excel", _pageInstance.ExportToExcelPopupTitle.Text);

                bool isDefaultOptionSelected = _pageInstance.GetExportDataCheckBox("Export visible Records")[0].Selected;
                Assert.IsTrue(isDefaultOptionSelected);

                bool isExportRecordsSelected = _pageInstance.GetExportDataCheckBox("Export Records")[0].Selected;
                Assert.IsFalse(isExportRecordsSelected);

                bool isExportRecordsDisplayed = _pageInstance.GetExportDataCheckBox("Export Records")[0].Displayed;
                Assert.IsTrue(isExportRecordsDisplayed);

                bool isExportRecordsEnabled = _pageInstance.GetExportDataCheckBox("Export Records")[0].Enabled;
                Assert.IsTrue(isExportRecordsEnabled);

                _pageInstance.GetExportDataCheckBox("Export Records")[0].Click();

                bool isNoOfItemsToExportTextDisplayed = _pageInstance.NumberOfItemsToExportText.Displayed;
                Assert.IsTrue(isNoOfItemsToExportTextDisplayed);

                if (_pageInstance.CountTextBox.Displayed && _pageInstance.CountTextBox.Enabled)
                {
                    _pageInstance.CountTextBox.Clear();
                    _pageInstance.CountTextBox.SendKeys(Convert.ToString(noOfRecords));
                }   

                if (_pageInstance.ExportButton.Displayed && _pageInstance.ExportButton.Enabled)
                    _pageInstance.ExportButton.Click();

                WaitForMoment(60);
                LaunchExportToExcelSessionAndExportExcelReport(testExcelfileName);
                WaitForMoment(5);
                KillExcelProcess();
                WaitForMoment(5);
                VerifyNoOfRecordsExported(testExcelfileName, noOfRecords);
                WaitForMoment(5);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
                LogInfo(testExcelfileName + " file is not exported.");
            }
            finally
            {
                DeleteExportedExcelFileFromDocumentsDir(testExcelfileName);
                LogInfo(testExcelfileName + " file has been deleted.");
            }
        }

        public void VerifyNoOfRecordsExported(string testExcelfileName, int expectedNoOfRecords)
        {
            string docummentsFolderPath = "OneDrive - West Pharmaceutical Services, Inc\\Documents";
            string documentsDirectory = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), docummentsFolderPath);

            string fileName = documentsDirectory + "\\" + testExcelfileName;
            int actualNoOfRecords;

            using (var excelWorkbook = new XLWorkbook(fileName))
            {
                actualNoOfRecords = excelWorkbook.Worksheet(1).RowsUsed().Count() - 1;
            }

            Assert.AreEqual(expectedNoOfRecords, actualNoOfRecords, "No. of records exported should be same.");
        }

        public void LaunchExportToExcelSessionAndExportExcelReport(string testExcelfileName)
        {       
            var desktopCapabilities = new AppiumOptions();
            desktopCapabilities.AddAdditionalCapability("platformName", "Windows");
            desktopCapabilities.AddAdditionalCapability("app", "Root");
            desktopCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");

            WindowsDriver<WindowsElement> exportToExcelSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), desktopCapabilities);

            WindowsElement applicationWindow = null;
            var openWindows = exportToExcelSession.FindElementsByClassName("ApplicationFrameWindow");

            foreach (var window in openWindows)
            {
                if (window.GetAttribute("Name").Contains("Export to Excel"))
                {
                    applicationWindow = window;
                    try
                    {
                        applicationWindow.Click();
                    }
                    catch (Exception ex)
                    {
                        LogError($"Error in clicking on application by method-2:{ex.Message} : {ex.StackTrace}");
                    }
                    break;
                }
            }

            // Attaching to existing Application Window to exportToExcelSession
            var exportToExcelWindowHandle = applicationWindow.GetAttribute("NativeWindowHandle");
            exportToExcelWindowHandle = int.Parse(exportToExcelWindowHandle).ToString("X");

            var capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("deviceName", "WindowsPC");
            capabilities.AddAdditionalCapability("appTopLevelWindow", exportToExcelWindowHandle);

            exportToExcelSession = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), desktopCapabilities);

            // Explicit wait to wait till save button displays
            DefaultWait<WindowsDriver<WindowsElement>> defaultWait = new DefaultWait<WindowsDriver<WindowsElement>>(exportToExcelSession);
            defaultWait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(Exception));
            defaultWait.Timeout = TimeSpan.FromSeconds(100);
            defaultWait.Until(pred => pred.FindElementByXPath("//Button[@AutomationId='1' and @Name='Save']").Displayed);

            exportToExcelSession.FindElementByXPath("//Edit[@Name='File name:']").Clear();
            exportToExcelSession.FindElementByXPath("//Edit[@Name='File name:']").SendKeys(testExcelfileName);

            WindowsElement saveButton = exportToExcelSession.FindElementByXPath("//Button[@AutomationId='1' and @Name='Save']");
            
            if (saveButton.Enabled)
                saveButton.Click();

            exportToExcelSession.Quit();
        }

        public void VerifyCopyInDetailsViewAndSemanticView()
        {
            // Verifying Copy feature on Details view, Copying 1st row, 1st column data
            VerifyCopyFeatureOnDetailsAndSemanticView();
            LogInfo($"Copy feature verified successfully on Details view");

            WaitForMoment(1);
            _pageInstance.ViewSemantics[0].Click();
            _pageInstance.SalesOrderItemsChildInbox.Click();
            WaitForLoadingToDisappear();

            // Verifying Copy feature on Semantic view, Copying 1st row, 1st column data
            VerifyCopyFeatureOnDetailsAndSemanticView();
            LogInfo($"Copy feature verified successfully on Semantic view");
        }

        public void VerifyCopyFeatureOnDetailsAndSemanticView()
        {
            if (_pageInstance.ValuebyRowAndColumnInGrid()[0].Displayed)
            {
                _pageInstance.ValuebyRowAndColumnInGrid()[0].Click();
                _pageInstance.ValuebyRowAndColumnInGrid()[0].SendKeys(Keys.Control + 'a');
                _pageInstance.ValuebyRowAndColumnInGrid()[0].SendKeys(Keys.Control + 'c');

                if (_pageInstance.SearchBoxOnDetails.Displayed && _pageInstance.SearchBoxOnDetails.Enabled)
                {
                    _pageInstance.SearchBoxOnDetails.Click();
                    _pageInstance.SearchBoxOnDetails.SendKeys(Keys.Control + 'v');
                }
                else
                {
                    LogInfo($"Search box is not displayed and enabled on Details view");
                }
            }
            else
            {
                LogInfo($"Record is not displayed on Details view");
            }
        }

        public void VerifyMasterActionConfirmationPopUpTextInSemanticView(string ExpectedTextOnPopup, string pageTitle)
        {
            if (_pageInstance.MAConfirmationPopup.Count > 0)
            {
                LogInfo($"Popup appeared successfully after selecting any Master Action from Actions menu. Now checking text on pop-up");

                if (_pageInstance.MAConfirmationPopupText.Text.ToLower().Contains(ExpectedTextOnPopup))
                {
                    LogInfo($"Text on popup matched");
                    _pageInstance.ConfirmationOkButton.Click();
                }
                else
                {
                    Assert.Fail($"Text on popup not matched");
                }
            }
            else
            {
                LogInfo($"No popup appeared after selecting any Master Action from Actions menu");
                if (_pageInstance.GetPageTitle.Displayed)
                {
                    VerifyPageTitle(pageTitle);
                    LogInfo($"Page title verified successfully");
                }
            }
        }


        public void VerifyLastSyncedTime()
        {
            string lastSyncTimeText = _pageInstance.LastSyncedTime.Text;

            //To validated the Last Sync Time for Second and Seconds
            Regex r = new Regex("second|seconds");
            bool expectedOutput = r.IsMatch(lastSyncTimeText);

            if (expectedOutput)
            {
                LogInfo($"Last Sync time is updated and Time displayed in : " + lastSyncTimeText);
            }
            else
            {
                Assert.Fail($"Sync time is not updated and Time displayed is  : " + lastSyncTimeText);
            }
        }
        public void VerifyHyperlinkNavigationFunctionality(string HyperlinkText, string InboxName)
        {
            WaitForLoadingToDisappear();
            _pageInstance.HyperlinkInSemantic(HyperlinkText).Click();
            WaitForLoadingToDisappear();

            //Verify inbox name after navigating through hyperlink in semantic page.
            VerifyInboxName(InboxName);

            //Verify Search value in contains field matches with hyperlink text
            if (_pageInstance.SearchEditInGrid.Text.Contains(HyperlinkText))
            {
                LogInfo($"Search value: {_pageInstance.SearchEditInGrid.Text} matched to hyperlink text: {HyperlinkText}");
            }
            else
            {
                Assert.Fail($"Search value: {_pageInstance.SearchEditInGrid.Text} not matched to hyperlink text: {HyperlinkText}");
            }

            //Verify Customer Id in grid result matches with hyperlink text
            if (_pageInstance.CustomerIdGridRecord.Text.Contains(HyperlinkText))
            {
                LogInfo($"Customer Id: {_pageInstance.CustomerIdGridRecord.Text} matched to hyperlink text: {HyperlinkText}");
            }
            else
            {
                Assert.Fail($"Customer Id: {_pageInstance.CustomerIdGridRecord.Text} not matched to hyperlink text: {HyperlinkText}");
            }
        }
        public void InsightIconDisplayed()
        {
            if (_pageInstance.InsightIcon.Displayed)
            {
                LogInfo($"Insight icon is displayed");
                _pageInstance.InsightIcon.Click();
            }
            else
            {
                Assert.Fail($"Insight icon not displayed");
            }
        }

        public void ClickOnViewDetailInExpandCard()
        {
            _pageInstance.ExpandCardViewDetailButton.Click();

        }

        public void VerifyPageTitle(string pageTitle)
        {

            Assert.AreEqual(pageTitle, _pageInstance.GetPageTitle.Text, $" Page title: {_pageInstance.GetPageTitle.Text} is not matching the expected title: {pageTitle}");
        }
        public void NavigateInxonSearch(string direction)
        {
            IList<WindowsElement> Action = _pageInstance.SlideDirection(direction);
            Action[0].Click();
        }
        public void ClickAll()
        {
            IList<WindowsElement> Action = _pageInstance.ClickAll();
            Action[0].Click();
        }
        public void Share(string recipientName)
        {
            _pageInstance.RecipientInputField.Clear();
            SplitAndEnterText(_pageInstance.RecipientInputField, recipientName);

            WaitForMoment(3);
            if (_pageInstance.RecipientDropdown(recipientName).Count == 0)
            {
                _pageInstance.RecipientInputField.Clear();
                SplitAndEnterText(_pageInstance.RecipientInputField, recipientName);
                WaitForMoment(3);
            }

            _pageInstance.RecipientDropdown(recipientName)[0].Click();
            _pageInstance.ShareButton.Click();
            WaitForLoadingToDisappear();
        }
        public void ClickManageAccess(string ChartOrKPIName)
        {
            IList<WindowsElement> ChartOrKPI = _pageInstance.MoreContextMenu(ChartOrKPIName);
            MouseClickOnWindowsElement(ChartOrKPI[0]);
            WaitForMoment(1);
            IList<WindowsElement> manageAccess = _pageInstance.GetElementByText("Manage access");
            if (manageAccess.Count > 0)
            {
                MouseClickOnWindowsElement(manageAccess[0]);
            }
        }
        public void VerifyContentsOnManageAccessPage(string ChartOrKPIName, string recipientName)
        {
            try
            {
                ClickManageAccess(ChartOrKPIName);
                WaitForLoadingToDisappear();
                Assert.IsTrue(_pageInstance.ManageAccessPopupTitle.Displayed, "Manage access popup title not displayed");
                Assert.IsTrue(_pageInstance.FeedbackImageOnPopup.Displayed, "Feedback image on manage access popup not present");
                Assert.IsTrue(_pageInstance.RecipientOnPopup.Displayed, "Recipient not present on manage access pop-up");
                Assert.IsTrue(_pageInstance.UpdateButtonOnPopup.Displayed, "Update button is displayed on manage access pop-up");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            finally
            {
                _pageInstance.ClosePopupImage.Click();
            }
        }

        public void ClearAllButtonDisabled()
        {
            IList<WindowsElement> sortDeleteButtons = _pageInstance.SortDeleteButton.Where(x => x.Displayed).ToList();
            if (sortDeleteButtons.Count == 0)
            {
                WindowsElement ClearAllButton = _pageInstance.SortClearAllButton;
                if (!ClearAllButton.Enabled)
                {
                    LogInfo("Clear All button is disabled.");
                }
                else
                {
                    LogInfo("Clear All button is enabled.");
                    Assert.Fail("Clear All button is enabled.");
                }

            }

        }

        public void VerifyInsightsLabelsDisplayed()
        {
            try
            {
                WaitForMoment(3);
                Assert.IsTrue(_pageInstance.InsightsLabel[0].Displayed, $" On Clicking on Insight icon, Insights label diaplyed with KPI details");
                Assert.IsTrue(_pageInstance.InsightsZoomIcon[0].Displayed, $" On Clicking on Insight icon, Zoom Icon diaplyed with KPI details");
                Assert.IsTrue(_pageInstance.InsightsCloseIcon[0].Displayed, $" On Clicking on Insight icon, Close Icon diaplyed with KPI details");

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        public void VerifyInsightZoomFunctionality()
        {
            if (_pageInstance.InsightsZoomIcon.Count > 0)
            {
                //Click on Zoom Icon in Insights window
                _pageInstance.InsightsZoomIcon[0].Click();
                WaitForLoadingToDisappear();
                LogInfo($"KPIs Should be displayed in expanded view:");
                _pageInstance.BackNavigationButton.Click();
                InsightIconDisplayed();
            }
            else
            {
                Assert.Fail($"Zoom Icon not dispalyed and On Clicking on KPI not displayed in Expand view:");
            }
        }

        public void VerifyInsightCloseFunctionality()
        {
            if (_pageInstance.InsightsCloseIcon.Count > 0)
            {
                //Click on Zoom Icon in Insights window
                _pageInstance.InsightsCloseIcon[0].Click();
                if (_pageInstance.InsightsLabel.Count == 0)
                {
                    LogInfo("On Clicking on Close icon, Insights window is closing ");
                }
                else
                {
                    LogInfo("Close icon not functioning in Insights and Insights window not closing.");
                    Assert.Fail("Close icon not functioning in Insights and Insights window not closing.");
                }
            }
            else
            {
                Assert.Fail($"Insight Close Icon not displayed in Insights Window");
            }
        }

        public void MouseHoverPeronaText(string personaName)
        {
            try
            {
                MouseHoverOnWindowsElement(_pageInstance.PersonaNameText(personaName));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
        public void VerifyInboxPageHeaderText(string inboxPageHeader)
        {
            Assert.AreEqual(inboxPageHeader, _pageInstance.InboxHeaderText.Text, $" Inbox page header text: '{_pageInstance.InboxHeaderText.Text}' is not matching the expected title: '{inboxPageHeader}'");
        }

        public List<string> GetInboxListNames()
        {
            List<string> inboxesStringList = new List<string>();
            IList<WindowsElement> inboxNamesBeforeScroll = _pageInstance.InboxNamesList();
            for (int i = 0; i < inboxNamesBeforeScroll.Count; i++)
            {
                inboxesStringList.Add(inboxNamesBeforeScroll[i].Text);
            }
            ScrollVertically(index: 0);
            IList<WindowsElement> inboxNamesAfterScroll = _pageInstance.InboxNamesList();
            for (int i = 0; i < inboxNamesAfterScroll.Count; i++)
            {
                if (!inboxesStringList.Contains(inboxNamesAfterScroll[i].Text))
                    inboxesStringList.Add(inboxNamesAfterScroll[i].Text);
            }
            return inboxesStringList;
        }

        public bool IsQuickFilterOptionPresent()
        {
            IList<WindowsElement> quickFilterButton = _pageInstance.QuickFilterButton;

            if(quickFilterButton.Count>0)
            {
                quickFilterButton[0].Click();
                LogInfo("Quick Filter option is present in the current page");
                return true;
            }
            else
            {
                LogInfo("Quick Filter option is not present in the current page");
                return false;
            }
        }

        public void ApplyQuickFilters()
        {
            IList<WindowsElement> quickFilterOptions = _pageInstance.QuickFilterTexts;

            if(quickFilterOptions.Count>0)
            {
                quickFilterOptions[0].Click();
                WaitForLoadingToDisappear();
                WaitForMoment(1);
                IList<WindowsElement> allFilterValueCheckboxes = _pageInstance.AllFilterValueCheckboxes.Where(x => x.Text != "").ToList();
                if (allFilterValueCheckboxes.Count > 0)
                {
                    foreach (WindowsElement eachOption in allFilterValueCheckboxes)
                    {
                        WaitForMoment(0.5);
                        MouseClickOnWindowsElement(eachOption);
                    }
                    WaitForMoment(2);
                    _pageInstance.ApplyButton.Click();
                    WaitForLoadingToDisappear();
                }
                else
                {
                    LogInfo("Filter option values are not present in the current popup");
                }
            }
        }
    }
}
