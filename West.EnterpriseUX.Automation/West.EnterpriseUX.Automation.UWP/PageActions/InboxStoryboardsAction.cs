using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using West.EnterpriseUX.Automation.UWP.PageObjects;
using West.EnterpriseUX.Automation.UWP.Utilities;

namespace West.EnterpriseUX.Automation.UWP.PageActions
{
    public class InboxStoryboardsAction : BaseAction
    {
        private readonly WindowsDriver<WindowsElement> _session;
        private readonly InboxStoryboardsPage _pageInstance;

        public InboxStoryboardsAction(WindowsDriver<WindowsElement> session) : base(session)
        {
            this._session = session;
            _pageInstance = new InboxStoryboardsPage(_session);
        }
        public void ClickOnCreateStoryBoard()
        {
            _pageInstance.CreateStoryboardButton.Click();
        }
        public void EnterStoryboardTitle(string title)
        {
            _pageInstance.StoryboardTitleTextbox.Clear();
            _pageInstance.StoryboardTitleTextbox.SendKeys(title);
        }
        public void SelectStoryboardType(string type)
        {
            _pageInstance.SelectStoryboardType(type).Click();
        }
        public void SaveStoryboard()
        {
            _pageInstance.SaveStoryboardButton.Click();
            WaitForLoadingToDisappear(LoadingText.Saving.ToString());
        }
        public void EditStoryboard()
        {
            WaitForMoment(1);
            _pageInstance.EditStoryboardButton.Click();
            WaitForMoment(1);
            IList<WindowsElement> storyboardsItemsRemoveOption = _pageInstance.StoryboardItemsRemoveButton;
            if (storyboardsItemsRemoveOption.Count == 0)
            {
                LogInfo($"Storyboard Remove option is not available on the indvidual KPIs/Charts");
                Assert.Fail($"Storyboard Remove option is not available on the indvidual KPIs/Charts");
            }
        }
        public void ImportCharts()
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            IList<WindowsElement> allCharts = _pageInstance.ImportableCharts;
            if(allCharts.Count==0)
            {
                LogInfo($"No Charts are available to import for storyboard");
                Assert.Fail($"No Charts are available to import for storyboard");
            }
            else
            {
                MouseClickOnWindowsElement(allCharts[0]);
            }
            _pageInstance.ImportChartButton.Click();
        }
        public void ImportKPIs()
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            IList<WindowsElement> allKPIs = _pageInstance.ImportableKPIs;
            if (allKPIs.Count == 0)
            {
                LogInfo($"No KPIs are available to import for storyboard");
                Assert.Fail($"No KPIs are available to import for storyboard");
            }
            else
            {
                MouseClickOnWindowsElement(allKPIs[0]);
            }
            _pageInstance.ImportChartButton.Click();
        }
        public void VerifyStoryboardCreation(string storyboardName,bool isPresent=false)
        {
            IList<WindowsElement> storyboards = _pageInstance.GetStoryboardByName(storyboardName);
            if(isPresent)
            {
                if (storyboards.Count == 0)
                {
                    LogInfo($"Storyboard by name {storyboardName} has not created successfully");
                    Assert.Fail($"Storyboard by name {storyboardName} has not created successfully");
                }
                else
                {
                    LogInfo($"Storyboard by name {storyboardName} has created successfully");
                }
            }
            else
            {
                if (storyboards.Count > 0)
                {
                    LogInfo($"Storyboard by name {storyboardName} exists even after delete operation.");
                    Assert.Fail($"Storyboard by name {storyboardName} exists even after delete operation.");
                }
                else
                {
                    LogInfo($"Storyboard by name {storyboardName} has deleted successfully");
                }
            }
        }
        public void DeleteAllStoryboards()
        {
            int totalDeleteCount = 0;
            WaitForMoment(1);
            IList<WindowsElement> StoryboardDelete;
            IList<WindowsElement> allStoryboards = _pageInstance.Storyboards;
            try
            {
                do
                {
                    if (allStoryboards.Count > 0)
                    {
                        WaitForMoment(1);
                        if (allStoryboards[0].Displayed)
                        {
                            MouseClickOnWindowsElement(allStoryboards[0]);
                            WaitForMoment(1);
                            StoryboardDelete = _pageInstance.StoryboardDelete;
                            WaitForMoment(1);
                            if (StoryboardDelete.Count > 0)
                            {
                                MouseClickOnWindowsElement(StoryboardDelete[0]);
                                WaitForMoment(1);
                                WindowsElement yesConfirmationButton = _pageInstance.ConfirmationYesButton;
                                MouseClickOnWindowsElement(yesConfirmationButton);
                                WaitForMoment(1);
                                WaitForLoadingToDisappear(LoadingText.Removing.ToString());
                                WaitForMoment(1);
                            }
                        }
                        allStoryboards = _pageInstance.Storyboards;
                        totalDeleteCount++;
                    }
                } while (allStoryboards.Count != 0 && totalDeleteCount <= 7);
                LogInfo($"Total Deleted Storyboards : {totalDeleteCount}");
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }
        public int GetStoryboardsCount()
        {
            return _pageInstance.Storyboards.Count;
        }
        public void SelectStoryboardByName(string storyboardName)
        {
            IList<WindowsElement> storyboard = _pageInstance.GetStoryboardByName(storyboardName);
            if (storyboard.Count > 0)
            {
                MouseClickOnWindowsElement(storyboard[0]);
            }
            else
            {
                LogInfo($"Storyboard by name {storyboardName} is not found in the current page");
                Assert.Fail($"Storyboard by name {storyboardName} is not found in the current page");
            }
        }
        public void DeleteStoryboardByCount(int valueToDelete = 0)
        {
            int totalDeleteCount = 0;
            int attempt = 0;
            WaitForMoment(1);
            IList<WindowsElement> storyboardsItems = _pageInstance.StoryboardItemsRemoveButton;
            try
            {
                do
                {

                    if (storyboardsItems.Count > 0)
                    {
                        WaitForMoment(1);
                        if (storyboardsItems[0].Displayed)
                        {
                            MouseClickOnWindowsElement(storyboardsItems[0]);
                            WaitForMoment(1);
                            storyboardsItems = _pageInstance.StoryboardItemsRemoveButton;
                            WaitForMoment(1);
                            totalDeleteCount++;
                        }
                    }
                    attempt++;
                } while (valueToDelete != totalDeleteCount && attempt <= 3);
            }
            catch (Exception ex)
            {
                LogError($"{ex.Message} : {ex.StackTrace}");
            }
        }
        public void ClickOnYes()
        {
            _pageInstance.ConfirmationYesButton.Click();
            WaitForLoadingToDisappear();
        }
        public void VerifyStoryboardItemsCount(int expectedItemsCount)
        {
            IList<WindowsElement> actualItemsCount = _pageInstance.StoryboardItemsRemoveButton;
            if (expectedItemsCount!= actualItemsCount.Count)
            {
                LogInfo($"Storyboard Items expected count:{actualItemsCount} not matching with the actual count{expectedItemsCount} after edit operation.");
                Assert.Fail($"Storyboard Items expected count:{ actualItemsCount} not matching with the actual count{ expectedItemsCount} after edit operation.");
            }
        }
        public void ClickOnDeleteStoryboard()
        {
            IList<WindowsElement> storyboardDelete=_pageInstance.StoryboardDelete;
            if(storyboardDelete.Count>0)
            {
                MouseClickOnWindowsElement(storyboardDelete[0]);
            }
            else
            {
                LogInfo($"Not able to find the Storyboard Delete Icon Image");
            }
           
        }
        public bool IsCreateStoryboardButtonPresent()
        {
            int count = _pageInstance.CreateStoryboardbutton.Count;
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ImportReports()
        {
            WaitForLoadingToDisappear();
            WaitForMoment(1);
            IList<WindowsElement> allReports = _pageInstance.SelectReportToImport;
            if (allReports.Count == 0)
            {
                LogInfo($"No Reports are available to import for storyboard");
                Assert.Fail($"No Reports are available to import for storyboard");
            }
            else
            {
                allReports[0].Click();
                //MouseClickOnWindowsElement(allReports[0]);
            }
            _pageInstance.ImportChartButton.Click();
        }
    }
}
